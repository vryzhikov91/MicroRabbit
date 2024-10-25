using System.Collections.Generic;
using MediatR;
using MicroRabbit.Banking.Application.Models;

namespace MicroRabbit.Banking.Application.Queries
{
    public class AccountQuery : IRequest<List<AccountViewModel>>
    {
    }
}