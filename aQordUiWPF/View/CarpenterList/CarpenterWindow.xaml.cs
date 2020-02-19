using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
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
using aQord.Models;
using System.Text.Json;
using System.Threading;
using System.Windows.Forms;
using aQord.Controller;
using Newtonsoft.Json;
using WPFCustomMessageBox;
using MessageBox = System.Windows.MessageBox;

namespace aQordUiWPF.View.CarpenterList
{

    /// <summary>
    /// Interaction logic for CarpenterList.xaml
    /// </summary>
    public partial class CarpenterWindow : Window
    {
        private readonly CraftsmensController _craftsmensController;


        private ObservableCollection<Craftsman> _craftMen = new ObservableCollection<Craftsman>();
        static BackgroundWorker worker = new BackgroundWorker();
        public ObservableCollection<Craftsman> CraftMen // This is being used in CarpenterList.xaml its not being highligted because xaml is not c#
        {
            get
            {
                return _craftMen;
            }
        }

        public CarpenterWindow()
        {
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            // Databinding either here first to enable ItemSource in xaml or DataContext on line 8 in xaml
            this.DataContext = this;

            //Referencing _craftMen and BricklayerMenu.BricklayerList
            _craftMen = BricklayerMenu.BricklayerList;
            _craftsmensController = new CraftsmensController(new Craftsman());

            InitializeComponent();
            AutoUpdate();
        }

        // Doing some backgroundworker 
        // AutoUpdate method being called from mainwindow
        public static void AutoUpdate()
        {
            
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            worker.RunWorkerAsync(2000);
        }

        private static void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            // run all background tasks here
            int sleeptime = (int)e.Argument;
            
                while (true)
                {
                    ObservableCollection<Craftsman> listToCompare = JsonConvert.DeserializeObject<ObservableCollection<Craftsman>>(File.ReadAllText("C:\\Users\\Quanv\\source\\repos\\aQord\\aQord\\Files\\JsonOutput\\Wednesday, February 19, 2020.json"));

                    //Dispatcher is needed for to be able to change in sourceCollection
                    App.Current.Dispatcher.Invoke((Action)delegate
                    {
                        BricklayerMenu.BricklayerList.Clear();
                        foreach (var objetcs in listToCompare)
                        {
                            BricklayerMenu.BricklayerList.Add(objetcs);

                        }

                    });


                    Thread.Sleep(sleeptime);
                }


        }

        private static void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //update ui once worker complete his work
            Console.Write("Thread stopped");
        }


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

        }


        private void EditClose(object sender, RoutedEventArgs e)
        {
            EditForm.Visibility = Visibility.Hidden;
        }

        private void DataGridXAMLCarpenterList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ExportButton(object sender, RoutedEventArgs e)
        {

            switch (CustomMessageBox.ShowYesNoCancel("Export", "Export", "Eksportere til Json", "Eksportere til excel", "Fortryd"))
            {
                case MessageBoxResult.Yes:
                    _craftsmensController.ExportToJson(_craftMen);
                    MessageBox.Show("Exported to Json");
                    break;
                case MessageBoxResult.No:
                    _craftsmensController.ExportToExel(_craftMen);
                    MessageBox.Show("Exported to excel");
                    break;
                case MessageBoxResult.Cancel:
                    break;

            }


        }
    }

}