using System.Collections.Generic;
using System.Threading.Tasks;
using Hopex.SDK.Core.Invoker.HttpClients;
using Hopex.SDK.Core.Invoker.Models.Commons;
using Hopex.SDK.Core.Models.Response.Home;

namespace Hopex.SDK.Core.Client
{
    public class HomeClient
    {
        public HomeClient()
        {

        }

        /// <summary>
        /// 获取成交量
        /// </summary>
        /// <returns></returns>
        public Task<GetIndexStatisticsResponse> GetIndexStatisticsAsync()
        {
            return HopexClient.Get<GetIndexStatisticsResponse>("/api/v1/indexStat", null, false);
        }

        /// <summary>
        /// 获取推送公告
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public Task<ListResultViewModel<GetIndexNotifyResponse>> GetIndexNotifyAsync(int page, int limit)
        {
            return HopexClient.Get<ListResultViewModel<GetIndexNotifyResponse>>("/api/v1/index_notify", new Dictionary<string, string>
            {
                {"page", page.ToString() },
                {"limit",limit.ToString() }
            }, false);
        }
    }
}
