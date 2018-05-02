using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blomstertonden.AppBase
{
    public static class AppConfig
    {
        private static string _serverURL = "";

        public static string ServerURL
        {
            get { return _serverURL; }
        }
    }
}
