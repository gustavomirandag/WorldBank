using System;
using System.Collections.Generic;
using System.Text;
using WorldBank.Common.Domain.Interfaces.Repositories;
using WorldBank.Common.Infra.DataAccess;
using WorldBank.Microservices.TransactionMicroservice.Domain.AggregatesModel.TransactionAggregate;
using WorldBank.Microservices.TransactionMicroservice.Domain.AggregatesModel.TransferAggregate;

namespace WorldBank.Microservices.TransactionMicroservice.Infra.Repositories
{
    public class TransactionRepository : EntityFrameworkRepositoryBase<Guid,Transaction>, ITransactionRepository
    {
    }
}
