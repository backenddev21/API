using BankAccountAPI.Domain.Entities;
namespace BankAccountAPI.Application.Interfaces
{
    public interface IBankAccountRepository
    {
        Task<IEnumerable<BankAccount>> GetAllAsync();
        Task<BankAccount?> GetByIdAsync(Guid id);
        Task AddAsync(BankAccount account);
        Task UpdateAsync(BankAccount account);
        Task DeleteAsync(Guid id);
    }
}