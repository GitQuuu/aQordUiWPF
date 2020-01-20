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
    /// Interaction logic for BricklayerTilesMenu.xaml
    /// </summary>
    public partial class BricklayerTilesMenu : Page
    {
        public BricklayerTilesMenu()
        {
            InitializeComponent();
        }

        private void Return(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
