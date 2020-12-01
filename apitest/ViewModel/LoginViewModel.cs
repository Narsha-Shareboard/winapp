using winapp.manager;
using winapp.Model;
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
    public class LoginViewModel : BindableBase
    {
        RestManager restmanager = new RestManager();

        public string Result;

        public async Task Login(string Id, string Password)
        {
            JObject jobj = new JObject();
            jobj.Add("userId", Id);
            jobj.Add("password", Password);
            var loginResult = await restmanager.RestRequest<LoginModel>(jobj.ToString(), null, Method.POST, "/signIn");
            TokenModel.Get().token = loginResult.token;
            if(loginResult.result == "1")
            {
                MessageBox.Show("로그인을 성공했습니다.", "SUCCESS");
                if (Settings.Default.isALChecked == true)
                {
                    Settings.Default.token = TokenModel.Get().token;
                    Settings.Default.Save();
                }
            }
            else
            {
                MessageBox.Show("아이디 혹은 비밀번호가 틀렸습니다.", "ERROR");
            }
        }
    }
}
