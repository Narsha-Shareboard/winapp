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
    public class PullViewModel
    {
        RestManager restmanager = new RestManager();

        public string[] clipboard;
        public async Task Push()
        {
            JObject jobj = new JObject();
            var pullResult = await restmanager.RestRequest<PullModel>(jobj.ToString(), null, Method.GET, "/clipboard");
            clipboard = pullResult.clipboard;
        }
    }
}
