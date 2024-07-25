using EnergyReport.DbConnector.Model;
using EnergyReport.WPF.UserControls;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EnergyReport.WPF
{
    
    public partial class MainWindow : Window

    {

       
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_Show_RealEstate(object sender, RoutedEventArgs e)
        {
            RootControl.Children.Clear();
            var iprest = new InputRealestate();
            RootControl.Children.Add(iprest);
        }
        private void Button_Click_Show_Contract(object sender, RoutedEventArgs e)
        {
           RootControl.Children.Clear();
            var contract = new InputContract();
            RootControl.Children.Add(contract);  
        }
        private void Button_Click_Show_Reading(object sender, RoutedEventArgs e)
        {
            RootControl.Children.Clear();
            var reading = new InputReading();
            RootControl.Children.Add(reading);
        }
        private void Button_Click_Show_LiveCharts(object sender, RoutedEventArgs e)
        {
            RootControl.Children.Clear();
            var livecharts = new Livecharts();
            RootControl.Children.Add(livecharts);
        }
        private void Button_Click_Show_Tariff(object sender, RoutedEventArgs e)
        {
            RootControl.Children.Clear();
            var tariff = new InputTariff();
            RootControl.Children.Add(tariff);
        }
    }
}