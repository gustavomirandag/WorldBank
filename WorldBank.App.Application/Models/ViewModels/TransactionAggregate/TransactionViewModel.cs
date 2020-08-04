using System;
using System.Collections.Generic;

namespace WorldBank.App.Application.Models.ViewModels.TransactionAggregate
{
    public abstract class TransactionViewModel
    {
        public Guid Id { get; set; }
        public DateTime DateTime { get; set; }
        public IEnumerable<ActionViewModel> Action { get; set; }
    }
}
