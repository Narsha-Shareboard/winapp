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
using System.Windows.Navigation;

namespace winapp.ViewModel
{
    public class RegisterViewModel : BindableBase
    {
        RestManager restmanager = new RestManager();

        public string Result;

        public async Task Register(string Id, string Password)
        {
            JObject jobj = new JObject();
            jobj.Add("userId", Id);
            jobj.Add("password", Password);
            var RegisterResult = await restmanager.RestRequest<RegisterModel>(jobj.ToString(), null, Method.POST, "/signUp");
            Result = RegisterResult.result;
            if (RegisterResult.result == "1")
            {
                MessageBox.Show("회원가입을 성공했습니다.", "SUCCESS");
                RegisterCheck.isValidAccess = true;
            }

            else
            {
                MessageBox.Show("이미 존재하는 아이디입니다.", "ERROR");
            }
        }
    }
}
