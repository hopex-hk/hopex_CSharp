using System.Collections.Generic;

namespace Hopex.SDK.Core.Models.Request.Trade
{
    public class QueryLiquidationHistoryRequest
    {
        /// <summary>
        /// 0 for no limit，1:双向持仓之多仓 2:双向持仓之空仓 3:单向持仓之多仓 4:单向持仓之空仓
        /// </summary>
        public int? Side { get; set; }

        /// <summary>
        /// 合约编码 ，不传表示查所有
        /// </summary>
        public List<string> ContractCodeList { get; set; }
    }
}
