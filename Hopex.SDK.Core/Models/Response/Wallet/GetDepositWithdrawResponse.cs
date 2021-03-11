using System;

namespace Hopex.SDK.Core.Models.Response.Wallet
{
    public class GetDepositWithdrawResponse
    {
        public int Id { get; set; }

        /// <summary>
        /// 币种
        /// </summary>
        public string Asset { get; set; }

        /// <summary>
        /// 交易类型(1 OTC入金，2 OTC出金，3 链上入金，4 链上出金，5 内部转账-入金，6 内部转账-出金, 7 人工入金, 8 人工出金,9 快速入金,10 快速出金)
        /// </summary>
        public int OrderType { get; set; }

        /// <summary>
        /// 交易类型描述
        /// </summary>
        public string OrderTypeD { get; set; }


        /// <summary>
        /// 数字货币金额
        /// </summary>
        public string Amount { get; set; }

        /// <summary>
        /// 人民币金额
        /// </summary>
        public string RMBAmount { get; set; }

        ///// <summary>
        ///// 手续费
        ///// </summary>
        //public string Commission { get; set; }

        /// <summary>
        /// 银行名
        /// </summary>
        public string BankName { get; set; }

        /// <summary>
        /// 钱包地址
        /// </summary>
        public string Addr { get; set; }

        /// <summary>
        /// 交易状态(0 进行中，1 完成，2失败）
        /// </summary>
        public int OrderStatus { get; set; }

        /// <summary>
        /// 交易状态描述
        /// </summary>
        public string OrderStatusD { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedTime { get; set; }
    }
}
