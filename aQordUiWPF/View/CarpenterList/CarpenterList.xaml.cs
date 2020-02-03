using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
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
        private ObservableCollection<Craftsman> _craftMen = new ObservableCollection<Craftsman>();
        public ObservableCollection<Craftsman> CraftMen
        {
            get
            {
                return _craftMen;
            }
        }
        public CarpenterList()
        {
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            // Databinding either here first to enable ItemSource in xaml or DataContext on line 8 in xaml
            this.DataContext = this;

            //Referencing _craftMen and BricklayerMenu.BricklayerList
            _craftMen = BricklayerMenu.BricklayerList;

            InitializeComponent();
        }


        public CarpenterList(BricklayerMenu bricklayerMenu)
        {
            _bricklayerMenu = bricklayerMenu;
        }

        // Method to Delete from the _bricklayerList and from the Xaml view look line 23 in xaml
        private void DeleteSelected(object sender, RoutedEventArgs e)
        {
            if (DataGridXAMLCarpenterList.SelectedCells != null && DataGridXAMLCarpenterList.SelectedCells.Count > 0)
            {
                foreach (Craftsman craftsman in BricklayerMenu.BricklayerList)
                {
                    if (DataGridXAMLCarpenterList.SelectedItem == craftsman)
                    {
                        _craftMen.Remove((Craftsman)DataGridXAMLCarpenterList.SelectedItem);
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show("Hvem vil du slette? vælg en fra listen oven over", "Fejl", MessageBoxButton.OK,
                    MessageBoxImage.Hand);
            }

        }

        private void UpdateSelected(object sender, RoutedEventArgs e)
        {
            if (DataGridXAMLCarpenterList.SelectedCells != null && DataGridXAMLCarpenterList.SelectedCells.Count > 0)
            {
                EditForm.Visibility = Visibility.Visible;
                //EditID.Text = (string)DataGridXAMLCarpenterList.CurrentCell.Item;
            }
            else
            {
                MessageBox.Show("Hvem vil du redigere? vælg en fra listen oven over", "Fejl", MessageBoxButton.OK,
                    MessageBoxImage.Hand);
            }
        }

        private void EditSave(object sender, RoutedEventArgs e)
        {
            // DataGridXAMLCarpenterList.Items

            //foreach (Craftsman craftsman in BricklayerMenu.BricklayerList)
            //{

            Craftsman craftmen = _craftMen.FirstOrDefault(c => c.Id == int.Parse(EditID.Text));
            if (craftmen != null)
            {
                craftmen.Id = Convert.ToInt32(EditID.Text);
                craftmen.FirstName = EditFirstName.Text;
                craftmen.LastName = EditLastName.Text;
                craftmen.Profession = EditProfession.Text;
                craftmen.HourlyRate = Convert.ToDecimal(EditHourlyRate.Text);
                craftmen.WorkingHourWeekly = Convert.ToInt32(EditWeeklyHours.Text);
            }
            else
            {
                MessageBox.Show("ID skal være identisk med eksisterende for at redigere", "Fejl", MessageBoxButton.OK, MessageBoxImage.Hand);
            }


            // find out why elseBlock is callling even thou if block is running

            //}


        }


        private void EditClose(object sender, RoutedEventArgs e)
        {
            EditForm.Visibility = Visibility.Hidden;
        }
    }

}