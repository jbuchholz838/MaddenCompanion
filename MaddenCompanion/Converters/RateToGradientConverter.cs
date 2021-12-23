using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace MaddenCompanion.Converters
{
    class RateToGradientConverter : IValueConverter
    {
        // Defines a "bar chart type" background using a of a cell based on its value 
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            double dblValue = 0;

            if (value != null && double.TryParse(value.ToString(), out dblValue))
            {
                var linBrush = new LinearGradientBrush();
                linBrush.StartPoint = new System.Windows.Point(0, 0);
                linBrush.EndPoint = new System.Windows.Point(1, 0);
                //linBrush.GradientStops.Add(new GradientStop(Color.FromRgb(181, 255, 150), dblValue / 100));
                linBrush.GradientStops.Add(new GradientStop(GetBackColor((int)dblValue), dblValue / 100));
                linBrush.GradientStops.Add(new GradientStop(Color.FromArgb(204, 204, 204, 255), dblValue / 100 + 0.001));
                //linBrush.GradientStops.Add(new GradientStop(GetBackColor((int)dblValue), dblValue / 100 + 0.001));
                return linBrush;
            }
            else
                return Binding.DoNothing;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private Color GetBackColor(int val)
        {
            double max = 99;
            double min = 40;

            if (val < min)
                val = (int)min;

            if (val > max)
                val = (int)max;

            double perRed = 0;
            double perGreen = 0;
            string color = "";
            double ratio = 0;

            ratio = 1 / (max - min);
            var finalValue = (val - min) * ratio;

            if (finalValue == 0.5)
            {
                perRed = 1;
                perGreen = 1;
            }
            else if (finalValue > 0.5)
            {
                perGreen = 1;
                perRed = (1 - finalValue) * 2;
            }
            else
            {
                perRed = 1;
                perGreen = finalValue * 2;
            }

            var red = (int)Math.Round(255.0 * perRed);
            var green = (int)Math.Round(255.0 * perGreen);

            var gString = green.ToString("X");
            var rString = red.ToString("X");

            if (gString.Length == 1)
            {
                gString = '0' + gString;
            }

            if (rString.Length == 1)
            {
                rString = "0" + rString;
            }

            color = "#" + rString + gString + "00";

            return (Color)ColorConverter.ConvertFromString(color);
        }
    }
}
