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

namespace aQordUiWPF
{
    /// <summary>
    /// Interaction logic for BricklayerMenu.xaml
    /// </summary>
    public partial class BricklayerMenu : Page
    {
        public BricklayerMenu()
        {
            InitializeComponent();
        }


        private void ReturnToMainPage(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri(@"\View\MainPageMenu\MainPage.xaml", UriKind.Relative));
            
        }

        private void PickTiles(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri(@"\View\BricklayerTilesMenu\BricklayerTilesMenu.xaml", UriKind.Relative));
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

            Craftsman.bricklayerList.Add(bricklayer);

        }
    }
}
