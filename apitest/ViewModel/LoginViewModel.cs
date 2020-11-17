using apitest.manager;
using apitest.Model;
using Newtonsoft.Json.Linq;
using Prism.Mvvm;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace apitest.ViewModel
{
    public class LoginViewModel : BindableBase
    {
        RestManager restmanager = new RestManager();

        private string _token;
        public string Token
        {
            get => _token;
            set => SetProperty(ref _token, value);
        }
        public string Result;

        public async Task Login(string Id, string Password)
        {
            JObject jobj = new JObject();
            jobj.Add("userId", Id);
            jobj.Add("password", Password);
            var loginResult = await restmanager.RestRequest<LoginModel>(jobj.ToString(), null, Method.POST, "/signIn");
            Token = loginResult.token;
            if(loginResult.result == "1")
            {
                MessageBox.Show("로그인을 성공했습니다.", "SUCCESS");
            }
            else
            {
                MessageBox.Show("아이디 혹은 비밀번호가 틀렸습니다.", "ERROR");
            }
        }
    }
}
