using ProjectSafeWayz.Enums;
using ProjectSafeWayz.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace ProjectSafeWayz.Converters
{
    public class TextToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string text = value as string;
            if (text.Contains("Murder"))
            {
                return Color.Red;
            }
            else if (text.Contains("Assault"))
            {
                return Color.Blue;
            }
            else if (text.Contains("Shooting"))
            {
                return Color.Green;
            }
            else if (text.Contains("Robbery"))
            {
                return Color.Orange;
            }
            else if (text.Contains("Accident"))
            {
                return Color.Purple;
            }

            return Color.Black;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}