using System.Collections.Generic;
using System.Threading.Tasks;
using Hopex.SDK.Core.Invoker.Models.Commons;
using Hopex.SDK.Core.Invoker.Services;
using Hopex.SDK.Core.Models.Response.Wallet;

namespace Hopex.SDK.Core.Client
{
    public class WalletClient
    {
        /// <summary>
        /// 获取用户出入金记录
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public Task<ListResultViewModel<GetDepositWithdrawResponse>> GetDepositWithdrawAsync(int page, int limit)
        {
            return HttpRequest.Get<ListResultViewModel<GetDepositWithdrawResponse>>("/api/v1/account_records", new Dictionary<string, string>
            {
                {"page", page.ToString() },
                {"limit", limit.ToString() },
            }, true);
        }

        /// <summary>
        /// 获取用户资产信息
        /// </summary>
        /// <returns></returns>
        public Task<GetUserWalletResponse> GetUserWalletAsync()
        {
            return HttpRequest.Get<GetUserWalletResponse>("/api/v1/wallet", null, true);
        }
    }
}
