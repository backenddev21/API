using BankAccountAPI.Application.Interfaces;
using BankAccountAPI.Domain.Entities;
using MediatR;

namespace BankAccountAPI.Application.Queries
{
    public class GetAllBankAccountsQuery : IRequest<IEnumerable<BankAccount>> { }

    public class GetAllBankAccountsHandler : IRequestHandler<GetAllBankAccountsQuery, IEnumerable<BankAccount>>
    {
        private readonly IBankAccountRepository _repository;

        public GetAllBankAccountsHandler(IBankAccountRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<BankAccount>> Handle(GetAllBankAccountsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    } 
}