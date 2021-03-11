namespace Hopex.SDK.Core.Models.Response.Market
{
    public class GetTradesResponse
    {
        public long Id { get; set; }
        /// <summary>
        /// 成交时间
        /// </summary>
        public string Time { get; set; }
        /// <summary>
        /// 时间戳（毫秒xxx.xxx)
        /// </summary>
        public double Timestamp { get; set; }
        /// <summary>
        /// 成交价格
        /// </summary>
        public string FillPrice { get; set; }
        /// <summary>
        /// 成交数量
        /// </summary>
        public string FillQuantity { get; set; }
        /// <summary>
        /// 方向 1 sell 2 buy
        /// </summary>
        public string Side { get; set; }
    }
}
