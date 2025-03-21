using BankAccountAPI.Application.Interfaces;
using MediatR;

namespace BankAccountAPI.Application.BankAccounts.Commands
{
    public class UpdateBankAccountCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string OwnerName { get; set; } = string.Empty;
        public decimal Balance { get; set; }
    }

    public class UpdateBankAccountHandler : IRequestHandler<UpdateBankAccountCommand, bool>
    {
        private readonly IBankAccountRepository _repository;

        public UpdateBankAccountHandler(IBankAccountRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(UpdateBankAccountCommand request, CancellationToken cancellationToken)
        {
            var account = await _repository.GetByIdAsync(request.Id);
            if (account == null) return false;

            account.OwnerName = request.OwnerName;
            account.Balance = request.Balance;
            await _repository.UpdateAsync(account);

            return true;
        }
    }
}
