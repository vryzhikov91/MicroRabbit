using System.Threading.Tasks;
using MicroRabbit.Banking.Application.Events;
using MicroRabbit.Banking.Application.Validators.Transfer;
using MicroRabbit.Banking.Domain.Interfaces;
using MicroRabbit.Banking.Domain.Models;
using MicroRabbit.Domain.Core.Bus;

namespace MicroRabbit.Banking.Application.EventHandler
{
    public class TransferCreatedEventHandler : IEventHandler<TransferCreatedEvent>
    {
        private readonly ITransferLogRepository _transferLogRepository;
        public TransferCreatedEventHandler(ITransferLogRepository transferLogRepository)
        {
            _transferLogRepository = transferLogRepository;
        }
        public Task Handle(TransferCreatedEvent @event)
        {
            var validator = new TransferCreatedEventValidator();
            var result = validator.Validate(@event);
            if (result.IsValid)
            {
                _transferLogRepository.Add(new TransferLog()
                {
                    FromAccount = @event.FromAccount,
                    ToAccount = @event.ToAccount,
                    TransferAmount = @event.TransferAmount,
                    TimeStamps = @event.TimeStamps
                });
                return Task.FromResult(true);
            }

            return Task.FromResult(false);
        }
    }
}