namespace Hopex.SDK.Core.Models.Response.Trade
{
    public class GetPositionsResponse
    {
        /// <summary>
        /// 允许全平
        /// </summary>
        public bool AllowFullClose { get; set; }
        /// <summary>
        /// 合约编码
        /// </summary>
        public string ContractCode { get; set; }
        /// <summary>
        /// 合约名称
        /// </summary>
        public string ContractName { get; set; }
        /// <summary>
        /// 杠杆倍数
        /// </summary>
        public string Leverage { get; set; }
        /// <summary>
        /// 合约价值
        /// </summary>
        public string ContractValue { get; set; }
        /// <summary>
        /// 合约方向："1":正向 "2":反向
        /// </summary>
        public string ContractDirection { get; set; }
        /// <summary>
        /// 合约的维持保证金率
        /// </summary>
        public string MaintMarginRate { get; set; }
        /// <summary>
        /// 提取方费率
        /// </summary>
        public string TakerFee { get; set; }
        /// <summary>
        /// 持仓量
        /// </summary>
        public string PositionQuantity { get; set; }

        /// <summary>
        /// 持仓量
        /// </summary>
        public int PositionQuantityD { get; set; }

        /// <summary>
        /// 持仓方向 1: 多仓，2：空仓, 3:单向持仓
        /// </summary>
        public int Direct { get; set; }

        /// <summary>
        /// 持仓方向（持多 1 /持空 -1)
        /// </summary>
        public int PosiDirect { get; set; }
        /// <summary>
        ///  持仓方向（持多/持空)
        /// </summary>
        public string PosiDirectD { get; set; }
        /// <summary>
        /// 开仓均价
        /// </summary>
        public string EntryPrice { get; set; }
        /// <summary>
        /// 开仓均价 decimal
        /// </summary>
        public decimal EntryPriceD { get; set; }
        /// <summary>
        /// 持仓占用保证金
        /// </summary>
        public string PositionMargin { get; set; }
        /// <summary>
        /// 持仓占用保证金 decimal
        /// </summary>
        public decimal PositionMarginD { get; set; }
        /// <summary>
        /// 强平价格
        /// </summary>
        public string LiquidationPrice { get; set; }
        /// <summary>
        /// 维持保证金
        /// </summary>
        public string MaintMargin { get; set; }
        /// <summary>
        /// 浮动盈亏
        /// </summary>
        public string UnrealisedPnl { get; set; }
        /// <summary>
        /// 收益率
        /// </summary>
        public string UnrealisedPnlPcnt { get; set; }
        /// <summary>
        /// 合理价格
        /// </summary>
        public string FairPrice { get; set; }

        /// <summary>
        /// 合理价格 decimal
        /// </summary>
        public decimal FairPriceD { get; set; }

        /// <summary>
        /// 最新成交价
        /// </summary>
        public string LastPrice { get; set; }

        /// <summary>
        /// 档长度
        /// </summary>
        public int Sequence { get; set; }

        /// <summary>
        /// 用户落在第几档
        /// </summary>
        public int Rank { get; set; }

        /// <summary>
        /// 最小变动价位
        /// </summary>
        public decimal MinPriceMovement { get; set; }

        /// <summary>
        /// 最小变动价位精度
        /// </summary>
        public int MinPriceMovementPrecision { get; set; }

        /// <summary>
        /// 冻结的持仓量,等待成交的平仓订单的总量
        /// </summary>
        public string PositionQuantityFreeze { get; set; }

        /// <summary>
        /// 可平数量
        /// </summary>
        public string CloseablePositionQuantity { get; set; }

        /// <summary>
        /// 可平数量（格式化展示）
        /// </summary>
        public string CloseablePositionQuantityD { get; set; }

        /// <summary>
        /// 是否设置追加保证金
        /// </summary>
        public bool IsAddMargin { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 判断是否存在白名单
        /// </summary>
        public bool IsWhitelistExist { get; set; }
        /// <summary>
        /// 结算货币
        /// </summary>
        public string CloseCurrency { get; set; }
    }
}
