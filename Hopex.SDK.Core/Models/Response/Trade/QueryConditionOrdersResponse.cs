namespace Hopex.SDK.Core.Models.Response.Trade
{
    public class QueryConditionOrdersResponse
    {
        /// <summary>
        /// 条件单类型
        /// </summary>
        public int TaskType { get; set; }

        /// <summary>
        /// 条件单类型-描述
        /// </summary>
        public string TaskTypeD { get; set; }

        /// <summary>
        ///  条件单任务id
        /// </summary>
        public long TaskId { get; set; }

        /// <summary>
        /// 合约编码
        /// </summary>
        public string ContractCode { get; set; }

        /// <summary>
        /// 合约名称
        /// </summary>
        public string ContractName { get; set; }

        /// <summary>
        /// 1.开仓 2:平仓
        /// </summary>
        public int Action { get; set; }

        /// <summary>
        /// 1.多仓 2:空仓
        /// </summary>
        public int Direct { get; set; }

        /// <summary>
        /// 1卖2买
        /// </summary>
        public int Side { get; set; }

        /// <summary>
        /// 条件单任务当前状态，1:创建ok 2.已撤销 3.已触发委托成功 4.已触发委托失败'
        /// </summary>
        public int TaskStatus { get; set; }

        /// <summary>
        /// 条件单任务当前状态-描述
        /// </summary>
        public string TaskStatusD { get; set; }

        /// <summary>
        /// 触发类型
        /// </summary>
        public int TrigType { get; set; }

        /// <summary>
        /// 触发类型-描述
        /// </summary>
        public string TrigTypeD { get; set; }

        /// <summary>
        /// 触发价格
        /// </summary>
        public string TrigPrice { get; set; }

        /// <summary>
        /// 期待数量
        /// </summary>
        public string ExpectedQuantity { get; set; }

        /// <summary>
        /// 期待价格
        /// </summary>
        public string ExpectedPrice { get; set; }

        /// <summary>
        /// 有效期
        /// </summary>
        public string ExpireTime { get; set; }

        /// <summary>
        /// 委托时间-时间戳-微秒
        /// </summary>
        public double Timestamp { get; set; }

        /// <summary>
        /// 委托时间
        /// </summary>
        public string CreateTime { get; set; }

        /// <summary>
        /// 委托ID
        /// </summary>
        public long? OrderId { get; set; }

        /// <summary>
        /// 订单里面的委托数量
        /// </summary>
        public string OrderQuantity { get; set; }

        /// <summary>
        /// 订单里面的委托价格
        /// </summary>
        public string OrderPrice { get; set; }

        /// <summary>
        /// 触发时间,精确到微秒
        /// </summary>
        public string FinishTime { get; set; }

        /// <summary>
        /// 失败原因
        /// </summary>
        public string FailureReason { get; set; }

        /// <summary>
        /// 杠杆倍数
        /// </summary>
        public string Leverage { get; set; }
    }
}
