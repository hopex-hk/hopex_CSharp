using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hopex.SDK.Core.Invoker.HttpClients;
using Hopex.SDK.Core.Models.Response.Account;

namespace Hopex.SDK.Core.Client
{
    public class AccountClient
    {
        private readonly string _apiKey;
        private readonly string _apiSecret;

        public AccountClient(string apiKey, string apiSecret)
        {
            _apiKey = apiKey;
            _apiSecret = apiSecret;
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <returns></returns>
        public Task<GetUserInfoResponse> GetUserInfoAsync()
        {
            return HopexClient.Get<GetUserInfoResponse>("/api/v1/userinfo", null, true, _apiKey, _apiSecret);
        }
    }
}
