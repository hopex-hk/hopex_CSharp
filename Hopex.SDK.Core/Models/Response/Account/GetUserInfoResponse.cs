namespace Hopex.SDK.Core.Models.Response.Account
{
    public class GetUserInfoResponse
    {
        /// <summary>
        /// 计价货币
        /// </summary>
        public string ConversionCurrency { get; set; }

        /// <summary>
        /// 当前持仓收益率(浮动盈亏/持仓占用保证金)
        /// </summary>
        public string ProfitRate { get; set; } = "0.00%";

        /// <summary>
        /// 账户总权益估值（法币)
        /// </summary>
        public string TotalWealth { get; set; }

        /// <summary>
        /// 总浮动盈亏估值（法币)
        /// </summary>
        public string FloatProfit { get; set; }

        /// <summary>
        /// 持仓数
        /// </summary>
        public int Position { get; set; }

        /// <summary>
        /// 活跃委托书数
        /// </summary>
        public int ActiveOrder { get; set; }
    }
}
