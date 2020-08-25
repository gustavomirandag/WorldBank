using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace WorldBank.Microservices.TransactionMicroservice.Infra.Contexts
{
    public class TransactionContext : DbContext
    {
        public DbSet<Transaction> Transactions { get; set; }

        public TransactionContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=tcp:worldbank-gustavo-db-server.database.windows.net,1433;Initial Catalog=WorldBank-gustavo-Db;Persist Security Info=False;User ID=pivotto;Password=@dsInf123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
    }
}
