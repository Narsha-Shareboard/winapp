using winapp.manager;
using winapp.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
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
using winapp.Properties;

namespace winapp.WPage
{
    /// <summary>
    /// Interaction logic for Pull.xaml
    /// </summary>
    public partial class Pull : Page
    {
        private readonly MainWindow _mainWindow;

        public Pull(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            Loaded += Signin_Loaded;
        }
        public Pull()
        {
            InitializeComponent();
            Loaded += Signin_Loaded;
        }

        private void Signin_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = App.PullViewModel;
        }

        /*
        private void btnPush_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.NavigatePage(new Device(_mainWindow));
        }

        private void btnDevice_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.NavigatePage(new Device(_mainWindow));
        }
        */

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            Settings.Default.isALChecked = false;
            Settings.Default.Save();
            _mainWindow.NavigatePage(new Signin(_mainWindow));
            MessageBox.Show("로그아웃되었습니다.", "Logout");
        }

        private void btnPull_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void btnPush_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            _mainWindow.NavigatePage(new Device(_mainWindow));
        }

        private void btnDevice_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            _mainWindow.NavigatePage(new Device(_mainWindow));
        }
    }
}
