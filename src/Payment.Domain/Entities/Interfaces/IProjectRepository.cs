using Payment.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Payment.Domain.Repositories
{
    public interface IProjectRepository
    {
        Task AddAsync(Projects project);
        Task UpdateAsync(Projects project);
        Task DeleteAsync(Guid id);
        Task<Projects?> GetByIdAsync(Guid id);
        Task<List<Projects>> GetAllAsync();
        Task SaveChangesAsync();
    }
}
