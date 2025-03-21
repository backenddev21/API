using MediatR;
using System;
using BankAccountAPI.Application.Interfaces;

namespace BankAccountAPI.Application.BankAccounts.Commands
{
    public class DeleteBankAccountCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }

        public DeleteBankAccountCommand(Guid id)
        {
            Id = id;
        }
    }

    public class DeleteBankAccountCommandHandler : IRequestHandler<DeleteBankAccountCommand, Unit>
    {
        private readonly IBankAccountRepository _repository;

        public DeleteBankAccountCommandHandler(IBankAccountRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteBankAccountCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.Id);
            return Unit.Value; // ✅ MediatR requires returning Unit.Value
        }
    }
}
