using System;
using System.Collections.Generic;
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

namespace Tehtava2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Euroiksi_Click(object sender, RoutedEventArgs e)
        {
            double x = 0;
            double Sum = 0;

            if (double.TryParse(textBox.Text, out x))
            {
                Sum = x / 5.94573;
                string value = Sum.ToString("0.00");
                textBox.Text = value;
            }
        }

        private void Markoiksi_Click(object sender, RoutedEventArgs e)
        {
            double x = 0;
            double Sum = 0;

            if (double.TryParse(textBox.Text, out x))
            {
                Sum = x * 5.94573;
                string value = Sum.ToString("0.00");
                textBox.Text = value;
            }
        }
    }
}
