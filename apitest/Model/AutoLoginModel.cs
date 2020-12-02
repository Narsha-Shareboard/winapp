using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace winapp.Model
{
    public class AutoLoginModel
    {
        public string userId { get; set; }
        public string result { get; set; }
    }

    public class AutoLoginCheck
    {
        public static bool isValidAccess = false;
    }

    public class IdModel
    {
        private static IdModel instance = null;
        public static IdModel Get()
        {
            if (instance == null)
            {
                instance = new IdModel();
            }
            return instance;
        }
        public string userId { get; set; }
    }
}
