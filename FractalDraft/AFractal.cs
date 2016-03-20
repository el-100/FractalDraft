using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace FractalDraft
{
    public abstract class AFractal
    {
        public string Name { get; private set; }
        public int PreferablyIterations { get; private set; }
        public double PreferablyScale { get; private set; }

        
        public abstract WriteableBitmap Draw(DrawingArgs args);


        protected AFractal(string name, int preferablyIterations, double preferablyScale)
        {
            Name = name;
            PreferablyIterations = preferablyIterations;
            PreferablyScale = preferablyScale;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}