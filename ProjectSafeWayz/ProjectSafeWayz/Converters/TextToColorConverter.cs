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
            var convertValue = (IncidentNames)value;

            switch (convertValue)
            {
                case IncidentNames.Murder:

                    return Color.Red;

                case IncidentNames.Accident:

                    return Color.Purple;

                case IncidentNames.Shooting:

                    return Color.Green;

                case IncidentNames.Robbery:

                    return Color.Orange;

                case IncidentNames.Assault:

                    return Color.Blue;
            }

            return Color.Aquamarine;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}