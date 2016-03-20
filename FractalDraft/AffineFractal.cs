using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace FractalDraft
{
    class AffineFractal : AFractal
    {
        private List<Affine> Affines { get; }
        private List<double> Props { get; }



        public AffineFractal(string name, List<Affine> affines, List<double> props, int preferablyIterations, double preferablyScale)
            : base(name, preferablyIterations, preferablyScale)
        {
            if (affines.Count != props.Count)
                throw new Exception("Affines.Count != Props.Count");

            Affines = affines;
            Props = props;
        }

        private List<Point> GeneratePoints(Point startPoint, int iterationsCount, double scale)
        {
            var points = new List<Point> { startPoint };


            var point = new Point(0, 0);
            for (int i = 0; i < iterationsCount; i++)
            {
                point = Affines.Random(Props).ApplyTo(point);
                var res = new Point(point.X * scale + startPoint.X, startPoint.Y - point.Y * scale);
                points.Add(res);
            }
            //for (int i = 0; i < _iterationsCount; i++)
            //{
            //    var affine = affines[(i + 2) % affines.Count];
            //    point = affine.ApplyTo(point);
            //    var res = new Point(point.X * _scale + startPoint.X, startPoint.Y - point.Y * _scale);
            //    points.Add(res);
            //}

            return points;
        }

        public override WriteableBitmap Draw(DrawingArgs args)
        {
            int w = (int)args.CanvasWidth;
            int h = (int)args.CanvasHeight;
            var fractalBitmap = new WriteableBitmap(w, h, 96.0, 96.0, PixelFormats.Bgra32, null);

            var width = (int)fractalBitmap.Width;
            var rawStride = (width * PixelFormats.Bgra32.BitsPerPixel + 7) / 8;

            var points = GeneratePoints(args.StartPoint, args.IterationsCount, args.Scale);

            var stride = w * 4;
            var pixelData = new byte[h * stride];
            Int32Rect rect;

            int i = -1;

            foreach (var point in points)
                if (point.X < w && point.Y < h &&
                    point.X >= 0 && point.Y >= 0)
                {
                    int offset = (int)point.Y * stride + (int)point.X * 4;

                    if (args.ColorMode)
                    {
                        UpdateColor(pixelData, offset);
                    }
                    else
                    {
                        pixelData[offset] = 255;
                        pixelData[offset + 1] = 255;
                        pixelData[offset + 2] = 255;
                        pixelData[offset + 3] = 255;
                    }

                    i++;
                    if (!args.DelayFlag || i % args.Delay != 0)
                        continue;

                    rect = new Int32Rect(0, 0, w, h);
                    fractalBitmap.WritePixels(rect, pixelData, rawStride, 0);

                    // TODO: partial redraw
                    //args.Image.Refresh();
                    //args.Image.InvalidateVisual();
                    //Thread.Sleep(args.Delay);
                }

            rect = new Int32Rect(0, 0, w, h);
            fractalBitmap.WritePixels(rect, pixelData, rawStride, 0);

            return fractalBitmap;
        }

        #region Colors

        static public byte ColorR;
        static public bool ColorRflag = true;
        static public byte ColorRstep;
        static public byte ColorG;
        static public bool ColorGflag = true;
        static public byte ColorGstep;
        static public byte ColorB;
        static public bool ColorBflag = true;
        static public byte ColorBstep;

        private void UpdateColor(byte[] color, int offset)
        {
            if (color[offset + 3] == 0) // first hit
            {
                color[offset + 0] = ColorB;
                color[offset + 1] = ColorG;
                color[offset + 2] = ColorR;
                color[offset + 3] = 255;
                return;
            }

            UpdateColorByte(ColorBflag, ColorRstep, ref color[offset + 0]);
            UpdateColorByte(ColorGflag, ColorGstep, ref color[offset + 1]);
            UpdateColorByte(ColorRflag, ColorBstep, ref color[offset + 2]);
        }
        private void UpdateColorByte(bool flag, byte step, ref byte b)
        {
            // Stopping:
            if (flag)
            {
                if (b + step <= 255)
                    b += step;
                else
                    b = 255;
            }
            else
            {
                if (b - step >= 0)
                    b -= step;
                else
                    b = 0;
            }

            // Cycling:
            //if (flag)
            //{
            //    if (b < 255)
            //        b = (byte)(b + step); // construction for unchecked sum
            //    else
            //        b = 0;
            //}
            //else
            //{
            //    if (b > 0)
            //        b = (byte)(b - step); // construction for unchecked sum
            //    else
            //        b = 255;
            //}
        }
        #endregion Colors
    }
}
