using System.Windows.Media.Imaging;

namespace FractalDraft
{
    public class MandelbrotFractal : AFractal
    {
        public MandelbrotFractal(string name, int preferablyIterations, double preferablyScale)
            : base(name, preferablyIterations, preferablyScale)
        { }
        

        public override WriteableBitmap Draw(DrawingArgs args)
        {
            /*var fractalBitmap = new WriteableBitmap((int)args.Canvas.ActualWidth, (int)args.Canvas.ActualHeight, 96.0, 96.0, PixelFormats.Bgra32, null);
            args.Image.Source = fractalBitmap;

            var width = (int)fractalBitmap.Width;
            var rawStride = (width * PixelFormats.Bgra32.BitsPerPixel + 7) / 8;
            var pixelData = new byte[] {255, 255, 255, 255};
            
            var startPoint = Mouse.GetPosition(args.Canvas);
            var scale = args.Scale;


            for (double imagCoord = 1.2; imagCoord >= -1.2; imagCoord -= 0.01)
            {
                for (double realCoord = -0.6; realCoord <= 1.77; realCoord += 0.01)
                {
                    double realTemp = realCoord;
                    double imagTemp = imagCoord;
                    double arg = (realCoord * realCoord) + (imagCoord * imagCoord);
                    for (int i = 0; (arg < 4) && (i < 40); i++)
                    {
                        double realTemp2 = (realTemp * realTemp) - (imagTemp * imagTemp) + realCoord;
                        imagTemp = (2 * realTemp * imagTemp) + imagCoord;
                        realTemp = realTemp2;
                        arg = (realTemp * realTemp) + (imagTemp * imagTemp);

                        points.Add(new Point(realTemp * scale + startPoint.X, startPoint.Y - imagTemp * scale));
                    }
                }
            }

            foreach (var point in points)
                if (point.X < args.Canvas.ActualWidth && point.Y < args.Canvas.ActualHeight &&
                    point.X >= 0 && point.Y >= 0)
                {

                    var rect = new Int32Rect((int)Math.Abs(point.X), (int)Math.Abs(point.Y), 1, 1);
                    
                    fractalBitmap.WritePixels(rect, pixelData, rawStride, 0);

                    if (!args.DelayFlag)
                        continue;
                    args.Image.Refresh();
                    Thread.Sleep(args.Delay);
                }*/

            return null;
        }
    }
}