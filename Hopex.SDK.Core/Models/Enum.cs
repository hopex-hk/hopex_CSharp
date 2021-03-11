using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hopex.SDK.Core.Models
{
    public class CandlestickInterval
    {
        public static string MIN1 { get; set; } = "1m";

        public static string MIN5 { get; set; } = "5m";

        public static string HOUR1 { get; set; } = "1h";

        public static string DAY1 { get; set; } = "1d";

        public static string MON1 { get; set; } = "1M";

        public static string WEEK1 { get; set; } = "1w";
    }

    public enum Direct
    {
        /// <summary>
        /// 多仓
        /// </summary>
        Long = 1,

        /// <summary>
        /// 空仓
        /// </summary>
        Short = 2
    }

    public enum OrderTradeType
    {
        /// <summary>
        /// 买入开多
        /// </summary>
        BuyLong =1,

        /// <summary>
        /// 卖出开空
        /// </summary>
        SellShort = 2,

        /// <summary>
        /// 买入平空
        /// </summary>
        BuyToCloseShort =3,

        /// <summary>
        /// 卖出平多
        /// </summary>
        SellToCloseLong = 4
    }

    public enum OrderType
    {
        /// <summary>
        /// 限价单
        /// </summary>
        Limit,

        /// <summary>
        /// 市价单
        /// </summary>
        Market
    }

    public enum OrderSide
    {
        /// <summary>
        /// 卖
        /// </summary>
        Sell = 1,

        /// <summary>
        /// 买
        /// </summary>
        Buy = 2
    }
}
