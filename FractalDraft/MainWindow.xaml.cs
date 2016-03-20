using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace FractalDraft
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        int _iterationsCount;
        double _scale;
        int _delay;

        private List<AFractal> Fractals { get; } = new List<AFractal>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Loaded, new Action(() => { checkBoxUsePreferably.IsChecked = true; }));

        }


        #region Textbox Validations

        readonly SolidColorBrush _validInput = new SolidColorBrush(Colors.Black);
        readonly SolidColorBrush _badInput = new SolidColorBrush(Colors.Red);

        private void textBoxIterarions_TextChanged(object sender, TextChangedEventArgs e)
        {
            var tb = (TextBox)sender;
            UpdateIntTextBox(tb, ref _iterationsCount);
        }
        private void textBoxScale_TextChanged(object sender, TextChangedEventArgs e)
        {
            var tb = (TextBox)sender;
            UpdateDoubleTextBox(tb, ref _scale);
        }
        private void textBoxDelay_TextChanged(object sender, TextChangedEventArgs e)
        {
            var tb = (TextBox)sender;
            UpdateIntTextBox(tb, ref _delay);
        }

        private void UpdateIntTextBox(TextBox tb, ref int depVal)
        {
            int i;
            if (int.TryParse(tb.Text, out i))
            {
                depVal = i;
                tb.Foreground = _validInput;
            }
            else
                tb.Foreground = _badInput;
        }
        private void UpdateDoubleTextBox(TextBox tb, ref double depVal)
        {
            double d;
            if (double.TryParse(tb.Text, out d))
            {
                depVal = d;
                tb.Foreground = _validInput;
            }
            else
                tb.Foreground = _badInput;
        }


        #region Colors
        private void textBoxR_TextChanged(object sender, TextChangedEventArgs e)
        {
            var tb = (TextBox)sender;
            UpdateColorTextBox(tb, ref AffineFractal.ColorR, ref AffineFractal.ColorRstep, ref AffineFractal.ColorRflag);
        }
        private void textBoxG_TextChanged(object sender, TextChangedEventArgs e)
        {
            var tb = (TextBox)sender;
            UpdateColorTextBox(tb, ref AffineFractal.ColorG, ref AffineFractal.ColorGstep, ref AffineFractal.ColorGflag);
        }
        private void textBoxB_TextChanged(object sender, TextChangedEventArgs e)
        {
            var tb = (TextBox)sender;
            UpdateColorTextBox(tb, ref AffineFractal.ColorB, ref AffineFractal.ColorBstep, ref AffineFractal.ColorBflag);
        }
        private void UpdateColorTextBox(TextBox tb, ref byte depVal, ref byte depStep, ref bool depFlag)
        {
            string text = tb.Text;
            string[] parts;
            if (text.Count(c => c == '+') == 1)
            {
                depFlag = true;
                parts = text.Split('+');
            }
            else if (text.Count(c => c == '-') == 1)
            {
                depFlag = false;
                parts = text.Split('-');
            }
            else
            {
                tb.Foreground = _badInput;
                return;
            }

            byte tmpVal;
            if (byte.TryParse(parts[0], out tmpVal))
            {
                byte tmpStep;
                if (byte.TryParse(parts[1], out tmpStep))
                {
                    depVal = tmpVal;
                    depStep = tmpStep;
                    tb.Foreground = _validInput;
                }
                else
                    tb.Foreground = _badInput;
            }
            else
                tb.Foreground = _badInput;

        }
        #endregion Colors

        #endregion Textbox Validations


        #region Affines

        private void FractalsInit()
        {
            Fractals.Add(new AffineFractal("Лист папоротника",
                                    new List<Affine> { new Affine(0, 0, 0, 0.16, 0, 0),
                                                       new Affine(0.85, 0.04, -0.04, 0.85, 0, 1.6),
                                                       new Affine(0.2, -0.26, 0.23, 0.22, 0, 1.6),
                                                       new Affine(-0.15, 0.28, 0.26, 0.24, 0, 0.44) },
                                    new List<double> { 0.01, 0.85, 0.07, 0.07 },
                                    100000, 50));

            Fractals.Add(new AffineFractal("Кленовый лист",
                                    new List<Affine> { new Affine(0.45, 0, 0, 0.5, -0.02, -1.2),
                                                       new Affine(0.45, 0.5, -0.5, 0.5, 1.5, -0.75),
                                                       new Affine(0.45, -0.5, 0.5, 0.5, -1.5, -0.75),
                                                       new Affine(0.45, 0, 0, 0.5, 0.02, 1.62) },
                                    new List<double> { 0.15, 0.35, 0.35, 0.15 },
                                    2000000, 75));

            Fractals.Add(new AffineFractal("Кленовый лист 2",
                                    new List<Affine> { new Affine(0.49, -0.01, 0, 0.62, 0.25, 0.02),
                                                       new Affine(0.27, -0.52, 0.4, 0.36, 0, -0.56),
                                                       new Affine(0.18, 0.73, -0.5, 0.26, 0.88, -0.08),
                                                       new Affine(0.04, 0.01, -0.5, 0, 0.52, -0.32), },
                                    new List<double> { 0.316, 0.316, 0.316, 0.052 },
                                    2000000, 500));

            Fractals.Add(new AffineFractal("Дракон Хартера-Хейтуэя",
                                    new List<Affine> { new Affine(-0.5, -0.5, 0.5, -0.5, 490, 120),
                                                       new Affine(0.5, -0.5, 0.5, 0.5, 340, -110) },
                                    new List<double> { 0.50, 0.50 },
                                    250000, 1));

            Fractals.Add(new AffineFractal("Треугольник серпинского",
                                    new List<Affine> { new Affine(0.5, 0, 0, 0.5, 0, 0),
                                                       new Affine(0.5, 0, 0, 0.5, 0.5, 0),
                                                       new Affine(0.5, 0, 0, 0.5, 0.25, 0.43301270189221932338186158537647) },
                                    new List<double> { 0.33, 0.33, 0.34 },
                                    100000, 500));

            Fractals.Add(new AffineFractal("Треугольник серпинского 2",
                        new List<Affine> { new Affine(0.333333, 0, 0, 0.333333, 0, 0),
                                           new Affine(0.333333, 0, 0, 0.333333, 0.333333, 0),
                                           new Affine(0.333333, 0, 0, 0.333333, 0.666667, 0),
                                           new Affine(0.333333, 0, 0, 0.333333, 0.166667, 0.288675),
                                           new Affine(0.333333, 0, 0, 0.333333, 0.5, 0.288675),
                                           new Affine(0.333333, 0, 0, 0.333333, 0.333333, 0.577350), },
                        new List<double> { 0.166667, 0.166667, 0.166667, 0.166667, 0.166667, 0.166667 },
                        100000, 500));

            double x1 = 0, y1 = 0.5;
            double x2 = 0.5, y2 = 0;
            Fractals.Add(new AffineFractal("Треугольник серпинского - втф",
                                    new List<Affine> { new Affine(x1, y1, x2, y2, 0, 0),
                                                       new Affine(x1, y1, x2, y2, 0.5, 0),
                                                       new Affine(x1, y1, x2, y2, 0.25, 0.43301270189221932338186158537647) },
                                    new List<double> { 0.33, 0.33, 0.34 },
                                    100000, 500));

            Fractals.Add(new AffineFractal("Фрактальная пыль",
                                    new List<Affine> { new Affine(0.33, 0, 0, 0.33, 0, 0),
                                                       new Affine(0.33, 0, 0, 0.33, 0.5, 0),
                                                       new Affine(0.33, 0, 0, 0.33, 0.25, 0.43301270189221932338186158537647) },
                                    new List<double> { 0.33, 0.33, 0.34 },
                                    10000, 750));

            Fractals.Add(new AffineFractal("Салфетка серпинского",
                                    new List<Affine> { new Affine(0.33, 0, 0, 0.33, 0.5, 0.866025),
                                                       new Affine(0.33, 0, 0, 0.33, -0.5, 0.866025),
                                                       new Affine(0.33, 0, 0, 0.33, -1.0, 0.0),
                                                       new Affine(0.33, 0, 0, 0.33, -0.5, -0.866025),
                                                       new Affine(0.33, 0, 0, 0.33, 0.5, -0.866025),
                                                       new Affine(0.33, 0, 0, 0.33, 1.0, 0.0) },
                                    new List<double> { 0.166, 0.166, 0.166, 0.166, 0.166, 0.1664 },
                                    200000, 200));

            Fractals.Add(new AffineFractal("Дракон",
                                    new List<Affine> { new Affine(0.824074, 0.281482, -0.212346, 0.864198, -1.882290, -0.110607),
                                                       new Affine(0.088272, 0.520988, -0.463889, -0.377778, 0.785360, 8.095795), },
                                    new List<double> { 0.787473, 0.212527 },
                                    200000, 75));

            Fractals.Add(new AffineFractal("Boxes",
                                    new List<Affine> { new Affine(0.5, 0.5, 0.0, 0.0, 0.00, 0.00),
                                                       new Affine(0.5, 0.5, 0.0, 0.0, 0.00, 1.00),
                                                       new Affine(0.0, 0.0, 0.5, 0.5, 0.00, 0.00),
                                                       new Affine(0.0, 0.0, 0.5, 0.5, 1.00, 0.00),
                                                       new Affine(0.5, 0.0, 0.0, 0.5, 0.25, 0.25), },
                                    new List<double> { 0.166, 0.166, 0.166, 0.166, 0.336 },
                                    100000, 500));

            Fractals.Add(new AffineFractal("Needle",
                                    new List<Affine> { new Affine(0.636364, -0.727273, -0.515152, -0.405303,  3.395211, 5.032732 ),
                                                       new Affine(0.151515, -0.321970,  0.484848, -0.155303, -3.669363, 5.726923 ), },
                                    new List<double> { 0.826733, 0.173267 },
                                    100000, 50));

            Fractals.Add(new AffineFractal("Star_49",
                        new List<Affine> { new Affine(0.6, 0, 0, 0.21, 0, 0),
                                           new Affine(-0.55, 0.75, -0.75, -0.55, 1.55, 0.75), },
                        new List<double> { 0.3, 0.7 },
                        100000, 500));

            Fractals.Add(new AffineFractal("Stairway",
                        new List<Affine> { new Affine(0.5, 0.5, 0, 0, 0, 0.5),
                                           new Affine(0.5, 0.5, 0, 0, 0, -0.5),
                                           new Affine(0, 0, 0.5, 0.5, 0.5, 0),
                                           new Affine(0, 0, 0.5, 0.5, -0.5, 0),
                                           new Affine(0.85, -0.15, 0.15, 0.85, 0, 0), },
                        new List<double> { 0.08, 0.08, 0.08, 0.08, 0.68 },
                        300000, 500));

            Fractals.Add(new AffineFractal("Leaf_70",
                        new List<Affine> { new Affine(0.000000, 0.243900, 0.000000, 0.305300, 0.000000, 0.000000),
                                           new Affine(0.724800, 0.033700, -0.025300, 0.742600, 0.206000, 0.253800),
                                           new Affine(0.158300, -0.129700, 0.355000, 0.367600, 0.138300, 0.175000),
                                           new Affine(0.338600, 0.369400, 0.222700, -0.075600, 0.067900, 0.082600), },
                        new List<double> { 0.010000, 0.710544, 0.137386, 0.142169 },
                        100000, 500));

            Fractals.Add(new AffineFractal("Floor_4",
                        new List<Affine> { new Affine(0.0, 0.5, -0.5, 0.0, 0.0, 0.5),
                                           new Affine(0.5, 0.0, 0.0, 0.5, 0.5, 0.0),
                                           new Affine(0.0, -0.5, 0.5, 0.0, 1.0, 0.5), },
                        new List<double> { 0.333333, 0.333333, 0.333333 },
                        200000, 750));

            Fractals.Add(new AffineFractal("Nautilus",
                        new List<Affine> { new Affine(0.860671, 0.401487, -0.402177, 0.860992, 0.108537, 0.075138),
                                           new Affine(0.094957, -0.000995, 0.237023, 0.002036, -0.746911, 0.047343),
                                           new Affine(0.150288, 0.000000, 0.000000, 0.146854, -0.563199, 0.032007),
                                           new Affine(0.324279, -0.002163, 0.005846, 0.001348, -0.557936, -0.139735), },
                        new List<double> { 0.956972, 0.009813, 0.023402, 0.009813 },
                        1000000, 500));

            Fractals.Add(new AffineFractal("Cross_2",
                        new List<Affine> { new Affine(0.333333, 0, 0, 0.333333, 0, 0),
                                           new Affine(0.333333, 0, 0, 0.333333, 0.333333, 0),
                                           new Affine(0.333333, 0, 0, 0.333333, -0.333333, 0),
                                           new Affine(0.333333, 0, 0, 0.333333, 0, 0.333333),
                                           new Affine(0.333333, 0, 0, 0.333333, 0, -0.333333), },
                        new List<double> { 0.2, 0.2, 0.2, 0.2, 0.2 },
                        100000, 1000));

            //Fractals.Add(new AffineFractal("AffineFractal Template",
            //                        new List<Affine> { new Affine(),
            //                                           new Affine(),
            //                                           new Affine(),
            //                                           new Affine(),
            //                                           new Affine(),
            //                                           new Affine(), },
            //                        new List<double> {  },
            //                        100000, 1));

            Fractals.Add(new StringFractal("Fractal string", "Fractal", 200000, 1800));
            Fractals.Add(new StringFractal("Fractal string 2", "IBKS LAL", 200000, 1800));

            //Fractals.Add(new JuliaFractal("Julia set (-0.12, 0.74)", 100, 1, new Complex(-0.12, 0.74)));
            Fractals.Add(new JuliaFractal("Julia set (-0.74543, 0.11301)", 1000, 4, new Complex(-0.74543, 0.11301)));


            //Fractals.Add(new MandelbrotFractal("Mandelbrot set", 10000, 1));
        }

        private void comboBoxFractals_Loaded(object sender, RoutedEventArgs e)
        {
            FractalsInit();

            foreach (var fractal in Fractals)
            {
                var cbi = new ComboBoxItem { Content = fractal.ToString() };

                comboBoxFractals.Items.Add(cbi);
            }

            comboBoxFractals.SelectedIndex = comboBoxFractals.Items.Count - 1;
        }


        private void comboBoxFractals_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            checkBoxUsePreferably_Checked(this, null);
        }

        private void checkBoxUsePreferably_Checked(object sender, RoutedEventArgs e)
        {
            if (checkBoxUsePreferably.IsChecked == true)
            {
                var fractal = Fractals[comboBoxFractals.SelectedIndex];
                textBoxIterarions.Text = fractal.PreferablyIterations.ToString();
                textBoxScale.Text = fractal.PreferablyScale.ToString(CultureInfo.InvariantCulture);
            }
        }
        #endregion Affines



        private void image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            //canvas.UpdateLayout();
            var fractal = Fractals[comboBoxFractals.SelectedIndex];

            var args = new DrawingArgs
            {
                CanvasWidth =  (int)ImageGrid.ActualWidth,
                CanvasHeight = (int)ImageGrid.ActualHeight,
                StartPoint = Mouse.GetPosition(ImageGrid),
                ColorMode = checkBoxColorMode.IsChecked == true,
                Delay = _delay,
                IterationsCount = _iterationsCount,
                DelayFlag = checkBoxDelay.IsChecked == true,
                Scale = _scale
            };


            // TODO: make it at another thread
            DrawFractalThread(fractal, args);
            
        }


        async void DrawFractalThread(AFractal fractal, DrawingArgs args)
        {
            FractalSettingsGrid.IsEnabled = false;
            var bmp = fractal.Draw(args);
            image.Source = bmp;
            FractalSettingsGrid.IsEnabled = true;

            // control size for Julia fractal
            if (fractal.GetType() != typeof(JuliaFractal))
            {
                image.Width = bmp.Width;
                image.Height = bmp.Height;
            }
            else
            {
                image.Width = args.CanvasWidth;
                image.Height = args.CanvasHeight;
            }
            image.InvalidateArrange();
            image.InvalidateMeasure();
        }


    }
}
