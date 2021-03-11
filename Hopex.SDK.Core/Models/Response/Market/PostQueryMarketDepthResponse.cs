using System.Collections.Generic;

namespace Hopex.SDK.Core.Models.Response.Market
{
    public class PostQueryMarketDepthResponse
    {
        /// <summary>
        /// 合约编码
        /// </summary>
        public string ContractCode { get; set; }

        /// <summary>
        /// 精度
        /// </summary>
        public string Decimalplace { get; set; }

        /// <summary>
        /// 区间
        /// </summary>
        public List<string> Intervals { get; set; }

        /// <summary>
        /// 最大卖价
        /// </summary>
        public string AsksFilter { get; set; }

        /// <summary>
        /// 卖盘
        /// </summary>
        public List<OrderBookItemViewModel> Asks { get; set; } = new List<OrderBookItemViewModel>();

        /// <summary>
        /// 最小买价
        /// </summary>
        public string BidsFilter { get; set; }

        /// <summary>
        /// 买盘
        /// </summary>
        public List<OrderBookItemViewModel> Bids { get; set; } = new List<OrderBookItemViewModel>();
    }

    public class OrderBookItemViewModel
    {
        public decimal PriceD { get; set; }

        /// <summary>
        /// 价格
        /// </summary>
        public string OrderPrice { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public long OrderQuantity { get; set; }

        public string OrderQuantityShow { get; set; }

        /// <summary>
        /// 此价格是否有用户自己的委托
        /// </summary>
        public int Exist { get; set; }
    }
}
