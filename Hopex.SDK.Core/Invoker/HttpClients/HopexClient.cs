using Hopex.SDK.Core.Invoker.Exceptions;
using Hopex.SDK.Core.Invoker.Models;
using Hopex.SDK.Core.Invoker.Models.Commons;
using Hopex.SDK.Core.Invoker.Utils;
using Hopex.SDK.Core.Log;
using Hopex.SDK.Invoker.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Hopex.SDK.Core.Invoker.HttpClients
{
    public class HopexClient
    {
        public static PerformanceLogger _logger = PerformanceLogger.GetInstance();
        private static readonly object _lock = new object();

        private static HttpClient _client = GetInstance();

        public static HttpClient GetInstance()
        {
            if (_client == null)
            {
                lock (_lock)
                {
                    if (_client == null)
                    {
                        _client = new HttpClient()
                        {
                            BaseAddress = new Uri(InvokerOption.HopexApiBase),
                        };

                        _client.Timeout = TimeSpan.FromSeconds(20);
                        _client.DefaultRequestHeaders.Accept.Clear();
                        _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        _client.DefaultRequestHeaders.ExpectContinue = false;
                        _client.DefaultRequestHeaders.ConnectionClose = false;
                        _client.DefaultRequestHeaders.Connection.Add("keep-alive");
                    }
                }
            }

            return _client;
        }

        private const string GET_METHOD = "GET";
        private const string POST_METHOD = "POST";

        public static async Task<T> Get<T>(string apiUrl, IDictionary<string, string> paras, bool isSign = false, string apiKey = "", string apiSecret = "", string host = "", CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(apiUrl)) throw new ArgumentNullException(nameof(apiUrl));

            using (var request = new HttpRequestMessage(HttpMethod.Get, QueryHelpers.AddQueryString(apiUrl, AddCommonParas(paras))))
            {
                BuildHead(request, GET_METHOD, apiUrl, JsonConvert.SerializeObject(paras), isSign, apiKey, apiSecret);

                if (!string.IsNullOrEmpty(host)) _client.BaseAddress = new Uri(host);
                
                _logger.RquestStart(GET_METHOD, apiUrl);


                using (var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false))
                {
                    _logger.RequestEnd(response.StatusCode.ToString());

                    response.EnsureSuccessStatusCode();

                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        using (StreamReader sr = new StreamReader(await response.Content
                            .ReadAsStreamAsync().ConfigureAwait(false)))
                        using (JsonReader reader = new JsonTextReader(sr))
                        {
                            var serializer = JsonSerializer.CreateDefault();
                            var rps = serializer.Deserialize<ApiResponseModel<T>>(reader);

                            if (!string.IsNullOrEmpty(rps.Message))
                            {
                                throw new InvokerFailException(rps.Message);
                            }

                            if (rps.Ret != 0)
                            {
                                throw new InvokerFailException(rps.ErrCode, rps.ErrStr);
                            }

                            return rps.Data;
                        }
                    }

                    return default;
                }
            }
        }

        /// <summary>
        ///  Send Http POST request
        /// </summary>
        /// <typeparam name="RequestT"></typeparam>
        /// <typeparam name="ResponseT"></typeparam>
        /// <param name="apiUrl"></param>
        /// <param name="requestPara"></param>
        /// <param name="urlParas"></param>
        /// <param name="isSign"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<ResponseT> Post<RequestT, ResponseT>(string apiUrl, RequestT requestPara, IDictionary<string, string> urlParas = null, bool isSign = false, string apiKey = "", string apiSecret = "", string host = "", CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(apiUrl)) throw new ArgumentNullException(nameof(apiUrl));

            using (var request = new HttpRequestMessage(HttpMethod.Post, QueryHelpers.AddQueryString(apiUrl, AddCommonParas(urlParas))))
            {
                BuildHead(request, POST_METHOD, apiUrl, JsonConvert.SerializeObject(requestPara), isSign, apiKey, apiSecret);

                using (var httpContent = JsonHelper.CreateJsonContent(requestPara))
                {
                    request.Content = httpContent;

                    if (!string.IsNullOrEmpty(host)) _client.BaseAddress = new Uri(host);

                    _logger.RquestStart(POST_METHOD, apiUrl);

                    using (var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false))
                    {
                        _logger.RequestEnd(response.StatusCode.ToString());
                        response.EnsureSuccessStatusCode();

                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            using (StreamReader sr = new StreamReader(await response.Content.ReadAsStreamAsync().ConfigureAwait(false)))
                            using (JsonReader reader = new JsonTextReader(sr))
                            {
                                var serializer = JsonSerializer.CreateDefault();
                                var rps = serializer.Deserialize<ApiResponseModel<ResponseT>>(reader);

                                if (!string.IsNullOrEmpty(rps.Message))
                                {
                                    throw new InvokerFailException(rps.Message);
                                }

                                if (rps.Ret != 0)
                                {
                                    throw new InvokerFailException(rps.ErrCode, rps.ErrStr);
                                }

                                return rps.Data;
                            }
                        }
                        return default;
                    }
                }
            }
        }

        private static IDictionary<string, string> AddCommonParas(IDictionary<string, string> paras)
        {
            paras ??= new Dictionary<string, string>();
            paras.TryAdd("culture", CultureInfo.CurrentCulture.Name);

            return paras;
        }

        private static void BuildHead(HttpRequestMessage request, string method, string apiUrl, string payload, bool isSign, string apiKey = "", string apiSecret = "")
        {
            var headers = new Dictionary<string, string>
            {
                { "User-Agent", InvokerOption.UserAgent ?? string.Empty }   // Please Specified Your Exchange Name
            };

            if (isSign)
            {
                var date = DateTime.UtcNow.ToString("r");
                var digest = HashUtil.HmacSha256(payload);
                var textToSign = "";
                textToSign += $"date: {date}\n";
                textToSign += $"{method} {apiUrl} HTTP/1.1\n";
                textToSign += $"digest: SHA-256={digest}";
                var signature = HashUtil.HmacSha256(textToSign, apiSecret);
                var headAuth = $"hmac apikey=\"{apiKey}\", algorithm=\"hmac-sha256\", headers=\"date request-line digest\", signature=\"{signature}\"";

                headers.Add("Date", date);
                headers.Add("Digest", $"SHA-256={digest}");
                headers.Add("Authorization", headAuth);
            }

            foreach (var (key, value) in headers)
            {
                request.Headers.Add(key, value);
            }
        }
    }
}
