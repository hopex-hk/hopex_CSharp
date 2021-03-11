using Hopex.SDK.Core.Client;
using Hopex.SDK.Core.Invoker.Models;
using Hopex.SDK.Core.Log;
using Hopex.SDK.Core.Models;
using Hopex.SDK.Core.Models.Request.Trade;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Hopex.SDK.Example.Example
{
    public class TradeClientExample
    {
        private static readonly PerformanceLogger _logger = PerformanceLogger.GetInstance();

        private static readonly TradeClient _tradeClient = new TradeClient(InvokerOption.ApiKey, InvokerOption.ApiSecret);

        private const string _contractCode = "BTCUSDT";

        public static void RunAll()
        {
            GetOpenOrders(_contractCode);
            GetPositions();
            SetLeverage(_contractCode);

            var orderId = CreateOrder(_contractCode);
            CancelOrder(_contractCode, orderId);

            CreateConditionOrder(_contractCode);
            var taskId = QueryConditionOrders(_contractCode);
            CancelConditionOrder(_contractCode, taskId);

            QueryHistoryOrders(_contractCode);
            QueryLiquidationHistory(_contractCode);
            QueryOrderParas(_contractCode);
        }

        /// <summary>
        /// 获取活跃委托
        /// </summary>
        /// <param name="contractCode"></param>
        private static void GetOpenOrders(string contractCode)
        {
            _logger.Start();
            var data = _tradeClient.GetOpenOrdersAsync(contractCode).Result;
            _logger.StopAndLog();

            AppLogger.Info($"get open orders, data:{JsonConvert.SerializeObject(data)}");
        }

        /// <summary>
        /// 获取持仓
        /// </summary>
        private static void GetPositions()
        {
            _logger.Start();
            var data = _tradeClient.GetPositionsAsync().Result;
            _logger.StopAndLog();

            AppLogger.Info($"get positions, data:{JsonConvert.SerializeObject(data)}");
        }

        /// <summary>
        /// 撤条件单
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="taskId"></param>
        private static void CancelConditionOrder(string contractCode, long taskId)
        {
            _logger.Start();

            var data = _tradeClient.CancelConditionOrderAsync(contractCode, taskId).Result;

            _logger.StopAndLog();

            AppLogger.Info($"cancel condition order taskId:{taskId} done, data:{data}");
        }
        
        /// <summary>
        /// 撤单
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="orderId"></param>
        private static void CancelOrder(string contractCode, long orderId)
        {
            if (orderId <= 0)
            {
                AppLogger.Error($"invalid orderId");
                return;
            }

            _logger.Start();
            var data = _tradeClient.CancelOrderAsync(contractCode, orderId).Result;
            _logger.StopAndLog();

            AppLogger.Info($"cancel order orderId:{orderId} done, result:{data}");
        }

        /// <summary>
        /// 下条件单
        /// </summary>
        /// <param name="contractCode"></param>
        private static void CreateConditionOrder(string contractCode)
        {
            _logger.Start();

            var data = _tradeClient.CreateConditionOrderAsync(contractCode, (int)OrderTradeType.BuyLong, OrderType.Limit.ToString(),
                60000, 10, 48000).Result;

            _logger.StopAndLog();

            AppLogger.Info($"create condition order done, result:{data}");
        }

        /// <summary>
        /// 下单
        /// </summary>
        /// <param name="contractCode"></param>
        /// <returns></returns>
        private static long CreateOrder(string contractCode)
        {
            _logger.Start();

            var orderId = _tradeClient.CreateOrderAsync(contractCode, (int)OrderTradeType.BuyLong, 10, 45000).Result;

            _logger.StopAndLog();

            AppLogger.Info($"create order done, orderId:{orderId}");

            return orderId;
        }

        /// <summary>
        /// 获取条件单
        /// </summary>
        /// <param name="contractCode"></param>
        /// <returns></returns>
        private static long QueryConditionOrders(string contractCode)
        {
            _logger.Start();
            var req = new QueryConditionOrdersRequest
            {
                ContractCodeList = new List<string>() { contractCode },
                TaskTypeList = new List<int>(),
                TrigTypeList = new List<int>(),
                TaskStatusList = new List<int>(),
                Direct = 0,
                Side = 0,
                StartTime = 0,
                EndTime = 0
            };
            var data = _tradeClient.QueryConditionOrdersAsync(req).Result;
            _logger.StopAndLog();
            AppLogger.Info($"query condition orders, data:{JsonConvert.SerializeObject(data)}");

            long taskId = 0;
            if (data != null && data.Result.Any())
            {
                taskId = data.Result.FirstOrDefault(x => x.TaskStatus == 1)?.TaskId ?? 0;
            }

            return taskId;
        }

        /// <summary>
        /// 获取历史委托
        /// </summary>
        /// <param name="contractCode"></param>
        private static void QueryHistoryOrders(string contractCode)
        {
            _logger.Start();
            var req = new QueryHistoryOrdersRequest()
            {
                ContractCodeList = new List<string>() { contractCode },
                TypeList = new List<int>(),
                Side = 0,
                StartTime = 0,
                EndTime = 0
            };

            var data = _tradeClient.QueryHistoryOrdersAsync(req).Result;

            _logger.StopAndLog();
            AppLogger.Info($"query history orders, data:{JsonConvert.SerializeObject(data)}");
        }

        /// <summary>
        /// 获取用户强平历史
        /// </summary>
        /// <param name="contractCode"></param>
        private static void QueryLiquidationHistory(string contractCode)
        {
            _logger.Start();
            var req = new QueryLiquidationHistoryRequest()
            {
                ContractCodeList = new List<string>() { contractCode },
                Side = 0
            };

            var data = _tradeClient.QueryLiquidationHistoryAsync(req).Result;

            _logger.StopAndLog();
            AppLogger.Info($"query liquidation orders, data:{JsonConvert.SerializeObject(data)}");
        }

        /// <summary>
        /// 获取下单参数
        /// </summary>
        /// <param name="contractCode"></param>
        private static void QueryOrderParas(string contractCode)
        {
            _logger.Start();

            var data = _tradeClient.QueryOrderParasAsync(contractCode).Result;

            _logger.StopAndLog();

            AppLogger.Info($"query order paras, data:{JsonConvert.SerializeObject(data)}");
        }

        /// <summary>
        /// 设置用户合约杠杆
        /// </summary>
        /// <param name="contractCode"></param>
        private static void SetLeverage(string contractCode)
        {
            _logger.Start();

            var data = _tradeClient.SetLeverageAsync(contractCode, (int)Direct.Long, 20).Result;

            _logger.StopAndLog();

            AppLogger.Info($"set leverage, data:{JsonConvert.SerializeObject(data)}");
        }
    }
}
