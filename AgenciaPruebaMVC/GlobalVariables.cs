﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace AgenciaPruebaMVC
{
    public static class GlobalVariables
    {
        public static HttpClient webApiClient = new HttpClient();

        static GlobalVariables()
        {
            webApiClient.BaseAddress = new Uri("http://localhost:49868/api/");
            webApiClient.DefaultRequestHeaders.Clear();
            webApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}