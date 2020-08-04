using System;
using WorldBank.App.Application.Models.ViewModels.WalletAggregate;

namespace WorldBank.App.Application.Models.ViewModels.TransactionAggregate
{
    public class WalletAction
    {
        public Guid WalletId { get; set; }
        public AmountViewModel Amount { get; set; }
        public WalletActionTypeViewModel ActionType { get; set; }
    }
}
