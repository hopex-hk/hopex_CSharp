using System.Collections.Generic;
using System.Threading.Tasks;
using Hopex.SDK.Core.Invoker.HttpClients;
using Hopex.SDK.Core.Invoker.Models.Commons;
using Hopex.SDK.Core.Models.Response.Wallet;

namespace Hopex.SDK.Core.Client
{
    public class WalletClient
    {
        private readonly string _apiKey;
        private readonly string _apiSecret;

        public WalletClient(string apiKey, string apiSecret)
        {
            _apiKey = apiKey;
            _apiSecret = apiSecret;
        }

        /// <summary>
        /// 获取用户出入金记录
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public Task<ListResultViewModel<GetDepositWithdrawResponse>> GetDepositWithdrawAsync(int page, int limit)
        {
            return HopexClient.Get<ListResultViewModel<GetDepositWithdrawResponse>>("/api/v1/account_records", new Dictionary<string, string>
            {
                {"page", page.ToString() },
                {"limit", limit.ToString() },
            }, true, _apiKey, _apiSecret);
        }

        /// <summary>
        /// 获取用户资产信息
        /// </summary>
        /// <returns></returns>
        public Task<GetUserWalletResponse> GetUserWalletAsync()
        {
            return HopexClient.Get<GetUserWalletResponse>("/api/v1/wallet", null, true, _apiKey, _apiSecret);
        }
    }
}
