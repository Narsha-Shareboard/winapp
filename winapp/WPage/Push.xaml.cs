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
    /// Interaction logic for Push.xaml
    /// </summary>
    public partial class Push : Page
    {
        private readonly MainWindow _mainWindow;

        public Push(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            Loaded += Push_Loaded;
        }
        public Push()
        {
            InitializeComponent();
            Loaded += Push_Loaded;
        }

        private void Push_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = App.PushViewModel;
        }

        private void btnPush_MouseDoubleClick(object Sender, RoutedEventArgs e)
        {

        }
        private void btnPull_MouseDoubleClick(object Sender, RoutedEventArgs e)
        {

        }

        private void btnDevice_MouseDoubleClick(object Sender, RoutedEventArgs e)
        {

        }
    }
}
