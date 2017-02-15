using System;
using System.Collections.Generic;
using System.Collections.ObjectModel; //observable collection
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
using JAMK.ICT;

namespace Tunnilla2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int x = 5;
        //Koska 
        HockeyLeague liiga;
        HockeyTeam tiimi;
        ObservableCollection<JAMK.ICT.HockeyTeam> joukkueet;
        int counter = 0;
        public MainWindow()
        {

            InitializeComponent();
            IniMyStyff();
        }
        private void IniMyStyff()
        {
            //Tänne kootusti omien kontrollien asetukset
            List<string> muuvit = new List<String>();
            muuvit.Add("Halloween");
            muuvit.Add("Jaws");
            muuvit.Add("Star Wars");
            muuvit.Add("Pahat pojat");
            cmbMovies.ItemsSource = muuvit;

            //Haetaan SM-Liigajoukkueet
            liiga = new JAMK.ICT.HockeyLeague();
            liiga.GetTeams();

            joukkueet = liiga.GetTeams();
            cmbTeams.ItemsSource = joukkueet;
        }

        private void btnBind_Click(object sender, RoutedEventArgs e)
        {
            //Määritellään Stackpanelin DataContext
            //Demo1: Datacontekstina on olio
            //tiimi = new HockeyTeam("KeuPa", "Keuruu");
            //spRight.DataContext = tiimi;
            //demo2: kytketään olio-kokoelman 1. olioon
            spRight.DataContext = joukkueet[counter];
        }

        private void btnForward_Click(object sender, RoutedEventArgs e)
        {
            if (counter < x)
            {
                counter++;
                spRight.DataContext = joukkueet[counter];
            }
            else if (counter >= x)
            {
                counter = 0;
                spRight.DataContext = joukkueet[counter];
            }


        }

        private void btnBackWard_Click(object sender, RoutedEventArgs e)
        {
            if (counter > 0)
            {
                counter = counter - 1;
                spRight.DataContext = joukkueet[counter];
            }
            else if (counter == 0)
            {
                counter = x;
                spRight.DataContext = joukkueet[counter];
            }

        }
       
        public void AssignTeam_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
