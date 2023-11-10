using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiloGuessing.Domain.Interfaces;
using HiLoGuessing.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace HiLoGuessing.Infrastructure.Repositories
{
    public class MysteryNumberRepository : IRepository<MysteryNumber>
    {
        private readonly MysteryNumberDbContext _dbContext;

        public MysteryNumberRepository(MysteryNumberDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<MysteryNumber> GetByIdAsync(int id)
        {
            return await _dbContext.MysteryNumbers.FindAsync(id);
        }

        public async Task<List<MysteryNumber>> GetAllAsync()
        {
            return await _dbContext.MysteryNumbers.ToListAsync();
        }

        public async Task AddAsync(MysteryNumber entity)
        {
            await _dbContext.MysteryNumbers.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(MysteryNumber entity)
        {
            _dbContext.MysteryNumbers.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(MysteryNumber entity)
        {
            _dbContext.MysteryNumbers.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
