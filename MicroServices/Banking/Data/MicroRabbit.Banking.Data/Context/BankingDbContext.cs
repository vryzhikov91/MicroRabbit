using MicroRabbit.Banking.Data.EntityConfigurations;
using MicroRabbit.Banking.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace MicroRabbit.Banking.Data.Context
{
    public class BankingDbContext : DbContext
    {
        public const string DefaultSchema = "dbo";
        public BankingDbContext(DbContextOptions options) : base(options)
        {
        }
        
        public DbSet<Account> Accounts { get; set; }
        public DbSet<TransferLog> TransferLogs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(new AccountEntityTypeConfiguration().GetType().Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(new TransferLogEntityTypeConfiguration().GetType().Assembly);
        }
    }
}