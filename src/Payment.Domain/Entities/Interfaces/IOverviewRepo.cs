using Payment.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payment.Domain.Repositories
{
    public interface IOverviewRepository
    {
        Task AddAsync(Overview overview);
        Task UpdateAsync(Overview overview);
        Task DeleteAsync(Guid id);
        Task<Overview?> GetByIdAsync(Guid id);
        Task<List<Overview>> GetAllAsync();
        Task SaveChangesAsync();
    }
}

