using System.Collections.Generic;

namespace Hopex.SDK.Core.Models.Response.Market
{
    public class GetKlineResponse
    {
        /// <summary>
        /// 小数点位数
        /// </summary>
        public string Decimalplace { get; set; }

        /// <summary>
        /// 数据
        /// </summary>
        public List<KLineItemViewModel> TimeData { get; set; }
    }

    public class KLineItemViewModel
    {
        /// <summary>
        /// 时间戳
        /// </summary>
        public long Time { get; set; }
        /// <summary>
        /// 开市值
        /// </summary>
        public string Open { get; set; }
        /// <summary>
        /// 闭市值
        /// </summary>
        public string Close { get; set; }
        /// <summary>
        /// 最高价
        /// </summary>
        public string High { get; set; }
        /// <summary>
        /// 最低价
        /// </summary>
        public string Low { get; set; }
        /// <summary>
        /// 成交量
        /// </summary>
        public string Vol { get; set; }
        /// <summary>
        /// 成交额
        /// </summary>
        public string Val { get; set; }
        /// <summary>
        /// 上一笔的闭市价
        /// </summary>
        public string PrevClose { get; set; }
        /// <summary>
        /// 涨跌额
        /// </summary>
        public string UpDown { get; set; }
        /// <summary>
        /// 涨跌率
        /// </summary>
        public string UpDownRate { get; set; }

        /// <summary>
        /// 合约方向
        /// </summary>
        public int Direct { get; set; }

        /// <summary>
        /// 合约价值
        /// </summary>
        public string ContractValue { get; set; }
    }
}
