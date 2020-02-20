using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

namespace aQordUiWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            _NavigationFrame.Navigate(new MainPage());
            // this is to populate our list for testing
            BricklayerMenu.BricklayerList.Add(new Craftsman(1, "Murer", "Emil", "Fredriksen", 200, 37, "Emil@test.dk", 12345678));
            BricklayerMenu.BricklayerList.Add(new Craftsman(2, "Lærling", "Qu", "Le", 200, 37, "Qu@test.dk", 60177516));
            BricklayerMenu.BricklayerList.Add(new Craftsman(3, "Murer", "Nicoline", "Le", 200, 32, "Nicoline@test.dk", 87654321));


        }

    }
}
