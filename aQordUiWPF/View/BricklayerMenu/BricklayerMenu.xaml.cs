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
        private readonly Craftsman _craftsman;

        public BricklayerMenu(Craftsman craftsman)
        {
            _craftsman = craftsman;
        }
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
            

        }
    }
}
