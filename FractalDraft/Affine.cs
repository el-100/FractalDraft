using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FractalDraft
{
    class Affine
    {
        public double A { get; }
        public double B { get; }
        public double C { get; }
        public double D { get; }
        public double E { get; }
        public double F { get; }

        public Point ApplyTo(Point p)
        {
            double x = A * p.X + B * p.Y + E;
            double y = C * p.X + D * p.Y + F;
            return new Point(x, y);
        }

        public Affine(double a0, double b0, double c0, double d0, double e0, double f0)
        {
            A = a0;
            B = b0;
            C = c0;
            D = d0;
            E = e0;
            F = f0;
        }
    }
}
