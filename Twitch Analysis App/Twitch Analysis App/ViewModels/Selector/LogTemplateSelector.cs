using System;
using System.Windows;
using System.Windows.Controls;
using Twitch_Analysis_App.Structure;

namespace Twitch_Analysis_App.Selector
{
    class LogTemplateSelector : DataTemplateSelector
    {
        public DataTemplate LeftTemplate { get; set; }
        public DataTemplate RightTemplate { get; set; }
        public String PropertyToCheck { get; set; }
        public String PropertyValue { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var target = (Log)item;
            var type = target.GetType();
            var property = type.GetProperty(PropertyToCheck);

            if(property.GetValue(target,null).ToString() == PropertyValue)
            {
                return RightTemplate;
            }
            else
            {
                return LeftTemplate;
            }
        }
    }
}
