using System.Collections.Generic;
using System.Threading.Tasks;
using MicroRabbit.Banking.Domain.Models;

namespace MicroRabbit.Banking.Application.Interfaces;

public interface ITransferService
{
    Task<List<TransferLog>> GetTransferLogs();
}