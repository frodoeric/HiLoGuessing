using HiloGuessing.Domain.Interfaces;
using HiLoGuessing.Infrastructure;
using HiLoGuessing.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace HiLoGuessing.Infrastructure.Repositories
{
    public class AttemptRepository : IRepository<Attempt>
    {
        private readonly MysteryNumberDbContext _dbContext;

        public AttemptRepository(MysteryNumberDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Attempt> GetByIdAsync(Guid id)
        {
            return await _dbContext.Attempts.FindAsync(id) ??
                   throw new KeyNotFoundException($"AttemptId: {id} not found");
        }

        public async Task<List<Attempt>> GetAllAsync()
        {
            return await _dbContext.Attempts.ToListAsync();
        }

        public async Task<Attempt> AddAsync(Attempt entity)
        {
            var result = await _dbContext.Attempts.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task UpdateAsync(Attempt entity)
        {
            _dbContext.Attempts.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Attempt entity)
        {
            _dbContext.Attempts.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}