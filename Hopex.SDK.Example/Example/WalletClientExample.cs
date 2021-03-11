using Hopex.SDK.Core.Client;
using Hopex.SDK.Core.Invoker.Models;
using Hopex.SDK.Core.Log;
using Newtonsoft.Json;

namespace Hopex.SDK.Example.Example
{
    public class WalletClientExample
    {
        private static readonly PerformanceLogger _logger = PerformanceLogger.GetInstance();

        private static readonly WalletClient _walletClient = new WalletClient(InvokerOption.ApiKey, InvokerOption.ApiSecret);

        public static void RunAll()
        {
            GetDepositWithdraw();
            GetUserWallet();
        }

        /// <summary>
        /// 获取用户出入金记录
        /// </summary>
        private static void GetDepositWithdraw()
        {
            _logger.Start();
            var data = _walletClient.GetDepositWithdrawAsync(1, 10).Result;
            _logger.StopAndLog();

            AppLogger.Info($"get deposit withdraw record, data:{JsonConvert.SerializeObject(data)}");
        }

        /// <summary>
        /// 获取用户资产信息
        /// </summary>
        private static void GetUserWallet()
        {
            _logger.Start();
            var data = _walletClient.GetUserWalletAsync().Result;
            _logger.StopAndLog();

            AppLogger.Info($"get user wallet, data:{JsonConvert.SerializeObject(data)}");
        }
    }
}
