using BankAccountAPI.Application.BankAccounts.Commands;
using BankAccountAPI.Application.BankAccounts.Queries;
using BankAccountAPI.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BankAccountAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankAccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BankAccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllBankAccountsQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _mediator.Send(new GetBankAccountByIdQuery(id)));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBankAccountCommand command)
        {
            return Ok(await _mediator.Send(command));
        }   

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await _mediator.Send(new DeleteBankAccountCommand(id)));  
        }
    }   
}
