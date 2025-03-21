using BankAccountAPI.Application.Interfaces;
using BankAccountAPI.Domain.Entities;

namespace BankAccountAPI.Infrastructure.Repositories
{
    public class BankAccountRepository : IBankAccountRepository
    {
        private readonly List<BankAccount> _accounts = new();
    }

    public async Task<BankAccount?> GetByIdAsync(Guid id)
    {
        return await Task.FromResult(_accounts.FirstOrDefault(a => a.Id == id));
    }

    public async Task AddAsync(BankAccount account)
    {
        _accounts.Add(account);
        await Task.CompletedTask;
    }

    public async Task UpdateAsync(BankAccount account)
    {
        var existingAccount = await GetByIdAsync(account.Id);
        if (existingAccount != null)
        {
            existingAccount.OwnerName = account.OwnerName;
            existingAccount.Balance = account.Balance;
        }
        await Task.CompletedTask;
    }

    public async Task DeleteAsync(Guid id)
    {
        var account = await GetByIdAsync(id);
        if (account != null)
        {
            _accounts.Remove(account);
        }
        await Task.CompletedTask;
    }
}