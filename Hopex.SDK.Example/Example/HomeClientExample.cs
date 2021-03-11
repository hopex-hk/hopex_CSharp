using Hopex.SDK.Core.Client;
using Hopex.SDK.Core.Log;
using Newtonsoft.Json;

namespace Hopex.SDK.Example.Example
{
    public class HomeClientExample
    {
        private static readonly PerformanceLogger _logger = PerformanceLogger.GetInstance();

        private static readonly HomeClient _homeClient = new HomeClient();

        public static void RunAll()
        {
            GetIndexStatistics();
            GetIndexNotify();
        }

        /// <summary>
        /// 获取成交量
        /// </summary>
        private static void GetIndexStatistics()
        {
            _logger.Start();
            var data = _homeClient.GetIndexStatisticsAsync().Result;
            _logger.StopAndLog();

            AppLogger.Info($"get index statistics, data:{JsonConvert.SerializeObject(data)}");
        }

        /// <summary>
        /// 获取推送公告
        /// </summary>
        private static void GetIndexNotify()
        {

            _logger.Start();
            var data = _homeClient.GetIndexNotifyAsync(1, 5).Result;
            _logger.StopAndLog();

            AppLogger.Info($"get index notify, data:{JsonConvert.SerializeObject(data)}");
        }
    }
}
