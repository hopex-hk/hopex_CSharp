using Hopex.SDK.Core.Client;
using Hopex.SDK.Core.Log;
using Newtonsoft.Json;

namespace Hopex.SDK.Example.Example
{
    public class AccountClientExample
    {
        private static readonly PerformanceLogger _logger = PerformanceLogger.GetInstance();


        private static readonly AccountClient _accountClient = new AccountClient();

        public static void RunAll()
        {
            GetUserInfo();
        }


        /// <summary>
        /// 获取用户信息
        /// </summary>
        private static void GetUserInfo()
        {
            _logger.Start();
            var data = _accountClient.GetUserInfoAsync().Result;
            _logger.StopAndLog();

            AppLogger.Info($"get user info, data:{JsonConvert.SerializeObject(data)}");
        }
    }
}
