using System.Collections.Generic;

namespace Hopex.SDK.Core.Models.Response.Wallet
{
    public class GetUserWalletResponse
    {
        /// <summary>
        /// 概况
        /// </summary>
        public AllAssetSummaryViewModel Summary { get; set; } = new AllAssetSummaryViewModel();

        /// <summary>
        /// 各个资产的概况
        /// </summary>
        public List<AssetSummaryViewModel> Detail { get; set; } = new List<AssetSummaryViewModel>();
    }

    public class AllAssetSummaryViewModel
    {
        /// <summary>
        /// 计价货币
        /// </summary>
        public string ConversionCurrency { get; set; }

        /// <summary>
        /// 总权益
        /// </summary>
        public string TotalWealth { get; set; }

        /// <summary>
        /// 浮动盈亏
        /// </summary>
        public string FloatProfit { get; set; }

        /// <summary>
        /// 总可用余额
        /// </summary>
        public string AvailableBalance { get; set; }
    }

    public class AssetSummaryViewModel
    {
        /// <summary>
        /// 货币
        /// </summary>
        public string AssetName { get; set; }

        /// <summary>
        /// 货币logo
        /// </summary>
        public string AssetLogoUrl { get; set; }

        /// <summary>
        /// 浮动盈亏
        /// </summary>
        public string FloatProfit { get; set; }

        /// <summary>
        /// 浮动盈亏-法币
        /// </summary>
        public string FloatProfitLegal { get; set; }

        /// <summary>
        /// 收益率 (+3.20%)
        /// </summary>
        public string ProfitRate { get; set; } = "0.00%";

        /// <summary>
        /// 总权益
        /// </summary>
        public string TotalWealth { get; set; }

        /// <summary>
        /// 总收益-法币
        /// </summary>
        public string TotalWealthLegal { get; set; }

        /// <summary>
        /// 总权益-解释
        /// </summary>
        public string TotalWealthInfo { get; set; }

        /// <summary>
        /// 可用余额
        /// </summary>
        public string AvailableBalance { get; set; }

        /// <summary>
        /// 可用余额-法币
        /// </summary>
        public string AvailableBalanceLegal { get; set; }

        /// <summary>
        /// 可用余额-解释
        /// </summary>
        public string AvailableBalanceInfo { get; set; }

        /// <summary>
        /// 钱包余额
        /// </summary>
        public string WalletBalance { get; set; }

        /// <summary>
        /// 钱包余额-法币
        /// </summary>
        public string WalletBalanceLegal { get; set; }

        /// <summary>
        /// 钱包余额-解释
        /// </summary>
        public string WalletBalanceInfo { get; set; }

        /// <summary>
        /// 持仓保证金
        /// </summary>
        public string PositionMargin { get; set; }

        /// <summary>
        /// 持仓保证金-法币
        /// </summary>
        public string PositionMarginLegal { get; set; }

        /// <summary>
        /// 委托占用保证金
        /// </summary>
        public string DelegateMargin { get; set; }

        /// <summary>
        /// 委托占用保证金-法币
        /// </summary>
        public string DelegateMarginLegal { get; set; }

        /// <summary>
        /// 提现冻结保证金
        /// </summary>
        public string WithdrawFreeze { get; set; }

        /// <summary>
        /// 提现冻结保证金-法币
        /// </summary>
        public string WithdrawFreezeLegal { get; set; }

        /// <summary>
        /// 入金
        /// </summary>
        public string DepositAmount { get; set; }
        /// <summary>
        /// 入金-法币
        /// </summary>
        public string DepositAmountLegal { get; set; }
        /// <summary>
        /// 出金
        /// </summary>
        public string WithdrawAmount { get; set; }
        /// <summary>
        /// 出金-法币
        /// </summary>
        public string WithdrawAmountLegal { get; set; }

    }
}
