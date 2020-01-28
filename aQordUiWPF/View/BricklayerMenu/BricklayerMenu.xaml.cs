using System;
using System.Collections.Generic;
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
using aQordUiWPF.View.CarpenterList;
using aQordUiWPF.ViewModels;

namespace aQordUiWPF
{
    /// <summary>
    /// Interaction logic for BricklayerMenu.xaml
    /// </summary>
    public partial class BricklayerMenu : Page
    {
        public static List<Craftsman> bricklayerList = new List<Craftsman>();
        public static List<Craftsman> carpenterList = new List<Craftsman>();

        public BricklayerMenu()
        {
            InitializeComponent();
            StackPanelForCRUD.DataContext = new ExpanderListViewModel();
        }


        private void ReturnToMainPage(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri(@"\View\MainPageMenu\MainPage.xaml", UriKind.Relative));
            
        }

        private void PickTiles(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri(@"\View\BricklayerTilesMenu\BricklayerTilesMenu.xaml", UriKind.Relative));
        }

        

        private void SavedClick(object sender, RoutedEventArgs e)
        {
            Craftsman bricklayer = new Craftsman()
            {
                Id = Convert.ToInt32(Id.Text),
                FirstName = Convert.ToString(FirstName.Text),
                LastName = Convert.ToString(LastName.Text),
                HourlyRate = Convert.ToDecimal(HourlyRate.Text),
                WorkingHourWeekly = Convert.ToDouble(WeeklyHours.Text),
            };

            bricklayerList.Add(bricklayer);

            MessageBox.Show("Gemt","Gemt",MessageBoxButton.OK,MessageBoxImage.Asterisk);
        }

        private void ResetClick(object sender, RoutedEventArgs e)
        {
            Id.Text = String.Empty;
            FirstName.Text = String.Empty;
            LastName.Text = String.Empty;
            HourlyRate.Text = String.Empty;
            WeeklyHours.Text = String.Empty;
            BoxItemBricklayer = null; // not working yet
            BoxItem2Apprentice = null; // not working yet
            BoxItem3Workingman = null; // not working yet

            MessageBox.Show("Reset", "Not added", MessageBoxButton.OK, MessageBoxImage.Information);
        }


        
        private void ShowAll(object sender, RoutedEventArgs e)
        {
           CarpenterList carpenterListWindow = new CarpenterList();
           carpenterListWindow.Show();
           
        }

        private void ShowSpecific(object sender,RoutedEventArgs e, int id)
        {

        }
    }
}
