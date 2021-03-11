using System;
using Hopex.SDK.Core.Client;
using Hopex.SDK.Core.Invoker.Utils;
using Hopex.SDK.Core.Log;
using Hopex.SDK.Core.Models;
using Newtonsoft.Json;

namespace Hopex.SDK.Example.Example
{
    public class MarketClientExample
    {
        private static readonly PerformanceLogger _logger = PerformanceLogger.GetInstance();

        private static readonly MarketClient _marketClient = new MarketClient();

        public static void RunAll()
        {
            GetKline();
            GetMarketTicker();
            GetMarkets();
            GetTrades();
            PostQueryMarketDepth();
        }

        /// <summary>
        /// 获取K线
        /// </summary>
        private static void GetKline()
        {
            _logger.Start();
            var data = _marketClient.GetKlineAsync("BTCUSDT", DateTimeUtil.GetTimestamps_seconds(DateTime.Now),
                DateTimeUtil.GetTimestamps_seconds(DateTime.Now.AddDays(-1)), CandlestickInterval.HOUR1).Result;
            _logger.StopAndLog();

            AppLogger.Info($"get kline, data:{JsonConvert.SerializeObject(data)}");
        }

        /// <summary>
        /// 获取单个合约行情
        /// </summary>
        private static void GetMarketTicker()
        {
            _logger.Start();
            var data = _marketClient.GetMarketTickerAsync("BTCUSDT").Result;
            _logger.StopAndLog();

            AppLogger.Info($"get market ticker, data:{JsonConvert.SerializeObject(data)}");
        }

        /// <summary>
        /// 获取所有合约行情
        /// </summary>
        private static void GetMarkets()
        {
            _logger.Start();
            var data = _marketClient.GetMarketsAsync().Result;
            _logger.StopAndLog();

            AppLogger.Info($"get markets, data:{JsonConvert.SerializeObject(data)}");
        }

        /// <summary>
        /// 获取最新成交
        /// </summary>
        private static void GetTrades()
        {
            _logger.Start();
            var data = _marketClient.GetTradesAsync("BTCUSDT", 10).Result;
            _logger.StopAndLog();

            AppLogger.Info($"get trades, data:{JsonConvert.SerializeObject(data)}");
        }

        /// <summary>
        /// 获取合约深度信息
        /// </summary>
        private static void PostQueryMarketDepth()
        {
            _logger.Start();
            var data = _marketClient.PostQueryMarketDepthAsync("BTCUSDT", 10).Result;
            _logger.StopAndLog();

            AppLogger.Info($"post query market depth, data:{JsonConvert.SerializeObject(data)}");
        }
    }
}
