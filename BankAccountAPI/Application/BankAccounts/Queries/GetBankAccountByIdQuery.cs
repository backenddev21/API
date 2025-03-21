using BankAccountAPI.Application.Interfaces;
using BankAccountAPI.Domain.Entities;
using MediatR;

namespace BankAccountAPI.Application.BankAccounts.Queries
{
    public class GetBankAccountByIdQuery : IRequest<BankAccount?>
    {
        public Guid Id { get; set; }
        public GetBankAccountByIdQuery(Guid id) => Id = id;
    }

    public class GetBankAccountByIdHandler : IRequestHandler<GetBankAccountByIdQuery, BankAccount?>
    {
        private readonly IBankAccountRepository _repository;

        public GetBankAccountByIdHandler(IBankAccountRepository repository)
        {
            _repository = repository;
        }

        public async Task<BankAccount?> Handle(GetBankAccountByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetByIdAsync(request.Id);
        }
    }
}
