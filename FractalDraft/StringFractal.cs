using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media.Imaging;

namespace FractalDraft
{
    public class StringFractal : AFractal
    {
        private const double STEP = 0.2;

        private string _text;
        private AffineFractal _affineFractal;

        public StringFractal(string name, string text, int preferablyIterations, double preferablyScale)
            : base(name, preferablyIterations, preferablyScale)
        {
            _text = text.ToUpper();

            GenerateAffineFractal();
        }

        private void GenerateAffineFractal()
        {
            // Считаем количество необходимых преобразований и длину строки
            double width = 0.0;
            int countTransforms = 0;
            for (int i = 0; i < _text.Length; ++i)
            {
                char ch = _text[i];

                if (Letters.Get(ch) == null)
                    continue;
                countTransforms += Letters.Get(ch).Triangles.Count;
                width += Letters.Get(ch).Width + STEP;

            }
            width -= STEP;

            //Вычисляем сами преобразования
            var affines = new List<Affine>();
            double shift = 0.0;
            double sump = 0.0;

            foreach (char ch in _text.Where(ch => Letters.Get(ch) != null))
            {
                foreach (var triangle in Letters.Get(ch).Triangles)
                {
                    var a = 1.0 / width * (-triangle[2] + triangle[4]);
                    var b = triangle[0] - triangle[2];
                    var e = 1.0 / width * (triangle[2] + shift);
                    var c = 1.0 / width * (-triangle[3] + triangle[5]);
                    var d = triangle[1] - triangle[3];
                    var f = 1.0 / width * triangle[3];
                    affines.Add(new Affine(a, b, c, d, e, f));
                    sump += Math.Abs(a * d - b * c);
                }
                shift += Letters.Get(ch).Width + STEP;
            }

            // Расчитываем веротностные коэффициенты
            var props = new List<double>();
            for (int i = 0; i < countTransforms; ++i)
            {
                props.Add(Math.Abs(affines[i].A * affines[i].D -
                                   affines[i].B * affines[i].C) / sump);
            }

            _affineFractal = new AffineFractal(Name + "_affine", affines, props, PreferablyIterations, PreferablyScale);
        }

        public override WriteableBitmap Draw(DrawingArgs args)
        {
            return _affineFractal.Draw(args);
        }
    }
}