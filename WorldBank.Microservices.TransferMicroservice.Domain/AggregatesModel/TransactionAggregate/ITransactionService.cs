using System;
using System.Collections.Generic;
using System.Text;
using WorldBank.Microservices.TransactionMicroservice.Domain.AggregatesModel.TransferAggregate;

namespace WorldBank.Microservices.TransactionMicroservice.Domain.AggregatesModel.TransactionAggregate
{
    public interface ITransactionService
    {
        IEnumerable<Transaction> GetWalletStatement(Guid walletId);
    }
}
