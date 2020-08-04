using System;
using System.Collections.Generic;
using System.Linq;
using WorldBank.Microservices.TransactionMicroservice.Domain.AggregatesModel.TransferAggregate;
using WorldBank.Microservices.WalletMicroservice.Domain.AggregatesModel.WalletAggregate;

namespace WorldBank.Microservices.TransactionMicroservice.Domain.AggregatesModel.TransactionAggregate
{
    /// <summary>
    /// Servicos de dominio
    /// </summary>
    public class TransactionService
    {
        //Servicos de Dominio
        public IEnumerable<Transaction> GetWalletStatement(Guid WalletId)
        {
            IEnumerable<Transaction> statements

            //########### Depósito de R$5.000 #############
            Transaction transaction = new Transaction();
            transaction.DateTime = DateTime.Now.AddDays(-5);
            transaction.Id = Guid.NewGuid();

            WorldBank.Microservices.TransactionMicroservice.Domain.AggregatesModel.TransactionAggregate.WalletAction action = new WorldBank.Microservices.TransactionMicroservice.Domain.AggregatesModel.TransactionAggregate.WalletAction();
            action.WalletId = WalletId; // input parameter
            action.ActionType = WalletActionType.Credit;
            action.Amount = new Amount("BRL", 5000);

            transaction.AddAction(action);

            return IEnumerable<Transaction>(transaction)
        }
    }
}
