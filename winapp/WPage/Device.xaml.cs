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
    /// Interaction logic for Device.xaml
    /// </summary>
    public partial class Device : Page
    {
        private readonly MainWindow _mainWindow;

        public Device(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            Loaded += Device_Loaded;
        }
        public Device()
        {
            InitializeComponent();
            Loaded += Device_Loaded;
        }

        private void Device_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = App.DeviceViewModel;
        }
    }
}
