using System;
using System.Collections.Generic;
using System.Text;

namespace WorldBank.Microservices.WalletMicroservice.Domain.AggregatesModel.WalletAggregate
{
    public class Wallet
    {
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public Amount Amount { get; set; }
        public WalletType WalletType { get; set; }
    }
}
