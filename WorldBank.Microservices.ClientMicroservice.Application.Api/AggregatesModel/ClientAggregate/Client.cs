using System;
using System.Collections.Generic;
using System.Text;

namespace WorldBank.Microservices.ClientMicroservice.Application.Domain.AggregatesModel.ClientAggregate
{
    public abstract class Client
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
