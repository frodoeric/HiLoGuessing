using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiloGuessing.Domain.Entities;
using HiloGuessing.Domain.Interfaces;
using HiLoGuessing.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace HiLoGuessing.Infrastructure.Repositories
{
    public class MysteryNumberRepository : IRepository<HiLoGuess>
    {
        private readonly MysteryNumberDbContext _dbContext;

        public MysteryNumberRepository(MysteryNumberDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<HiLoGuess> GetByIdAsync(Guid id)
        {
            return await _dbContext.HiLoGuess.FindAsync(id);
        }

        public async Task<List<HiLoGuess>> GetAllAsync()
        {
            return await _dbContext.HiLoGuess.ToListAsync();
        }

        public async Task<HiLoGuess> AddAsync(HiLoGuess entity)
        {
            var result = await _dbContext.HiLoGuess.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task UpdateAsync(HiLoGuess entity)
        {
            _dbContext.HiLoGuess.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(HiLoGuess entity)
        {
            _dbContext.HiLoGuess.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
