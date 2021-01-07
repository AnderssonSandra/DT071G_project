using Newtonsoft.Json;
using System;
using System.Net;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Drawing;
using Console = Colorful.Console;
using System.Threading.Tasks;

namespace DT071G_project
{
    class AccessToken
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public long expires_in { get; set; }
    }

}
