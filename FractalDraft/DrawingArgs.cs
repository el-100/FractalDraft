using System.Windows;
using System.Windows.Controls;

namespace FractalDraft
{
    public class DrawingArgs
    {
        public int CanvasWidth;
        public int CanvasHeight;
        public Point StartPoint;
        public int IterationsCount;
        public double Scale;
        public int Delay;
        public bool DelayFlag;
        public bool ColorMode;
    }
}