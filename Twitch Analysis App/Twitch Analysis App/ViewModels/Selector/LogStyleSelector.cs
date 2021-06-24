using System;
using System.Windows;
using System.Windows.Controls;
using Twitch_Analysis_App.Structure;

namespace Twitch_Analysis_App.Selector
{
    class LogStyleSelector : StyleSelector
    {
        public Style LeftStyle { get; set; }
        public Style RightStyle { get; set; }
        public String PropertyToCheck { get; set; }
        public String PropertyValue { get; set; }

        public override Style SelectStyle(object item, DependencyObject container)
        {
            var target = (Log)item;
            var type = target.GetType();
            var property = type.GetProperty(PropertyToCheck);

            if(property.GetValue(target).ToString() == PropertyValue)
            {
                return RightStyle;
            }
            else
            {
                return LeftStyle;
            }
        }
    }
}
