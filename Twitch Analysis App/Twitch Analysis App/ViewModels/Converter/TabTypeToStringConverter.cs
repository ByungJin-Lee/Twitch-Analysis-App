using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using Twitch_Analysis_App.ViewModels.Types;

namespace Twitch_Analysis_App.ViewModels.Converter
{
    class TabTypeToStringConverter : IValueConverter
    {        
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {            
            switch ((TabType)value)
            {
                case TabType.Analysis:                    
                    return "Analysis";
                case TabType.Configuration:
                    return "Configuration";
                case TabType.DataBase:
                    return "DataBase";
                case TabType.Download:
                    return "Download";
            }
            return "Undefined";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
