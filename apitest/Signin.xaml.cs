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

namespace winapp
{
    /// <summary>
    /// Interaction logic for Signin.xaml
    /// </summary>
    public partial class Signin : Page
    {

        private readonly MainWindow _mainWindow;

        public Signin(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            Loaded += Signin_Loaded;
        }
        public Signin()
        {
            InitializeComponent();
            Loaded += Signin_Loaded;
        }

        private void Signin_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = App.LoginViewModel;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            onLogin();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            Signup page = new Signup(_mainWindow);
            _mainWindow.NavigatePage(page);

        }

        private async void onLogin()
        {
            await App.LoginViewModel.Login(tbID.Text, tbPassword.Password);
        }
    }
}
