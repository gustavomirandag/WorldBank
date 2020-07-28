using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using WorldBank.Microservices.WalletMicroservice.Domain.AggregatesModel.WalletAggregate;

namespace WorldBank.Microservices.TransferMicroservice.Domain.AggregatesModel.TransactionAggregate
{
    public class Action
    {
        public Guid WalletId { get; set; }
        public Amount Amount { get; set; }
        public ActionType ActionType { get; set; }
    }
}
