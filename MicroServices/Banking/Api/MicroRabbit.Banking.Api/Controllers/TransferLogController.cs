using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using MicroRabbit.Banking.Application.Interfaces;
using MicroRabbit.Banking.Application.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MicroRabbit.Banking.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransferLogController : ControllerBase
    {
        private readonly ILogger<TransferLogController> _logger;
        private readonly IMediator _mediator;
        private readonly ITransferService _transferService;
        public TransferLogController(IMediator mediator, ILogger<TransferLogController> logger, ITransferService transferService)
        {
            _mediator = mediator;
            _logger = logger;
            _transferService = transferService;
        }

        [HttpGet]
        public async Task<ActionResult<List<TransferLogViewModel>>> Get()
        {
            var results = await _transferService.GetTransferLogs();
            return Ok(results);
        }
    }
}
