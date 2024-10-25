using System.Collections.Generic;
using System.Threading.Tasks;
using MicroRabbit.Banking.Data.Context;
using MicroRabbit.Banking.Domain.Interfaces;
using MicroRabbit.Banking.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace MicroRabbit.Banking.Data.Repository
{
    public class TransferLogRepository : ITransferLogRepository
    {
        private readonly BankingDbContext _dbContext;

        public TransferLogRepository(BankingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(TransferLog transferLog)
        {
            _dbContext.TransferLogs.Add(transferLog);
            _dbContext.SaveChanges();
        }

        public Task<List<TransferLog>> GetTransferLogs()
        {
            return _dbContext.TransferLogs.ToListAsync();
        }

        
    }
}