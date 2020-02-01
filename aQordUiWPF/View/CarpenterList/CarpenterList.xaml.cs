using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            if (DataGridXAMLCarpenterList.SelectedCells != null && DataGridXAMLCarpenterList.SelectedCells.Count > 0)
            {
                foreach (Craftsman craftsman in BricklayerMenu.BricklayerList)
                {
                    if (DataGridXAMLCarpenterList.SelectedItem == craftsman)
                    {
                        DataGridXAMLCarpenterList.Items.Remove(craftsman);
                        BricklayerMenu.BricklayerList.Remove(craftsman);
                        DataGridXAMLCarpenterList.Items.Refresh();
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
            foreach (Craftsman craftsman in BricklayerMenu.BricklayerList)
            {
                if (EditID.Text.Equals(craftsman.Id.ToString()))
                {
                    craftsman.Id = Convert.ToInt32(EditID.Text);
                    craftsman.FirstName = EditFirstName.Text;
                    craftsman.LastName = EditLastName.Text;
                    craftsman.Profession = EditProfession.Text;
                    craftsman.HourlyRate = Convert.ToDecimal(EditHourlyRate.Text);
                    craftsman.WorkingHourWeekly = Convert.ToInt32(EditWeeklyHours.Text);

                    DataGridXAMLCarpenterList.Items.Refresh();
                    
                }
                else
                {
                    MessageBox.Show("Fejl", "ID skal være identisk med eksisterende for at redigere", MessageBoxButton.OK, MessageBoxImage.Hand);
                }

                
                // find out why elseBlock is callling even thou if block is running
               
            }
           

        }


        private void EditClose(object sender, RoutedEventArgs e)
        {
            EditForm.Visibility = Visibility.Hidden;
        }
    }

}  