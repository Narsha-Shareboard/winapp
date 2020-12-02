using winapp.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows;

namespace winapp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static LoginViewModel LoginViewModel = new LoginViewModel();
        public static RegisterViewModel RegisterViewModel = new RegisterViewModel();
        public static PullViewModel PullViewModel = new PullViewModel();
        public static AutoLoginViewModel AutoLoginViewModel = new AutoLoginViewModel();
    }
}
