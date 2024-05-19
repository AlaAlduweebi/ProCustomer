using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace CustomerUI.Design
{
    public class BooleanToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool && (bool)value)
                return new SolidColorBrush(System.Windows.Media.Color.FromRgb(19, 123, 193)); // Set your desired color
            else
                return System.Windows.Media.Brushes.Transparent; // Or any other default color
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
