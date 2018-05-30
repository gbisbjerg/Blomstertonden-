using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blomstertonden
{
    public static class AppConfig
    {
        //private static string _serverURL = "http://localhost:54477/";

        private static string _serverURL = "http://webservice420180530111814.azurewebsites.net";

        /*http://webservice420180530111814.azurewebsites.net*/

        public static string ServerURL => _serverURL;
    }
}
