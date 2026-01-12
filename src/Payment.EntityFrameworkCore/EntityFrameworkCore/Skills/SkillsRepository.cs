using Microsoft.EntityFrameworkCore;
using Payment.Domain.Repositories;
using Payment.Entities;
using Payment.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class SkillsRepository : ISkillsRepository
{
        private readonly PaymentDbContext _context;

        public SkillsRepository(PaymentDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Skills skill)
        {
            await _context.Skills.AddAsync(skill);
        }

        public Task UpdateAsync(Skills skill)
        {
            _context.Skills.Update(skill);
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
                _context.Skills.Remove(entity);
        }

        public Task<Skills?> GetByIdAsync(Guid id)
        {
            return _context.Skills.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Payment.Entities.Skills>> GetAllAsync()
        {
            return await _context.Skills.ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }

