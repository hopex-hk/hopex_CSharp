namespace Hopex.SDK.Core.Models.Response.Market
{
    public class GetMarketsResponse
    {
        /// <summary>
        /// 合约编码
        /// </summary>
        public string ContractCode { get; set; }

        /// <summary>
        /// 合约名称
        /// </summary>
        public string ContractName { get; set; }

        /// <summary>
        /// 合约是否允许交易
        /// </summary>
        public bool AllowTrade { get; set; }

        /// <summary>
        /// 有持仓
        /// </summary>
        public bool HasPosition { get; set; }

        ///// <summary>
        ///// 持仓方向（持多 1 /持空 -1)
        ///// </summary>
        //public int PosiDirect { get; set; }

        ///// <summary>
        /////  持仓方向（持多/持空)
        ///// </summary>
        //public string PosiDirectD { get; set; }

        /// <summary>
        /// 结算货币
        /// </summary>
        public string CloseCurrency { get; set; }

        /// <summary>
        /// 标价币种
        /// </summary>
        public string QuotedCurrency { get; set; }

        /// <summary>
        /// 合理价格精度
        /// </summary>
        public int Precision { get; set; }

        /// <summary>
        /// 合约最小变动价格
        /// </summary>
        public decimal MinPriceMovement { get; set; }

        /// <summary>
        /// 价格精度
        /// </summary>
        public int PricePrecision { get; set; }

        /// <summary>
        /// 最新价
        /// </summary>
        public decimal? LastestPrice { get; set; }

        /// <summary>
        /// 24小时涨跌幅
        /// </summary>
        public decimal? ChangePercent24h { get; set; }

        /// <summary>
        /// 24小时成交额
        /// </summary>
        public decimal? SumAmount24h { get; set; }

        /// <summary>
        /// 24小时成交额-usdt
        /// </summary>
        public decimal? SumAmount24hUSDT { get; set; }
        /// <summary>
        /// 合约未平仓量价值(USD)
        /// </summary>
        public string PosVauleUSD { get; set; }
    }
}
