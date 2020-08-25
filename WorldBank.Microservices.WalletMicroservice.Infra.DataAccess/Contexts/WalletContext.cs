using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WorldBank.Microservices.WalletMicroservice.Domain.AggregatesModel.WalletAggregate;
using WorldBank.Microservices.WalletMicroservice.Infra.DataAccess.Model;

namespace WorldBank.Microservices.WalletMicroservice.Infra.DataAccess.Contexts
{
    public class WalletContext : DbContext
    {
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<DbCurrency> Currencies { get; set; }

        public WalletContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=tcp:worldbank-gustavo-db-server.database.windows.net,1433;Initial Catalog=WorldBank-gustavo-Db;Persist Security Info=False;User ID=pivotto;Password=@dsInf123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder
                .Entity<Wallet>()
                .Property(account => account.Amount)
                .HasConversion(
                amount => amount.ToString(),
                amount => Amount.Parse(amount))
                .HasColumnName("Amount");

            modelBuilder
                .Entity<DbCurrency>()
                .Property(dbCurrency => dbCurrency.Currency)
                .HasConversion(
                    currency => currency.ToString(),
                    currency => new Currency(currency))
                .HasColumnName("Currency");
        }
    }
}
