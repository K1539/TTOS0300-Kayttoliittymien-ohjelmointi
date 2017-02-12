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

namespace Tehtava3
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

        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> data = new List<string>();
            data.Add("Lotto");
            data.Add("Viking Lotto");
            data.Add("EuroJackpot");

            comboBox.ItemsSource = data;

            comboBox.SelectedIndex = 0;

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;
        }

        private void btnDraw_Click(object sender, RoutedEventArgs e)
        {
            int x = 0;
            if (int.TryParse(txtDraws.Text, out x))
            {
                if (comboBox.SelectedIndex == 0)
                {
                    ArvoLotto(x);
                }
                else if (comboBox.SelectedIndex == 1)
                {
                    ArvoVikingLotto(x);
                }
                else if (comboBox.SelectedIndex == 2)
                {
                    ArvoEuroJackpot(x);
                }
            }
            else
            {
                MessageBox.Show("Invalid input. Please give a integer number");
            }

        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtNumbers.Text = "";
        }

        private void ArvoLotto(int x)
        {
            Random rand = new Random();
            List<int> apuLista = new List<int>();
            int riviNmr = 1;

            for (int i = 0; i < x; i++)
            {
                txtNumbers.Text += "Rivi " + riviNmr + ":";
                for (int y = 0; y < 7; y++)
                {
                    int numero = rand.Next(0, 40);
                    if (apuLista.Contains(numero))
                    {
                        y--;
                    }
                    else
                    {
                        apuLista.Add(numero);
                    }
                }
                apuLista.Sort();
                foreach (int num in apuLista)
                {
                    txtNumbers.Text += " " + num;
                }
                txtNumbers.Text += "\n";
                apuLista.Clear();
                riviNmr++;
            }
        }

        private void ArvoVikingLotto(int x)
        {
            Random rand = new Random();
            List<int> apuLista = new List<int>();
            int riviNmr = 1;

            for (int i = 0; i < x; i++)
            {
                txtNumbers.Text += "Rivi " + riviNmr + ":";
                for (int y = 0; y < 6; y++)
                {
                    int numero = rand.Next(0, 49);
                    if (apuLista.Contains(numero))
                    {
                        y--;
                    }
                    else
                    {
                        apuLista.Add(numero);
                    }
                }
                apuLista.Sort();
                foreach (int num in apuLista)
                {
                    txtNumbers.Text += " " + num;
                }
                txtNumbers.Text += "\n";
                apuLista.Clear();
                riviNmr++;
            }
        }

        private void ArvoEuroJackpot(int x)
        {
            Random rand = new Random();
            List<int> apuLista = new List<int>();
            int riviNmr = 1;

            for (int i = 0; i < x; i++)
            {
                txtNumbers.Text += "Rivi " + riviNmr + ":";
                for (int y = 0; y < 5; y++)
                {
                    int numero = rand.Next(0, 51);
                    if (apuLista.Contains(numero))
                    {
                        y--;
                    }
                    else
                    {
                        apuLista.Add(numero);
                    }
                }
                apuLista.Sort();
                foreach (int num in apuLista)
                {
                    txtNumbers.Text += " " + num;
                }

                int apuTahtiNumero = 0;
                for (int h = 0; h < 2; h++)
                {
                    int numero = rand.Next(0, 11);
                    if (apuTahtiNumero == numero)
                    {
                        h--;
                    }
                    else
                    {
                        apuTahtiNumero = numero;
                        txtNumbers.Text += " " + numero;
                    }
                }
                txtNumbers.Text += "\n";
                apuLista.Clear();
                riviNmr++;
            }
        }
    }
}