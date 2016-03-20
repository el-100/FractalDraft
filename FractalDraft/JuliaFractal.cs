using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace FractalDraft
{
    public class JuliaFractal : AFractal
    {
        private Complex C { get; }

        public JuliaFractal(string name, int preferablyIterations, double preferablyScale, Complex c)
            : base(name, preferablyIterations, preferablyScale)
        {
            C = c;
        }

        public override WriteableBitmap Draw(DrawingArgs args)
        {
            int scale = (int) args.Scale;
            var h = args.CanvasHeight;
            var w = h;
            var fractalBitmap = new WriteableBitmap(w * scale, h * scale, 96.0, 96.0, PixelFormats.Bgra32, null);

            h = h * scale;
            w = w * scale;

            var stride = w * 4;
            var pixelData = new byte[h * stride];

            double xMin = double.NaN;
            double yMin = double.NaN;
            double xMax = double.NaN;
            double yMax = double.NaN;

            double r = CalculateR(C);
            if (Double.IsNaN(xMin) || Double.IsNaN(xMax) || Double.IsNaN(yMin) || Double.IsNaN(yMax))
            {
                xMin = -r;
                yMin = -r;
                xMax = r;
                yMax = r;
            }
            double xStep = Math.Abs(xMax - xMin) / w;
            double yStep = Math.Abs(yMax - yMin) / h;

            var xyIdx = new Dictionary<int, IDictionary<int, int>>();
            int maxIdx = 0;
            for (int i = 0; i < w; i++)
            {
                xyIdx.Add(i, new Dictionary<int, int>());
                for (int j = 0; j < h; j++)
                {
                    double x = xMin + i * xStep;
                    double y = yMin + j * yStep;
                    var z = new Complex(x, y);
                    var zIter = SqPolyIteration(z, C, args.IterationsCount, r);
                    int idx = zIter.Count - 1;
                    if (maxIdx < idx)
                    {
                        maxIdx = idx;
                    }
                    xyIdx[i].Add(j, idx);
                }
            }
            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    int idx = xyIdx[i][j];
                    double x = xMin + i * xStep;
                    double y = yMin + j * yStep;
                    var z = new Complex(x, y);

                    var color = ComplexHeatMap(idx, 0, maxIdx, z, r);
                    pixelData[j * stride + (w - i - 1) * 4 + 0] = color.R;
                    pixelData[j * stride + (w - i - 1) * 4 + 1] = color.G;
                    pixelData[j * stride + (w - i - 1) * 4 + 2] = color.B;
                    pixelData[j * stride + (w - i - 1) * 4 + 3] = color.A;
                }
            }

            var rect = new Int32Rect(0, 0, w - 1, h - 1);
            var rawStride = (w * PixelFormats.Bgra32.BitsPerPixel + 7) / 8;

            fractalBitmap.WritePixels(rect, pixelData, rawStride, 0);

            return fractalBitmap;
        }

        private static IList<Complex> SqPolyIteration(Complex z0, Complex c, int n, double r = 0)
        {
            IList<Complex> res = new List<Complex>();
            res.Add(z0);
            for (int i = 0; i < n; i++)
            {
                if (r > 0)
                {
                    if (res.Last().Magnitude > r)
                    {
                        break;
                    }
                }
                res.Add(res.Last() * res.Last() + c);
            }
            return res;
        }

        private static double CalculateR(Complex c)
        {
            return (1 + Math.Sqrt(1 + 4 * c.Magnitude)) / 2;
        }

        private static Color ComplexHeatMap(decimal value, decimal min, decimal max, Complex z, double r)
        {
            decimal val = (value - min) / (max - min);
            return Color.FromArgb(
                255,
                Convert.ToByte(255 * val),
                Convert.ToByte(255 * (1 - val)),
                Convert.ToByte(255 * (z.Magnitude / r > 1 ? 1 : z.Magnitude / r))
            );
        }
    }
}