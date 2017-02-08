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

        private void button_Click(object sender, RoutedEventArgs e)
        {
            double ikkunakorkeus = 0, ikkunaleveys = 0;
            double IkkunanPintaala;
            if (double.TryParse(IkkunanKorkeusinput.Text, out ikkunakorkeus) && double.TryParse(IkkunanLeveysInput.Text, out ikkunaleveys))
            {
                IkkunanPintaala = (ikkunakorkeus * ikkunaleveys) / 10;
                IkkunanPintaAlaOutput.Text = Convert.ToString(IkkunanPintaala);
            }
            double karminleveys = 0;
            double LasinPintaala;
            if (double.TryParse(IkkunanKorkeusinput.Text, out ikkunakorkeus) && double.TryParse(IkkunanLeveysInput.Text, out ikkunaleveys) && double.TryParse(KarmipuunLeveysInput.Text, out karminleveys))
            {
                LasinPintaala = (ikkunakorkeus - (2 * karminleveys))*(ikkunaleveys - (2 * karminleveys))/10;
                LasinPintaAlaOutput.Text = Convert.ToString(LasinPintaala);
            }
            double KarminPiiri;
            if (double.TryParse(IkkunanKorkeusinput.Text, out ikkunakorkeus) && double.TryParse(IkkunanLeveysInput.Text, out ikkunaleveys) && double.TryParse(KarmipuunLeveysInput.Text, out karminleveys))
            {
                KarminPiiri = (ikkunakorkeus * 2 + ikkunaleveys * 2) / 10;
                KarminPiiriOutput.Text = Convert.ToString(KarminPiiri);
                
            }
            Laatikko.Height = ikkunakorkeus / 10;
            Laatikko.Width = ikkunaleveys / 10;
        }
    }
}
