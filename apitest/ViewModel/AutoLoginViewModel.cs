using winapp.manager;
using winapp.Model;
using winapp.WPage;
using Newtonsoft.Json.Linq;
using Prism.Mvvm;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using winapp.Properties;

namespace winapp.ViewModel
{
    public class AutoLoginViewModel : BindableBase
    {
        RestManager restmanager = new RestManager();

        public string Result;

        public async Task AutoLogin()
        {
            JObject jobj = new JObject();
            var loginResult = await restmanager.RestRequest<AutoLoginModel>(jobj.ToString(), null, Method.POST, "/autologin");
            if (loginResult.result == "1")
            {
                IdModel.Get().userId = loginResult.userId;
                AutoLoginCheck.isValidAccess = true;
            }
            else
            {
                MessageBox.Show("로그인 만료", "ERROR");
                Settings.Default.isALChecked = false;
                Settings.Default.Save();
            }
        }
    }
}