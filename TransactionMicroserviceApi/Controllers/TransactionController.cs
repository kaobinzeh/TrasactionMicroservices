using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransactionMicroserviceApi.Dispatchers;
using TransactionMicroserviceApi.Dtos;
using TransactionMicroserviceApi.Messages.Commands;

namespace TransactionMicroserviceApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly IDispatcher _dispatcher;

        public TransactionController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        [HttpPost]
        public async Task<IActionResult> Post(UpdateTransaction command)
        {
            await _dispatcher.SendAsync(command);

            return Accepted();
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<TransactionDto>> Get(GetTransaction trans)
        {
            var transaction = await _dispatcher.QueryAsync(trans);
            if (transaction is null)
            {
                return NotFound();
            }

            return transaction;
        }
    }
}
