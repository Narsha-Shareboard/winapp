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

namespace winapp.ViewModel
{
    public class PushViewModel : BindableBase
    {
        RestManager restmanager = new RestManager();

        public async Task Push()
        {
            JObject jobj = new JObject();
            var pushResult = await restmanager.RestRequest<PushModel>(jobj.ToString(), null, Method.POST, "/clipboard");
        }
    }
}
