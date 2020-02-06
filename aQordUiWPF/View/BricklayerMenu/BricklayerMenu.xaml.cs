using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using aQord.Models;
using aQordUiWPF.View.CarpenterList;
using aQordUiWPF.ViewModels;

namespace aQordUiWPF
{
    /// <summary>
    /// Interaction logic for BricklayerMenu.xaml
    /// </summary>
    public partial class BricklayerMenu : Page
    {
        public static ObservableCollection<Craftsman> BricklayerList = new ObservableCollection<Craftsman>();
        public static List<Craftsman> carpenterList = new List<Craftsman>();

        

        public BricklayerMenu()
        {
            InitializeComponent();
            // for the Expander
            StackPanelForCRUD.DataContext = new ExpanderListViewModel();

            // this is to populate our list for testing
            BricklayerList.Add(new Craftsman { Id = 1, FirstName = "Qu", LastName = "Le", Profession = "Murersvend",HourlyRate = 200, WorkingHourWeekly = 18 });
            BricklayerList.Add(new Craftsman { Id = 2, FirstName = "Nicoline", LastName = "Le", Profession = "Lærling", HourlyRate = 250, WorkingHourWeekly = 32 });

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
                FirstName = FirstName.Text,
                LastName = LastName.Text,
                Profession = ProfessionComboBox.Text,
                HourlyRate = Convert.ToDecimal(HourlyRate.Text),
                WorkingHourWeekly = Convert.ToDouble(WeeklyHours.Text),

            };
                BricklayerList.Add(bricklayer);
            
                MessageBox.Show("Gemt", "Gemt", MessageBoxButton.OK, MessageBoxImage.Asterisk);
        }

        private void ResetClick(object sender, RoutedEventArgs e)
        {
            Id.Text = String.Empty;
            FirstName.Text = String.Empty;
            LastName.Text = String.Empty;
            HourlyRate.Text = String.Empty;
            WeeklyHours.Text = String.Empty;
            ProfessionComboBox.Text = String.Empty;

            MessageBox.Show("Reset", "Not added", MessageBoxButton.OK, MessageBoxImage.Information);
        }


        
        private void ShowAllClicked(object sender, RoutedEventArgs e)
        {
           CarpenterList carpenterListWindow = new CarpenterList();
           
           carpenterListWindow.Show();
           
        }

    }
}
