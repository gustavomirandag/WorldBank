using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorldBank.Microservices.TransactionMicroservice.Domain.AggregatesModel.TransferAggregate;
using WorldBank.Microservices.WalletMicroservice.Domain.AggregatesModel.WalletAggregate;

namespace WorldBank.Microservices.TransactionMicroservice.Domain.AggregatesModel.TransactionAggregate
{
    public interface ITransactionService
    {
        Task<bool> WalletDepositAsync(Guid walletId, Amount amount);
        Task<bool> WalletWithdrawAsync(Guid walletId, Amount amount);
        Task<bool> WalletTransferAsync(Guid originWalletId, Guid destinyWalletId, Amount amount);
        IEnumerable<Transaction> GetWalletStatement(Guid walletId);
    }
}
