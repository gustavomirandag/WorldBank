using System;
using System.Collections.Generic;
using System.Text;
using WorldBank.Microservices.WalletMicroservice.Domain.AggregatesModel.WalletAggregate;

namespace WorldBank.Microservices.WalletMicroservice.Infra.DataAccess.Model
{
    public class DbCurrency
    {
        public Guid Id { get; set; }
        public Currency Currency { get; set; }
    }
}
