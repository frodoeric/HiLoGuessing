using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiloGuessing.Domain.Interfaces;
using HiLoGuessing.Infrastructure.Context;

namespace HiLoGuessing.Infrastructure.Repositories
{
    public class MysteryNumberRepository : IMysteryNumberRepository
    {
        private readonly MysteryNumberDbContext _context;

        public MysteryNumberRepository(MysteryNumberDbContext context)
        {
            _context = context;
        }

        public async Task<MysteryNumber> CreateAsync(MysteryNumber mysteryNumber)
        {
            _context.Add(mysteryNumber);
            await _context.SaveChangesAsync();
            return mysteryNumber;
        }

        public async Task<MysteryNumber?> GetByIdAsync(Guid id)
        {
            return await _context.MysteryNumbers.FindAsync(id);
        }

        public async Task<MysteryNumber> UpdateByIdAsync(MysteryNumber mysteryNumber)
        {
            _context.Update(mysteryNumber);
            await _context.SaveChangesAsync();
            return mysteryNumber;
        }
    }
}
