namespace Hopex.SDK.Core.Models.Response.Trade
{
    public class QueryOrderParasResponse
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
        /// 合约方向（正向：Forward)
        /// </summary>
        public string ContractDirect { get; set; }

        /// <summary>
        /// 合约价值
        /// </summary>
        public string ContractValue { get; set; }

        /// <summary>
        /// 合约价值单位
        /// </summary>
        public string ValueUnit { get; set; }

        /// <summary>
        /// 结算货币
        /// </summary>
        public string CloseCurrency { get; set; }

        /// <summary>
        /// take费率
        /// </summary>
        public string TakeRate { get; set; }

        /// <summary>
        /// 用户是否允许交易
        /// </summary>
        public bool UserAllowTrade { get; set; }

        /// <summary>
        /// 合约是否允许交易
        /// </summary>
        public bool MarketAllowTrade { get; set; }

        /// <summary>
        /// 最小单位精度
        /// </summary>
        public int MinPricePrecision { get; set; }

        /// <summary>
        /// 最小单位
        /// </summary>
        public string MinPriceMovement { get; set; }

        /// <summary>
        /// 最小单位
        /// </summary>
        public string MinPriceMovementDisplay { get; set; }

        /// <summary>
        /// 多仓维持保证金率
        /// </summary>
        public string LongMaintenanceMarginRate { get; set; }

        /// <summary>
        /// 多仓维持保证金率%
        /// </summary>
        public string LongMaintenanceMarginRateDisplay { get; set; }

        /// <summary>
        /// 空仓维持保证金率
        /// </summary>
        public string ShortMaintenanceMarginRate { get; set; }

        /// <summary>
        /// 空仓维持保证金率%
        /// </summary>
        public string ShortMaintenanceMarginRateDisplay { get; set; }

        /// <summary>
        /// 最小交易数量
        /// </summary>
        public int MinTradeNum { get; set; }

        /// <summary>
        /// 最小交易数量
        /// </summary>
        public string MinTradeNumDisplay { get; set; }

        /// <summary>
        /// 可用余额 （保留4位小数）
        /// </summary>
        public string AvailableBalance { get; set; }

        /// <summary>
        /// 可用余额
        /// </summary>
        public string AvailableBalanceDisplay { get; set; }

        /// <summary>
        /// 最高允许买价（精度：合约最小变动价位位数）
        /// </summary>
        public string MaxBuyPrice { get; set; }

        /// <summary>
        /// 最低允许卖价（精度：合约最小变动价位位数)
        /// </summary>
        public string MinSellPrice { get; set; }

        /// <summary>
        /// 多仓-杠杆范围-最小值
        /// </summary>
        public string LongMinLeverage { get; set; }

        /// <summary>
        /// 多仓-杠杆范围-最大值
        /// </summary>
        public string LongMaxLeverage { get; set; }

        /// <summary>
        /// 空仓-杠杆范围-最小值
        /// </summary>
        public string ShortMinLeverage { get; set; }

        /// <summary>
        /// 空仓-杠杆范围-最大值
        /// </summary>
        public string ShortMaxLeverage { get; set; }

        /// <summary>
        /// 多仓默认杠杆
        /// </summary>
        public string LongDefaultLeverage { get; set; }

        /// <summary>
        /// 空仓默认杠杆
        /// </summary>
        public string ShortDefaultLeverage { get; set; }

        /// <summary>
        /// 多仓杠杆
        /// </summary>
        public string LongLeverage { get; set; }

        /// <summary>
        /// 空仓杠杆
        /// </summary>
        public string ShortLeverage { get; set; }

        /// <summary>
        ///买入开多保证金（保留4位小数)
        /// </summary>
        public string OpenLongMargin { get; set; }

        /// <summary>
        /// 买入开多保证金（展示）
        /// </summary>
        public string OpenLongMarginDisplay { get; set; }

        /// <summary>
        /// 卖出开空保证金（保留4位小数)
        /// </summary>
        public string OpenShortMargin { get; set; }

        /// <summary>
        /// 卖出开空保证金（展示）
        /// </summary>
        public string OpenShortMarginDisplay { get; set; }

        /// <summary>
        /// 可开多
        /// </summary>
        public long OpenLongAmount { get; set; }

        /// <summary>
        /// 可开空
        /// </summary>
        public long OpenShortAmount { get; set; }

        /// <summary>
        /// 可平多
        /// </summary>
        public long CloseLongAmount { get; set; }

        /// <summary>
        /// 可平空
        /// </summary>
        public long CloseShortAmount { get; set; }

        /// <summary>
        /// 委托价值（保留4位小数）
        /// </summary>
        public string EvaluateOrderValue { get; set; }

        /// <summary>
        /// 指数/合理价格小数位数
        /// </summary>
        public int Precision { get; set; }

        /// <summary>
        /// 是否设置追加保证金
        /// </summary>
        public bool IsAddMargin { get; set; }

        /// <summary>
        /// 多仓是否设置追加保证金
        /// </summary>
        public bool LongIsAddMargin { get; set; }

        /// <summary>
        /// 空仓是否设置追加保证金
        /// </summary>
        public bool ShortIsAddMargin { get; set; }

        /// <summary>
        /// 多仓强平价格
        /// </summary>
        public string LongLiquidationPrice { get; set; }

        /// <summary>
        /// 空仓强平价格
        /// </summary>
        public string ShortLiquidationPrice { get; set; }
    }
}
