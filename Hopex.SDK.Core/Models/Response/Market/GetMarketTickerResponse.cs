namespace Hopex.SDK.Core.Models.Response.Market
{
    public class GetMarketTickerResponse
    {
        /// <summary>
        /// 合约编码
        /// </summary>
        public string ContractCode { get; set; }

        /// <summary>
        /// 现货指数编码
        /// </summary>
        public string SpotIndexCode { get; set; }

        /// <summary>
        /// 合理价格编码
        /// </summary>
        public string FairPriceCode { get; set; }

        /// <summary>
        /// 合约名称
        /// </summary>
        public string ContractName { get; set; }

        /// <summary>
        /// 结算货币
        /// </summary>
        public string CloseCurrency { get; set; }

        /// <summary>
        /// 合约是否允许交易
        /// </summary>
        public bool AllowTrade { get; set; }

        /// <summary>
        /// 是否暂停交易，暂停：true 启用: false
        /// </summary>
        public bool Pause { get; set; }

        /// <summary>
        /// 最新价
        /// </summary>
        public string LastPrice { get; set; }

        /// <summary>
        /// 最新价To USD（兼容旧版本)
        /// </summary>
        public string LastPriceToUSD { get; set; }

        /// <summary>
        /// 最新价 to 法币
        /// </summary>
        public string LastPriceLegal { get; set; }

        /// <summary>
        /// 24小时涨跌幅
        /// </summary>
        public string ChangePercent24 { get; set; }

        /// <summary>
        /// 现货指数价格
        /// </summary>
        public string MarketPrice { get; set; }

        /// <summary>
        /// 现货指数价格-解释
        /// </summary>
        public string MarketPriceInfo { get; set; }

        /// <summary>
        /// 合理价格
        /// </summary>
        public string FairPrice { get; set; }

        /// <summary>
        /// 合理价格-解释
        /// </summary>
        public string FairePriceInfo { get; set; }

        /// <summary>
        /// 24h最高
        /// </summary>
        public string Price24Max { get; set; }

        /// <summary>
        /// 24h最低
        /// </summary>
        public string Price24Min { get; set; }

        /// <summary>
        /// 24h交易额
        /// </summary>
        public string Amount24h { get; set; }

        /// <summary>
        /// 最新价To CNY
        /// </summary>
        public string LastPriceToCNY { get; set; }

        /// <summary>
        /// 24h交易量
        /// </summary>
        public string Quantity24h { get; set; }

        /// <summary>
        /// 资金费率
        /// </summary>
        public string FundRate { get; set; }
    }
}
