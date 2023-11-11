using HiloGuessing.Domain.Entities;
using HiloGuessing.Domain.Interfaces;
using HiLoGuessing.Infrastructure;
using HiLoGuessing.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace HiLoGuessing.Infrastructure.Repositories
{
    public class AttemptRepository : IRepository<Attempts>
    {
        private readonly MysteryNumberDbContext _dbContext;

        public AttemptRepository(MysteryNumberDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Attempts> GetByIdAsync(Guid id)
        {
            return await _dbContext.Attempts.FindAsync(id) ??
                   throw new KeyNotFoundException($"AttemptId: {id} not found");
        }

        public async Task<List<Attempts>> GetAllAsync()
        {
            return await _dbContext.Attempts.ToListAsync();
        }

        public async Task<Attempts> AddAsync(Attempts entity)
        {
            var result = await _dbContext.Attempts.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task UpdateAsync(Attempts entity)
        {
            _dbContext.Attempts.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Attempts entity)
        {
            _dbContext.Attempts.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}