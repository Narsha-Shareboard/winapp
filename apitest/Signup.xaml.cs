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

namespace winapp
{
    /// <summary>
    /// Signup.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Signup : Page
    {
        private readonly MainWindow _mainWindow;
        public Signup(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            Loaded += Signup_Loaded;
        }

        public Signup()
        {
            InitializeComponent();
            Loaded += Signup_Loaded;
        }

        private void Signup_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = App.RegisterViewModel;
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            if(tbPassword.Password == tbCheck.Password)
            {
                onRegister();
            }
            else
            {
                MessageBox.Show("비밀번호가 일치하지 않습니다.", "ERROR");
            }
        }

        private async void onRegister()
        {
            await App.RegisterViewModel.Register(tbID.Text, tbPassword.Password);
            _mainWindow.NavigatePage(new Signin(_mainWindow));
        }

        private void btnBack(object sender, RoutedEventArgs e)
        {
            _mainWindow.NavigatePage(new Signin(_mainWindow));
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
}
