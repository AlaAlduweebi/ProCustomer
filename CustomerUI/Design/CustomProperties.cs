using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CustomerUI.Design
{
    public static class CustomProperties
    {
        public static readonly DependencyProperty ProfileIconDataProperty =
            DependencyProperty.RegisterAttached("M5 21C5 17.134 8.13401 14 12 14C15.866 14 19 17.134 19 21M16 7C16 9.20914 14.2091 11 12 11C9.79086 11 8 9.20914 8 7C8 4.79086 9.79086 3 12 3C14.2091 3 16 4.79086 16 7Z", 
                typeof(string), typeof(CustomProperties), new PropertyMetadata(null));

        public static string GetProfileIconData(DependencyObject obj)
        {
            return (string)obj.GetValue(ProfileIconDataProperty);
        }

        public static void SetProfileIconData(DependencyObject obj, string value)
        {
            obj.SetValue(ProfileIconDataProperty, value);
        }
    }
}
