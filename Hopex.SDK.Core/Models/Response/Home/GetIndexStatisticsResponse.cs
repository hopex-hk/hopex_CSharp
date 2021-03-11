namespace Hopex.SDK.Core.Models.Response.Home
{
    public class GetIndexStatisticsResponse
    {
        /// <summary>
        /// 未平仓合约价值(USD)
        /// </summary>
        public string PosVauleUSD { get; set; }

        /// <summary>
        /// 未平仓合约价值(CNY)
        /// </summary>
        public string PosVauleCNY { get; set; }

        /// <summary>
        /// 24h交易额
        /// </summary>
        public string Amount24hUSD { get; set; }
        /// <summary>
        /// 24h交易额
        /// </summary>
        public string Amount24hCNY { get; set; }

        /// <summary>
        /// 7day交易额
        /// </summary>
        public string Amount7dayUSD { get; set; }
        /// <summary>
        /// 7day交易额
        /// </summary>
        public string Amount7dayCNY { get; set; }

        /// <summary>
        /// 用户数
        /// </summary>
        public string UserCount { get; set; }

        /// <summary>
        /// 总交易额
        /// </summary>
        public string DealCountUSD { get; set; }
        /// <summary>
        /// 总交易额
        /// </summary>
        public string DealCountCNY { get; set; }
    }
}
