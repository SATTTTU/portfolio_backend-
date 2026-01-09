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

    public async Task AddAsync(Overviews overview)
    {
        await _context.Overviews.AddAsync(overview);
    }

    public Task UpdateAsync(Overviews overview)
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

    public Task<Overviews?> GetByIdAsync(Guid id)
    {
        return _context.Overviews.FirstOrDefaultAsync(x => x.Id == id);
    }

    public Task<IQueryable<Overviews>> GetAllAsync()
    {
       var overviews =  _context.Overviews.AsQueryable();
        return Task.FromResult(overviews);
    }


    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

}
