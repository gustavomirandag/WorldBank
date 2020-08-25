using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldBank.Microservices.TransactionMicroservice.Domain.AggregatesModel.TransferAggregate;
using WorldBank.Microservices.WalletMicroservice.Domain.AggregatesModel.WalletAggregate;

namespace WorldBank.Microservices.TransactionMicroservice.Domain.AggregatesModel.TransactionAggregate
{
    /// <summary>
    /// Servicos de dominio
    /// </summary>
    public class TransactionService : ITransactionService
    {
        private ITransactionRepository transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            this.transactionRepository = transactionRepository;
        }

        //Servicos de Dominio
        public IEnumerable<Transaction> GetWalletStatement(Guid walletId)
        {
            var statement = new List<Transaction>();

            //########### Depósito de R$5.000 #############
            Transaction transaction = new Transaction();
            transaction.DateTime = DateTime.Now.AddDays(-5);
            transaction.Id = Guid.NewGuid();

            var action = new WalletAction();
            action.WalletId = walletId;
            action.ActionType = WalletActionType.Credit;
            action.Amount = new Amount("BRL", 5000);

            transaction.AddAction(action);
            statement.Add(transaction);
            //##############################################


            //########### Transferência Para Esta Wallet de R$2.500 #############
            transaction = new Transaction();
            transaction.DateTime = DateTime.Now.AddDays(-2);
            transaction.Id = Guid.NewGuid();

            action = new WalletAction();
            action.WalletId = Guid.NewGuid(); // input parameter
            action.ActionType = WalletActionType.Debit;
            action.Amount = new Amount("BRL", 2500);
            transaction.AddAction(action);

            action = new WalletAction();
            action.WalletId = walletId; // input parameter
            action.ActionType = WalletActionType.Credit;
            action.Amount = new Amount("BRL", 2500);
            transaction.AddAction(action);

            statement.Add(transaction);
            //##############################################


            //########### Transferência Desta Wallet para outra de R$500 #############
            transaction = new Transaction();
            transaction.DateTime = DateTime.Now.AddDays(-1);
            transaction.Id = Guid.NewGuid();

            action = new WalletAction();
            action.WalletId = walletId; // input parameter
            action.ActionType = WalletActionType.Debit;
            action.Amount = new Amount("BRL", 500);
            transaction.AddAction(action);

            action = new WalletAction();
            action.WalletId = Guid.NewGuid(); // input parameter
            action.ActionType = WalletActionType.Credit;
            action.Amount = new Amount("BRL", 500);
            transaction.AddAction(action);

            statement.Add(transaction);
            //##############################################


            return statement;
        }

        public async Task<bool> WalletDepositAsync(Guid walletId, Amount amount)
        {
            Transaction transaction = new Transaction();
            transaction.DateTime = DateTime.Now;
            transaction.Id = Guid.NewGuid();

            var action = new WalletAction();
            action.WalletId = walletId;
            action.ActionType = WalletActionType.Credit;
            action.Amount = amount;

            transaction.AddAction(action);

            await transactionRepository.CreateAsync(transaction);
            return await transactionRepository.SaveChangesAsync() > 0;
        }

        public async Task<bool> WalletTransferAsync(Guid originWalletId, Guid destinyWalletId, Amount amount)
        {
            var transaction = new Transaction();
            transaction.DateTime = DateTime.Now;
            transaction.Id = Guid.NewGuid();

            var action = new WalletAction();
            action.WalletId = originWalletId;
            action.ActionType = WalletActionType.Debit;
            action.Amount = amount;
            transaction.AddAction(action);

            action = new WalletAction();
            action.WalletId = destinyWalletId;
            action.ActionType = WalletActionType.Credit;
            action.Amount = amount;
            transaction.AddAction(action);

            await transactionRepository.CreateAsync(transaction);
            return await transactionRepository.SaveChangesAsync() > 0;
        }

        public async Task<bool> WalletWithdrawAsync(Guid walletId, Amount amount)
        {
            Transaction transaction = new Transaction();
            transaction.DateTime = DateTime.Now;
            transaction.Id = Guid.NewGuid();

            var action = new WalletAction();
            action.WalletId = walletId;
            action.ActionType = WalletActionType.Debit;
            action.Amount = amount;

            transaction.AddAction(action);

            await transactionRepository.CreateAsync(transaction);
            return await transactionRepository.SaveChangesAsync() > 0;
        }
    }
}
