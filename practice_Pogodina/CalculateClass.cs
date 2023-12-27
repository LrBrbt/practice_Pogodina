using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;

namespace practice_Pogodina
{
    public static class CalculateClass
    {
        public static double k;
        public static double b;

        public static Polyline CalculateFunction()
        {
            Polyline line = new Polyline();
            Color graphColor = Color.FromRgb(30, 36, 96);
            line.Stroke = new SolidColorBrush(graphColor);
            line.StrokeThickness = 2;

            // построение линии
            for (int i = 0; i <= 500; i++)
            {
                double xVal = i - 250; // размещаем точку (0,0) в центре канваса
                double yVal = k * xVal + b;

                line.Points.Add(new Point(i, 150 - yVal));
            }

            return line;
        }
    }
}
