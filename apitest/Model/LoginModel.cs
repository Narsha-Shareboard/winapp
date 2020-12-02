using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace winapp.Model
{
    public class LoginModel
    {
        public string result { get; set; }
        public string token { get; set; }
    }

    public class LoginCheck
    {
        public static bool isValidAccess = false;
    }

    public class TokenModel
    {
        private static TokenModel instance = null;
        public static TokenModel Get()
        {
            if (instance == null)
            {
                instance = new TokenModel();
            }
            return instance;
        }
        public string token { get; set; }
    }
}
