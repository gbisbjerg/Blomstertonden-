using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blomstertonden
{
    public static class AppConfig
    {
        private static string _serverURL = "http://localhost:49957/";

        public static string ServerURL => _serverURL;
    }
}
