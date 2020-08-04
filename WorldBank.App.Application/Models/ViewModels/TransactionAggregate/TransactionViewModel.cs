using System;
using System.Collections.Generic;

namespace WorldBank.App.Application.Models.ViewModels.TransactionAggregate
{
    public class TransactionViewModel
    {
        public Guid Id { get; set; }
        public DateTime DateTime { get; set; }
        public IEnumerable<WalletActionViewModel> Action { get; set; }
    }
}
