using Microsoft.EntityFrameworkCore;
using Payment.Domain.Repositories;
using Payment.Entities;
using Payment.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class OverviewRepository : IOverviewRepository
{
    private readonly PaymentDbContext _context;

    public OverviewRepository(PaymentDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Overview overview)
    {
        await _context.Overviews.AddAsync(overview);
    }

    public Task UpdateAsync(Overview overview)
    {
        _context.Overviews.Update(overview);
        return Task.CompletedTask;
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
            _context.Overviews.Remove(entity);
    }

    public Task<Overview?> GetByIdAsync(Guid id)
    {
        return _context.Overviews.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Overview>> GetAllAsync()
    {
        return await _context.Overviews.ToListAsync();
    }


    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

}

