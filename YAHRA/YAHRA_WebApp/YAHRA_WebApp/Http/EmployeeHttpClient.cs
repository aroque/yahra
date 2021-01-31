using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace YAHRA_WebApp.Http
{
    public class EmployeeHttpClient
    {
        private HttpClient _httpClient;
        private EmployeeHttpClient ()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(ConfigurationManager.AppSettings["baseUrl"]);

            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public HttpClient Instance
        {
            get
            {
                if (_httpClient == null)
                    new EmployeeHttpClient();

                return _httpClient;
            }
        }
    }
}