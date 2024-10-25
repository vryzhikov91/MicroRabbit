using AutoMapper;
using MicroRabbit.Banking.Application.Commands;
using MicroRabbit.Banking.Application.Models;

namespace MicroRabbit.Banking.Api.Infrastructure.Mapper
{
    public class ApiAutoMappingProfile : Profile
    {
        public ApiAutoMappingProfile()
        {
            CreateMap<TransferViewModel, CreateTransferCommand>();
            CreateMap<CreateTransferCommand, TransferViewModel>();
        }
    }
}
