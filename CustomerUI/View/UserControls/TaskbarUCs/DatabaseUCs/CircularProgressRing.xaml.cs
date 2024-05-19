using Avalonia.Controls.Shapes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Color = System.Windows.Media.Color;
using ColorConverter = System.Windows.Media.ColorConverter;

namespace CustomerUI.View.UserControls.TaskbarUCs.DatabaseUCs
{
    public partial class CircularProgressRing : System.Windows.Controls.UserControl
    {
        public static readonly DependencyProperty PercentageProperty = DependencyProperty.Register(
            "Percentage", typeof(double), typeof(CircularProgressRing), new PropertyMetadata(0.0, OnPercentageChanged));

        public double Percentage
        {
            get { return (double)GetValue(PercentageProperty); }
            set { SetValue(PercentageProperty, value); }
        }

        public CircularProgressRing()
        {
            InitializeComponent();
        }

        private static void OnPercentageChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((CircularProgressRing)d).UpdateArc();
        }

        private void UpdateArc()
        {
            if (Percentage >= 100)
            {
                // Verberge den Fortschrittspfad und zeige die komplette Ellipse
                arc.Visibility = Visibility.Collapsed;
                fullCircle.Visibility = Visibility.Visible;
            }
            else
            {
                // Zeige den Fortschrittspfad und verberge die komplette Ellipse
                arc.Visibility = Visibility.Visible;
                fullCircle.Visibility = Visibility.Collapsed;

                double angle = Percentage / 100 * 360;
                double radians = (Math.PI / 180) * (angle - 90);
                double radius = 18; // Stellen Sie sicher, dass der Radius mit dem der Ellipse übereinstimmt
                double centerX = 20;
                double centerY = 20;
                double x = centerX + radius * Math.Cos(radians);
                double y = centerY + radius * Math.Sin(radians);

                string largeArc = angle > 180 ? "1" : "0";
                string pathData = String.Format(CultureInfo.InvariantCulture,
                    "M {0},{1} A {2},{2} 0 {3},1 {4},{5}",
                    centerX, centerY - radius,
                    radius,
                    largeArc,
                    Math.Round(x, 2),
                    Math.Round(y, 2));

                arc.Data = Geometry.Parse(pathData);
            }
        }
    }
}
