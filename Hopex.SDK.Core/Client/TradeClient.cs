using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using Hopex.SDK.Core.Invoker.Models.Commons;
using Hopex.SDK.Core.Invoker.Services;
using Hopex.SDK.Core.Models.Request.Trade;
using Hopex.SDK.Core.Models.Response.Trade;

namespace Hopex.SDK.Core.Client
{
    public class TradeClient
    {
        /// <summary>
        /// 获取活跃委托
        /// </summary>
        /// <param name="contractCode"></param>
        public Task<List<GetOpenOrdersResponse>> GetOpenOrdersAsync(string contractCode)
        {
            return HttpRequest.Get<List<GetOpenOrdersResponse>>("/api/v1/order_info", new Dictionary<string, string>
            {
                {"contractCode", contractCode }
            }, true);
        }

        /// <summary>
        /// 获取持仓
        /// </summary>
        /// <returns></returns>
        public Task<List<GetPositionsResponse>> GetPositionsAsync()
        {
            return HttpRequest.Get<List<GetPositionsResponse>>("/api/v1/position", null, true);
        }

        /// <summary>
        /// 撤条件单
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="taskId"></param>
        /// <returns></returns>
        public Task<bool> CancelConditionOrderAsync(string contractCode, long taskId)
        {
            var req = new ApiRequestModel<dynamic>
            {
                Param = new Dictionary<string, string>
                {
                    {"contractCode", contractCode},
                    {"taskId", taskId.ToString()}
                }
            };

            return HttpRequest.Post<ApiRequestModel<dynamic>, bool>("/api/v1/cancel_condition_order", req, null, true);
        }

        /// <summary>
        /// 撤单
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public Task<bool> CancelOrderAsync(string contractCode, long orderId)
        {
            return HttpRequest.Get<bool>("/api/v1/cancel_order", new Dictionary<string, string>
            {
                {"contractCode", contractCode},
                {"orderId", orderId.ToString()}
            }, true);
        }

        /// <summary>
        /// 下条件单
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="side"></param>
        /// <param name="type"></param>
        /// <param name="trigPrice"></param>
        /// <param name="expectedQuantity"></param>
        /// <param name="expectedPrice"></param>
        /// <returns></returns>
        public Task<bool> CreateConditionOrderAsync(string contractCode, int side, string type, decimal trigPrice,
            int expectedQuantity, decimal? expectedPrice)
        {
            var req = new ApiRequestModel<dynamic>
            {
                Param = new Dictionary<string, string>
                {
                    {"contractCode", contractCode},
                    {"side", side.ToString()},
                    {"type", type},
                    {"trigPrice", trigPrice.ToString(CultureInfo.InvariantCulture)},
                    {"expectedQuantity", expectedQuantity.ToString()},
                    {"expectedPrice", expectedPrice.ToString()},
                }
            };

            return HttpRequest.Post<ApiRequestModel<dynamic>, bool>("/api/v1/condition_order", req, null, true);
        }

        /// <summary>
        /// 下单
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="side"></param>
        /// <param name="orderQuantity"></param>
        /// <param name="orderPrice"></param>
        /// <returns></returns>
        public Task<long> CreateOrderAsync(string contractCode, int side, int orderQuantity, decimal? orderPrice)
        {
            var req = new ApiRequestModel<dynamic>
            {
                Param = new Dictionary<string, string>
                {
                    {"contractCode", contractCode},
                    {"side", side.ToString()},
                    {"orderQuantity", orderQuantity.ToString()},
                    {"orderPrice", orderPrice.ToString()}
                }
            };

            return HttpRequest.Post<ApiRequestModel<dynamic>, long>("/api/v1/order", req, null, true);
        }

        /// <summary>
        /// 获取条件单
        /// </summary>
        /// <param name="param"></param>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public Task<ListResultViewModel<QueryConditionOrdersResponse>> QueryConditionOrdersAsync(QueryConditionOrdersRequest param, int page = 1, int limit = 10)
        {
            var req = new ApiRequestModel<QueryConditionOrdersRequest>
            {
                Param = param
            };

            return HttpRequest.Post<ApiRequestModel<QueryConditionOrdersRequest>, ListResultViewModel<QueryConditionOrdersResponse>>("/api/v1/condition_order_info", req, new Dictionary<string, string>
            {
                { "page", page.ToString() },
                { "limit", limit.ToString() }
            }, true);
        }

        /// <summary>
        /// 获取历史委托
        /// </summary>
        /// <param name="param"></param>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public Task<ListResultViewModel<QueryHistoryOrdersResponse>> QueryHistoryOrdersAsync(QueryHistoryOrdersRequest param, int page = 1, int limit = 10)
        {
            var req = new ApiRequestModel<QueryHistoryOrdersRequest>
            {
                Param = param
            };

            return HttpRequest.Post<ApiRequestModel<QueryHistoryOrdersRequest>, ListResultViewModel<QueryHistoryOrdersResponse>>("/api/v1/order_history", req, new Dictionary<string, string>
            {
                { "page", page.ToString() },
                { "limit", limit.ToString() }
            }, true);
        }

        /// <summary>
        /// 获取用户强平历史
        /// </summary>
        /// <param name="param"></param>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public Task<ListResultViewModel<QueryLiquidationHistoryResponse>> QueryLiquidationHistoryAsync(QueryLiquidationHistoryRequest param, int page = 1, int limit = 10)
        {
            var req = new ApiRequestModel<QueryLiquidationHistoryRequest>
            {
                Param = param
            };

            return HttpRequest.Post<ApiRequestModel<QueryLiquidationHistoryRequest>, ListResultViewModel<QueryLiquidationHistoryResponse>>("/api/v1/liquidation_history", req, new Dictionary<string, string>
            {
                { "page", page.ToString() },
                { "limit", limit.ToString() }
            }, true);
        }

        /// <summary>
        /// 获取下单参数
        /// </summary>
        /// <param name="contractCode"></param>
        /// <returns></returns>
        public Task<QueryOrderParasResponse> QueryOrderParasAsync(string contractCode)
        {

            var req = new ApiRequestModel<Dictionary<string, string>>
            {
                Param = new Dictionary<string, string>
                {
                    {"contractCode", contractCode}
                }
            };

            return HttpRequest.Post<ApiRequestModel<Dictionary<string, string>>, QueryOrderParasResponse>("/api/v1/get_orderParas", req, null, true);
        }

        /// <summary>
        /// 设置用户合约杠杆
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="direct"></param>
        /// <param name="leverage"></param>
        /// <returns></returns>
        public Task<decimal> SetLeverageAsync(string contractCode, int direct, decimal leverage)
        {
            return HttpRequest.Get<decimal>("/api/v1/set_leverage", new Dictionary<string, string>
            {
                { "contractCode", contractCode },
                { "direct", direct.ToString() },
                { "leverage", leverage.ToString(CultureInfo.InvariantCulture) },
            }, true);
        }

    }
}
