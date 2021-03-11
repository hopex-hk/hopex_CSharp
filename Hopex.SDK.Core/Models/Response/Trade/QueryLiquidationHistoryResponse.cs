namespace Hopex.SDK.Core.Models.Response.Trade
{
    public class QueryLiquidationHistoryResponse
    {
        /// <summary>
        /// 订单id
        /// </summary>
        public long OrderId { get; set; }

        public string ContractCode { get; set; }

        /// <summary>
        /// 合约名称
        /// </summary>
        public string ContractName { get; set; }

        /// <summary>
        /// 方向，1:卖 2买
        /// </summary>
        public string Side { get; set; }

        /// <summary>
        /// 方向
        /// </summary>
        public string SideDisplay { get; set; }

        /// <summary>
        /// 订单类型
        /// </summary>
        public string OrderType { get; set; }

        /// <summary>
        /// 订单类型
        /// <see cref="OrderSide"/>
        /// </summary>
        public int OrderTypeVal { get; set; }

        /// <summary>
        /// 1 多，2空，3单向
        /// </summary>
        public int Direct { get; set; }

        /// <summary>
        /// 杠杆倍数
        /// </summary>
        public string Leverage { get; set; }

        /// <summary>
        /// 数量（张）
        /// </summary>
        public string OrderQuantity { get; set; }

        /// <summary>
        /// 价格
        /// </summary>
        public string OrderPrice { get; set; }

        /// <summary>
        /// 平仓盈亏
        /// 小数点后4位
        /// 单位结算货币
        /// 成交数量为0时显示--
        /// </summary>
        public string ClosePosPNL { get; set; }

        /// <summary>
        /// 手续费(小数点后4位)
        /// </summary>
        public string Fee { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public string Ctime { get; set; }

        /// <summary>
        /// 时间戳(微秒)
        /// </summary>
        public long Timestamp { get; set; }

        /// <summary>
        /// 1.空 2.多
        /// </summary>
        public int Direction { get; set; }

        /// <summary>
        /// 空/多
        /// </summary>
        public string DirectionDisplay { get; set; }

        /// <summary>
        /// 持仓占用保证金-4位小数
        /// </summary>
        public string PositionMargin { get; set; }

        /// <summary>
        /// 开仓均价,合理价格精度
        /// </summary>
        public string OpenPrice { get; set; }

        /// <summary>
        /// 实际强平价格 ,为0时显示--
        /// </summary>
        public string LiquidationPriceReal { get; set; }

        /// <summary>
        /// 是否显示强平详情
        /// </summary>
        public bool ShowDetail { get; set; } = false;
    }
}
