using BankAccountAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankAccountAPI.Application.Interfaces
{
    public interface IBankAccountRepository
    {
        Task<IEnumerable<BankAccount>> GetAllAsync();
        Task<BankAccount?> GetByIdAsync(Guid id);
        Task AddAsync(BankAccount bankAccount);
        Task UpdateAsync(BankAccount bankAccount);
        Task DeleteAsync(Guid id);
    }
}
