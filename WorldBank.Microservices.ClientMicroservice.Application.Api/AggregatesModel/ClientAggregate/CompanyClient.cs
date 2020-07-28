using System;
using System.Collections.Generic;
using System.Text;

namespace WorldBank.Microservices.ClientMicroservice.Application.Domain.AggregatesModel.ClientAggregate
{
    public class CompanyClient : Client
    {
        public string CNPJ { get; set; }
    }
}
