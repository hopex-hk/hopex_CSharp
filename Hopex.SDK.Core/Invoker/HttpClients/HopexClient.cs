using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Versioning;
using Hopex.SDK.Core.Invoker.Models;

namespace Hopex.SDK.Core.Invoker.HttpClients
{
    public class HopexClient
    {
        private static readonly object _lock = new object();

        private static HttpClient _httpClient;


        public static HttpClient GetInstance()
        {
            if (_httpClient == null)
            {
                lock (_lock)
                {
                    if (_httpClient == null)
                    {
                        _httpClient = new HttpClient()
                        {
                            BaseAddress = new Uri(InvokerOption.HopexApiBase),
                        };

                        _httpClient.Timeout = TimeSpan.FromSeconds(20);
                        _httpClient.DefaultRequestHeaders.Accept.Clear();
                        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        _httpClient.DefaultRequestHeaders.ExpectContinue = false;
                        _httpClient.DefaultRequestHeaders.ConnectionClose = false;
                        _httpClient.DefaultRequestHeaders.Connection.Add("keep-alive");
                    }
                }
            }

            return _httpClient;
        }
    }
}
