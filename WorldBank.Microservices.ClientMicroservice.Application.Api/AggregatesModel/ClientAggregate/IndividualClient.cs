using System;
using System.Collections.Generic;
using System.Text;

namespace WorldBank.Microservices.ClientMicroservice.Application.Domain.AggregatesModel.ClientAggregate
{
    public class IndividualClient : Client
    {
        public string CPF { get; set; }
    }
}
