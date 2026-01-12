using Microsoft.EntityFrameworkCore;
using Payment.Domain.Repositories;
using Payment.Entities;
using Payment.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class ProjectRepository : IProjectRepository
{
    private readonly PaymentDbContext _context;

    public ProjectRepository(PaymentDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Projects project)
    {
        await _context.Projects.AddAsync(project);
    }

    public Task UpdateAsync(Projects project)
    {
        _context.Projects.Update(project);
        return Task.CompletedTask;
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
            _context.Projects.Remove(entity);
    }

    public Task<Projects?> GetByIdAsync(Guid id)
    {
        return _context.Projects.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Projects>> GetAllAsync()
    {
        return await _context.Projects.ToListAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
