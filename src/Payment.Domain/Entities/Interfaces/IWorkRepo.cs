using Payment.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payment.Domain.Repositories
{
    public interface IWorkRepository
    {
        Task AddAsync(Working working);
        Task UpdateAsync(Working working);
        Task DeleteAsync(Guid id);
        Task<Working?> GetByIdAsync(Guid id);
        Task<List<Working>> GetAllAsync();
        Task SaveChangesAsync();
    }
}

