using Microsoft.EntityFrameworkCore;
using Payment.Domain.Repositories;
using Payment.Entities;
using Payment.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class WorkRepository : IWorkRepository
{
    private readonly PaymentDbContext _context;

    public WorkRepository(PaymentDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Working working)
    {
        await _context.Workings.AddAsync(working);
    }

    public Task UpdateAsync(Working working)
    {
        _context.Workings.Update(working);
        return Task.CompletedTask;
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
            _context.Workings.Remove(entity);
    }

    public Task<Working?> GetByIdAsync(Guid id)
    {
        return _context.Workings.Include(w=>w.Descriptions).FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Working>> GetAllAsync()
    {
        return await _context.Workings.Include(w=>w.Descriptions).ToListAsync();
    }


    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

}

