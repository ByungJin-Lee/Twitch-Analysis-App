using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Twitch_Analysis_App.ViewModels.Converter
{
    /// <summary>
    /// This Converter for On/Off value To Color
    /// </summary>
    class BooleanToColorBrushConverter : IValueConverter
    {
        public Brush TrueBrush { get; set; }
        public Brush FalseBrush { get; set; }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? TrueBrush : FalseBrush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
