using System;
using System.Collections.Generic;
using System.Text;

namespace WorldBank.Microservices.TransferMicroservice.Domain.AggregatesModel.TransactionAggregate
{
    public enum ActionType
    {
        Credit,
        Debit
    }
}
