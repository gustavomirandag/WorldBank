using System;
using System.Collections.Generic;
using System.Linq;
using WorldBank.Common.Domain.Entities;
using WorldBank.Microservices.TransactionMicroservice.Domain.AggregatesModel.TransactionAggregate;

namespace WorldBank.Microservices.TransactionMicroservice.Domain.AggregatesModel.TransferAggregate
{
    public class Transaction : EntityBase<Guid>
    {
        public DateTime DateTime { get; set; }
        public ICollection<WalletAction> Actions { get; set; }

        public Transaction()
        {
            Actions = new List<WalletAction>();
        }

        public void AddAction(WalletAction action)
        {
            Actions.Add(action);
        }
    }
}
