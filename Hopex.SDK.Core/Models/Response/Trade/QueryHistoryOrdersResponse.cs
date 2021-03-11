namespace Hopex.SDK.Core.Models.Response.Trade
{
    public class QueryHistoryOrdersResponse
    {
        /// <summary>
        /// 订单ID
        /// </summary>
        public long OrderId { get; set; }

        /// <summary>
        /// 合约code
        /// </summary>
        public string ContractCode { get; set; }

        /// <summary>
        /// 合约name
        /// </summary>
        public string ContractName { get; set; }

        /// <summary>
        /// "1":限价开仓(限价单) "2":(市价开仓)(市价单)"3": 限价全平单,"4":市价全平单 5.限价部分平仓单 6.市价部分平仓单(部分平仓)
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 方向，1:卖 2买
        /// </summary>
        public string Side { get; set; }

        /// <summary>
        /// 订单对应的持仓方向
        /// </summary>
        public int Direct { get; set; }

        /// <summary>
        /// 方向
        /// </summary>
        public string SideDisplay { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public string Ctime { get; set; }

        /// <summary>
        /// 完成时间
        /// </summary>
        public string Ftime { get; set; }

        /// <summary>
        /// 数量（张）
        /// </summary>
        public string OrderQuantity { get; set; }

        ///// <summary>
        ///// taker手续费
        ///// </summary>
        //public decimal TakerFee { get; set; }

        ///// <summary>
        ///// maker手续费
        ///// </summary>
        //public decimal MakerFee { get; set; }

        ///// <summary>
        ///// 还剩下多少没有成交
        ///// </summary>
        //public string LeftQuantity { get; set; }

        /// <summary>
        /// 已经成交的数量
        /// </summary>
        public string FillQuantity { get; set; }

        ///// <summary>
        ///// 成交额
        ///// </summary>
        //public decimal Turnover { get; set; }

        /// <summary>
        /// 订单状态:1.部分成交 2:等待成交
        /// </summary>
        public string OrderStatus { get; set; }

        /// <summary>
        /// 订单状态
        /// </summary>
        public string OrderStatusDisplay { get; set; }

        /// <summary>
        /// 委托价
        /// </summary>
        public string OrderPrice { get; set; }

        /// <summary>
        /// 杠杆倍数
        /// </summary>
        public string Leverage { get; set; }

        /// <summary>
        /// 手续费(小数点后4位)
        /// </summary>
        public string Fee { get; set; }

        /// <summary>
        /// 成交均价(指数_合理价格小数位数)
        /// </summary>
        public string AvgFillMoney { get; set; }

        /// <summary>
        /// 平仓盈亏
        /// 小数点后4位
        /// 单位结算货币
        /// 成交数量为0时显示--
        /// </summary>
        public string ClosePosPNL { get; set; }

        /// <summary>
        /// 时间戳(微秒)
        /// </summary>
        public long Timestamp { get; set; }

        /// <summary>
        /// 订单类型
        /// <see cref="OrderSide"/>
        /// </summary>
        public int OrderTypeVal { get; set; }

        /// <summary>
        /// 订单类型
        /// </summary>
        public string OrderType { get; set; }

        /// <summary>
        /// 撤单原因（撤单时间自动是ftime)
        /// </summary>
        public string CancelReason { get; set; }
    }
}
