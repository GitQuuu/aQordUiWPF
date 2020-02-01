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
using System.Windows.Shapes;

namespace aQordUiWPF.View.CarpenterList
{
    /// <summary>
    /// Interaction logic for CarpenterList.xaml
    /// </summary>
    public partial class CarpenterList : Window
    {
        private readonly BricklayerMenu _bricklayerMenu;

        public CarpenterList()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            ReadAllFromList();
        }

        public CarpenterList(BricklayerMenu bricklayerMenu)
        {
            _bricklayerMenu = bricklayerMenu;
        }

        // Method to add all Craftsman object to the Xaml by using the x:Name reference from CarpenterList.Xaml
        private void ReadAllFromList()
        {
            foreach (Craftsman craftsman in BricklayerMenu.BricklayerList)
            {
                DataGridXAMLCarpenterList.Items.Add(craftsman);
            }
        }
        // Method to Delete from the _bricklayerList and from the Xaml view look line 23 in xaml
        private void DeleteSelected(object sender, RoutedEventArgs e)
        {
            foreach (Craftsman craftsman in BricklayerMenu.BricklayerList)
            {
                if (DataGridXAMLCarpenterList.SelectedItem == craftsman)
                {
                    DataGridXAMLCarpenterList.Items.Remove(craftsman);
                    BricklayerMenu.BricklayerList.Remove(craftsman);
                    return;
                }
            }
        }

        private void UpdateSelected(object sender, RoutedEventArgs e)
        {
            if (Update.IsChecked == true)
            {
                EditForm.Visibility = Visibility.Visible;
            }
        }
    }
}
    