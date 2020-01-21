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
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void PickBricklayer(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri(@"\View\BricklayerMenu\BricklayerMenu.xaml", UriKind.Relative));
        }

        private void PickCarpenter(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri(@"\View\CarpenterMenu\CarpenterMenu.xaml", UriKind.Relative));
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {

            Application.Current.Shutdown();
        }

        private void PickConstructionPainter(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri(@"\View\ConstructionPainterMenu\ConstructionPainterMenu.xaml", UriKind.Relative));
        }
    }
}
