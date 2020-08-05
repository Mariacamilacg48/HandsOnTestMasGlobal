using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace prjMasGlobalCommon
{
    public class HelperAPI
    {
        public HttpClient Initial()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://masglobaltestapi.azurewebsites.net");
            return client;
        }
    }
}
