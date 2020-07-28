using System;
using System.Collections.Generic;
using System.Text;
using WorldBank.Microservices.WalletMicroservice.Domain.AggregatesModel.WalletAggregate;

namespace WorldBank.Microservices.TransferMicroservice.Domain.AggregatesModel.TransferAggregate
{
    public abstract class Transaction
    {
        public Guid Id { get; set; }
        public DateTime DateTime { get; set; }
        public IEnumerable<Action> Action { get; set; }
    }
}
