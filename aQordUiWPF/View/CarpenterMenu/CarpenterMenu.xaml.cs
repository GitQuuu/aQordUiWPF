﻿using System;
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
    /// Interaction logic for CarpenterMenu.xaml
    /// </summary>
    public partial class CarpenterMenu : Page
    {
        public CarpenterMenu()
        {
            InitializeComponent();
        }

        private void ReturnToMain(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri(@"\View\MainPageMenu\MainPage.xaml", UriKind.Relative));
        }
    }
}
