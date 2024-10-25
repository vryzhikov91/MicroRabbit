using System.Collections.Generic;
using System.Threading.Tasks;
using MicroRabbit.Banking.Application.Interfaces;
using MicroRabbit.Banking.Domain.Interfaces;
using MicroRabbit.Banking.Domain.Models;
using MicroRabbit.Domain.Core.Bus;

namespace MicroRabbit.Banking.Application.Services
{
    public class TransferService : ITransferService
    {
        private readonly IEventBus _bus;
        private readonly ITransferLogRepository _transferLogRepository;

        public TransferService(IEventBus bus, ITransferLogRepository transferLogRepository)
        {
            _bus = bus;
            _transferLogRepository = transferLogRepository;
        }

        public async Task<List<TransferLog>> GetTransferLogs()
        {
            return await _transferLogRepository.GetTransferLogs();
        }
    }
}