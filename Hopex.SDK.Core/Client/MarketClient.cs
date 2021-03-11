using Hopex.SDK.Core.Invoker.HttpClients;
using Hopex.SDK.Core.Invoker.Models.Commons;

using Hopex.SDK.Core.Models.Response.Market;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hopex.SDK.Core.Client
{
    public class MarketClient
    {
        public MarketClient()
        {

        }

        /// <summary>
        /// 获取K线
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="endTime"></param>
        /// <param name="startTime"></param>
        /// <param name="interval"></param>
        /// <returns></returns>
        public Task<GetKlineResponse> GetKlineAsync(string contractCode, long endTime, long startTime, string interval)
        {
            return HopexClient.Get<GetKlineResponse>("/api/v1/kline", new Dictionary<string, string>
            {
                {"contractCode", contractCode },
                {"endTime",endTime.ToString() },
                {"startTime",startTime.ToString() },
                {"interval",interval },
            }, false);
        }

        /// <summary>
        /// 获取单个合约行情
        /// </summary>
        /// <param name="contractCode"></param>
        /// <returns></returns>
        public Task<GetMarketTickerResponse> GetMarketTickerAsync(string contractCode)
        {
            return HopexClient.Get<GetMarketTickerResponse>("/api/v1/ticker", new Dictionary<string, string>
            {
                {"contractCode", contractCode }
            }, false);
        }

        /// <summary>
        /// 获取所有合约行情
        /// </summary>
        /// <returns></returns>
        public Task<List<GetMarketsResponse>> GetMarketsAsync()
        {
            return HopexClient.Get<List<GetMarketsResponse>>("/api/v1/markets", null, false);
        }

        /// <summary>
        /// 获取最新成交
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public Task<List<GetTradesResponse>> GetTradesAsync(string contractCode, int pageSize)
        {
            return HopexClient.Get<List<GetTradesResponse>>("/api/v1/trades", new Dictionary<string, string>
            {
                {"contractCode", contractCode },
                {"pageSize",pageSize.ToString() }
            }, false);
        }

        /// <summary>
        /// 获取合约深度信息
        /// </summary>
        /// <param name="contractCode"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public Task<PostQueryMarketDepthResponse> PostQueryMarketDepthAsync(string contractCode, int pageSize)
        {
            var req = new ApiRequestModel<dynamic>
            {
                Param = new Dictionary<string, string>
                {
                    {"contractCode", contractCode},
                    {"pageSize", pageSize.ToString()}
                }
            };

            return HopexClient.Post<ApiRequestModel<dynamic>, PostQueryMarketDepthResponse>("/api/v1/depth", req, null, false);
        }

    }
}
