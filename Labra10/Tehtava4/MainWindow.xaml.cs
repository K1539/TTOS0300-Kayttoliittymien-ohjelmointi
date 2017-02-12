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

namespace Tehtava4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Kiuas kiuas = new Kiuas();
        RoutedEventArgs test = new RoutedEventArgs(); // testing for Key down events



        public MainWindow()
        {
            try
            {
                InitializeComponent();
                btnTemp.ToolTip = "Max temperature for this is: " + kiuas.maxTemperature.ToString();
                btnHumi.ToolTip = "Max humidity for this is: " + kiuas.maxHumidity.ToString();
                txtInput.MaxLength = 5;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }


        public static double GetDouble(string value, double defaultValue)
        {
            double result;
            // Try parsing in the current culture
            if (!double.TryParse(value, System.Globalization.NumberStyles.Any, CultureInfo.CurrentCulture, out result) &&
                // Then try in US english
                !double.TryParse(value, System.Globalization.NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out result) &&
                // Then in neutral language
                !double.TryParse(value, System.Globalization.NumberStyles.Any, CultureInfo.InvariantCulture, out result))
            {
                result = defaultValue;
            }
            return result;
        }


        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            test = e; // testing for Key down events
            if (rdbHumi.IsChecked == true) { txtHumi.Text = kiuas.ChangeHumidity(txtInput.Text.ToString()) + " %"; }
            else if (rdbTemp.IsChecked == true) { txtTemp.Text = kiuas.ChangeTemperature(txtInput.Text.ToString()) + "°C"; }
            else { MessageBox.Show("Choose temp or humi"); }
            txtInput.Text = "";
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            if (txtInput.Text.Length < 5)
            {
                var con = ((Button)sender).Content;
                txtInput.Text += con.ToString();
            }
        }

        private void btnCan(object sender, RoutedEventArgs e)
        {
            if (txtInput.Text.Length > 0) { txtInput.Text = txtInput.Text.Substring(0, txtInput.Text.Length - 1); }

        }

        private void btnHumi_Click(object sender, RoutedEventArgs e)
        {
            rdbHumi.IsChecked = true;
            txtInput.Focusable = true;
            txtInput.Focus();
        }

        private void btnTemp_Click(object sender, RoutedEventArgs e)
        {
            rdbTemp.IsChecked = true;
            txtInput.Focusable = true;
            txtInput.Focus();
        }

        private void txtInput_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Enter)
            {
                btnOk_Click(btnOk, test);
            }
            else if (e.Key == Key.Back)
            {
                btnCan(btnCancel, e);

            }
            else if (e.Key == Key.H)
            {
                rdbHumi.IsChecked = true;
            }
            else if (e.Key == Key.T)
            {
                rdbTemp.IsChecked = true;
            }



        }
    }
}

