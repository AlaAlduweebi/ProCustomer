using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace CustomerUI.Design
{
    public class BoolToVisibilityInverseConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var itemsControl = value as ItemsControl;
            if (itemsControl == null || parameter == null)
                return Visibility.Collapsed;

            var item = parameter;
            var container = itemsControl.ItemContainerGenerator.ContainerFromItem(item);
            var index = itemsControl.ItemContainerGenerator.IndexFromContainer(container);
            var count = itemsControl.Items.Count;

            // Sichtbar machen, wenn es nicht das letzte Item ist
            return index < count - 1 ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }

}
