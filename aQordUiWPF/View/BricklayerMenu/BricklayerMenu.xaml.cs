using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Text.Json.Serialization;
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
using Microsoft.Xrm.Sdk.Messages;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using JsonConverter = Newtonsoft.Json.JsonConverter;

namespace aQordUiWPF
{
    /// <summary>
    /// Interaction logic for BricklayerMenu.xaml
    /// </summary>
    public partial class BricklayerMenu : Page
    {
        public static ObservableCollection<Craftsman> BricklayerList = new ObservableCollection<Craftsman>();




        public BricklayerMenu()
        {
            InitializeComponent();
            // for the Expander
            StackPanelForCRUD.DataContext = new ExpanderListViewModel();

            // this is to populate our list for testing
            //BricklayerList.Add(new Craftsman(1, "Murer", "Emil", "Fredriksen", 200, 37, "Emil@test.dk", 12345678));
            //BricklayerList.Add(new Craftsman(2, "Lærling", "Qu", "Le", 200, 37, "Qu@test.dk", 60177516));
            //BricklayerList.Add(new Craftsman(3, "Murer", "Nicoline", "Le", 200, 32, "Nicoline@test.dk", 87654321));

            LoadJsonToCollection();
        }





        public void LoadJsonToCollection()
        {
            List<Craftsman> deserializeObject = JsonConvert.DeserializeObject<List<Craftsman>>(
                File.ReadAllText(
                    "C:\\Users\\Quanv\\source\\repos\\aQord\\aQord\\Files\\JsonOutput\\Wednesday, February 19, 2020.json"));

            foreach (var objetcs in deserializeObject)
            {
                BricklayerList.Add(objetcs);
            }

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
                Email = Email.Text,
                Cellphone = Convert.ToInt32(Cellphone.Text)

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
            CarpenterWindow carpenterWindow = new CarpenterWindow();


            carpenterWindow.Show();

        }

    }
}
