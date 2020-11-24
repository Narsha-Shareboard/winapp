using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace winapp.manager
{
    public class QueryParam
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
    public class RestManager
    {

        /// <summary>
        /// 서버 통신
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns> 서버 통신의 결과값 </returns>
        public async Task<T> RestRequest<T>(string jsondata, QueryParam[] queryParams, Method method, string reosurces)     //<t>는 받아오는 자료형에 따라서 변환해줌
        {
            var restClient = new RestClient(ServerSetting.ServerUri);
            var request = new RestRequest(reosurces, method);

            if (jsondata != null)
            {
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", jsondata,  ParameterType.RequestBody);
            }

            if(queryParams != null)
            {
                foreach(QueryParam queryParam in queryParams)
                {
                    request.AddQueryParameter(queryParam.Key, queryParam.Value);
                }
            }

            var response = await restClient.ExecuteAsync<T>(request);       // await = 위의 비동기 작업이 끝날때 까지 기다려줌

            var result = JsonConvert.DeserializeObject<T>(response.Content);
            return result;
        }

        internal Task RestRequest<T>(string v1, object p, object pOST, string v2)
        {
            throw new NotImplementedException();
        }
    }
}
