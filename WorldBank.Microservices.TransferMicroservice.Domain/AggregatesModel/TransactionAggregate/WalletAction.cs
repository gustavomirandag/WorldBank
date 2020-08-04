using System;
using WorldBank.Microservices.WalletMicroservice.Domain.AggregatesModel.WalletAggregate;

namespace WorldBank.Microservices.TransactionMicroservice.Domain.AggregatesModel.TransactionAggregate
{
    public class WalletAction
    {
        public Guid WalletId { get; set; }
        public Amount Amount { get; set; }
        public WalletActionType ActionType { get; set; }
    }
}
