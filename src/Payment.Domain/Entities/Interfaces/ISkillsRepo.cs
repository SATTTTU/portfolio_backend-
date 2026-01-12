using Payment.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Payment.Domain.Repositories
{
    public interface ISkillsRepository
    {
        Task AddAsync(Skills skill);
        Task UpdateAsync(Skills skill);
        Task DeleteAsync(Guid id);
        Task<Skills?> GetByIdAsync(Guid id);
        Task<List<Skills>> GetAllAsync();
        Task SaveChangesAsync();
    }
}
