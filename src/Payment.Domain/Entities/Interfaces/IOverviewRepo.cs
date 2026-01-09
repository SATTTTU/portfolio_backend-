using Payment.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payment.Domain.Repositories
{
    public interface IOverviewRepository
    {
        Task AddAsync(Overviews overview);
        Task UpdateAsync(Overviews overview);
        Task DeleteAsync(Guid id);
        Task<Overviews> GetByIdAsync(Guid id);
        Task<IQueryable<Overviews>> GetAllAsync();
        Task SaveChangesAsync();
    }
}
