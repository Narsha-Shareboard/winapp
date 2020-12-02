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
            if (Settings.Default.isALChecked == true)
            {
                autoLogin();
                if (AutoLoginCheck.isValidAccess == true)
                {
                    _mainWindow.NavigatePage(new Pull(_mainWindow));
                }
            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (tbID.Text == "")
            {
                MessageBox.Show("아이디를 입력해주세요.", "ERROR");
            }
            else if (tbPassword.Password == "")
            {
                MessageBox.Show("비밀번호를 입력해주세요.", "ERROR");
            }
            else
            {
                onLogin();
            }
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            Signup page = new Signup(_mainWindow);
            _mainWindow.NavigatePage(page);
        }

        private async void onLogin()
        {
            await App.LoginViewModel.Login(tbID.Text, tbPassword.Password);
            if (LoginCheck.isValidAccess == true)
            {
                _mainWindow.NavigatePage(new Pull(_mainWindow));
            }
        }
        
        private async void autoLogin()
        {
            await App.AutoLoginViewModel.AutoLogin();
        }

        private void btnFindPW_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("관리자에게 문의하세요.", "ERROR");
        }

        private void chkAutoLogin_Checked(object sender, RoutedEventArgs e)
        {
            Settings.Default.isALChecked = true;
        }
        private void chkAutoLogin_Unchecked(object sender, RoutedEventArgs e)
        {
            Settings.Default.isALChecked = false;
        }
    }
    public class PasswordBoxMonitor : DependencyObject
    {
        public static bool GetIsMonitoring(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsMonitoringProperty);
        }

        public static void SetIsMonitoring(DependencyObject obj, bool value)
        {
            obj.SetValue(IsMonitoringProperty, value);
        }

        public static readonly DependencyProperty IsMonitoringProperty =
            DependencyProperty.RegisterAttached("IsMonitoring", typeof(bool), typeof(PasswordBoxMonitor), new UIPropertyMetadata(false, OnIsMonitoringChanged));

        public static int GetPasswordLength(DependencyObject obj)
        {
            return (int)obj.GetValue(PasswordLengthProperty);
        }

        public static void SetPasswordLength(DependencyObject obj, int value)
        {
            obj.SetValue(PasswordLengthProperty, value);
        }

        public static readonly DependencyProperty PasswordLengthProperty =
            DependencyProperty.RegisterAttached("PasswordLength", typeof(int), typeof(PasswordBoxMonitor), new UIPropertyMetadata(0));

        private static void OnIsMonitoringChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var pb = d as PasswordBox;
            if (pb == null)
            {
                return;
            }
            if ((bool)e.NewValue)
            {
                pb.PasswordChanged += PasswordChanged;
            }
            else
            {
                pb.PasswordChanged -= PasswordChanged;
            }
        }

        static void PasswordChanged(object sender, RoutedEventArgs e)
        {
            var pb = sender as PasswordBox;
            if (pb == null)
            {
                return;
            }
            SetPasswordLength(pb, pb.Password.Length);
        }
    }
}
