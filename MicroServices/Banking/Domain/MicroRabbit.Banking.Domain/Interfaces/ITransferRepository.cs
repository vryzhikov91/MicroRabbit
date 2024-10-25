using System.Collections.Generic;
using System.Threading.Tasks;
using MicroRabbit.Banking.Domain.Models;

namespace MicroRabbit.Banking.Domain.Interfaces
{
    public interface ITransferLogRepository
    {
        Task<List<TransferLog>> GetTransferLogs();
        void Add(TransferLog transferLog);
    }
}