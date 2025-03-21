using BankAccountAPI.Application.Interfaces;
using BankAccountAPI.Domain.Entities;


namespace BankAccountAPI.Infrastructure.Repositories
{
    public class BankAccountRepository : IBankAccountRepository
    {
        private readonly List<BankAccount> _bankAccounts = new(); // Sample in-memory data store

        public async Task<IEnumerable<BankAccount>> GetAllAsync()
        {
            return await Task.FromResult(_bankAccounts);
        }

        public async Task<BankAccount?> GetByIdAsync(Guid id)
        {
            return await Task.FromResult(_bankAccounts.Find(b => b.Id == id));
        }

        public async Task AddAsync(BankAccount bankAccount)
        {
            _bankAccounts.Add(bankAccount);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(BankAccount bankAccount)
        {
            var existingAccount = _bankAccounts.Find(b => b.Id == bankAccount.Id);
            if (existingAccount is not null)
            {
                existingAccount.Balance = bankAccount.Balance;
                existingAccount.OwnerName = bankAccount.OwnerName;
            }
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(Guid id)
        {
            _bankAccounts.RemoveAll(b => b.Id == id);
            await Task.CompletedTask;
        }
    }
}
