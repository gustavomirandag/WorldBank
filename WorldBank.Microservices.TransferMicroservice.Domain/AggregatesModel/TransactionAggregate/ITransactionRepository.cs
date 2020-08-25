using System;
using System.Collections.Generic;
using System.Text;
using WorldBank.Common.Domain.Interfaces.Repositories;
using WorldBank.Microservices.TransactionMicroservice.Domain.AggregatesModel.TransferAggregate;

namespace WorldBank.Microservices.TransactionMicroservice.Domain.AggregatesModel.TransactionAggregate
{
    public interface ITransactionRepository : IRepository<Guid,Transaction>
    {
    }
}
