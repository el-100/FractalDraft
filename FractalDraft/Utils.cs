using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Threading;

namespace FractalDraft
{
    static class ExtensionMethods
    {
        static Random Rnd = new Random();

        public static T Random<T>(this IEnumerable<T> enumerable, List<double> weights)
        {
            double r = Rnd.NextDouble();
            double totalWeight = 0;
            int i = 0;
            T selected = default(T);

            foreach (var data in enumerable)
            {
                if (r >= totalWeight)
                    selected = data;
                totalWeight += weights[i];
                i++;
            }

            return selected; // when iterations end, selected is some element of sequence. 
        }


        private static Action EmptyDelegate = delegate { };


        public static void Refresh(this UIElement uiElement)
        {
            uiElement.Dispatcher.Invoke(DispatcherPriority.Render, EmptyDelegate);

            //Application.Current.Dispatcher.BeginInvoke(
            //    DispatcherPriority.Background,
            //    new Action(() =>
            //    {
            //        // Do something here.
            //    }));
        }

    }
}
