using BankAccountAPI.Application.Interfaces;
using BankAccountAPI.Domain.Entities;
using MediatR;

namespace BankAccountAPI.Application.BankAccounts.Commands
{
    public class CreateBankAccountCommand : IRequest<BankAccount>
    {
        public string AccountNumber { get; set; } = string.Empty;
        public string OwnerName { get; set; } = string.Empty;
        public decimal Balance { get; set; }
    }

    public class CreateBankAccountHandler : IRequestHandler<CreateBankAccountCommand, BankAccount>
    {
        private readonly IBankAccountRepository _repository;

        public CreateBankAccountHandler(IBankAccountRepository repository)
        {
            _repository = repository;
        }

        public async Task<BankAccount> Handle(CreateBankAccountCommand request, CancellationToken cancellationToken)
        {
            var account = new BankAccount
            {
                Id = Guid.NewGuid(),
                AccountNumber = request.AccountNumber,
                OwnerName = request.OwnerName,
                Balance = request.Balance
            };

            await _repository.AddAsync(account);
            return account;
        }
    }
}
