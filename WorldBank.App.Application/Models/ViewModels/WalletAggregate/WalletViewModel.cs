using System;

namespace WorldBank.App.Application.Models.ViewModels.WalletAggregate
{
    public class WalletViewModel
    {
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public AmountViewModel Amount { get; set; }
    }
}
