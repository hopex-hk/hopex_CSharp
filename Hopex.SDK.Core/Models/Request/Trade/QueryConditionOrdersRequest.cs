using System.Collections.Generic;

namespace Hopex.SDK.Core.Models.Request.Trade
{
    public class QueryConditionOrdersRequest
    {
        /// <summary>
        /// 合约编码列表，不传表示所有合约
        /// </summary>
        public List<string> ContractCodeList { get; set; } = new List<string>();

        /// <summary>
        /// 条件单类别 ,为空查所有
        /// </summary>
        public List<int> TaskTypeList { get; set; } = new List<int>();

        /// <summary>
        /// 条件单触发类别  1:市场价 2.合理价格  为空查所有
        /// </summary>
        public List<int> TrigTypeList { get; set; } = new List<int>();

        /// <summary>
        /// 条件单状态 1:已创建 2.已撤销 3.已触发委托成功 4.已触发委托失败',为空查所有
        /// </summary>
        public List<int> TaskStatusList { get; set; } = new List<int>();

        /// <summary>
        /// //1.多仓 2:空仓 3.单向持仓
        /// </summary>
        public int Direct { get; set; }

        /// <summary>
        /// 1:卖出 2:买入',0 查所有
        /// </summary>
        public int Side { get; set; }

        /// <summary>
        /// 0:not limit 按着时间段过滤,起始时间,精确到微秒
        /// </summary>
        public double StartTime { get; set; }

        /// <summary>
        /// 0:not limit    按着时间段过滤,结束时间,精确到微秒
        /// </summary>
        public double EndTime { get; set; }
    }
}
