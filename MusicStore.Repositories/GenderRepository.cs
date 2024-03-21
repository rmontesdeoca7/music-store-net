using Microsoft.EntityFrameworkCore;
using MusicStore.DataAccess;
using MusicStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Repositories
{
    public class GenderRepository : IGenderRepository
    {
        private readonly MusicStoreDbContext _context;
        public GenderRepository(MusicStoreDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Gender>> ListAsync()
        {
            return await _context.Set<Gender>()
                .Where(p => p.Status)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Gender?> GetAsync(int id)
        {
            return await _context.Set<Gender>()
                .FindAsync(id);
        }

        public async Task<int> AddAsync(Gender gender)
        {
            _context.Set<Gender>().Add(gender);
            await _context.SaveChangesAsync();
            return gender.Id;
        }

        public async Task UpdateAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var gender = await _context.Set<Gender>().FindAsync();
            if(gender != null)
            {
                gender.Status = false;
                await _context.SaveChangesAsync();
            }

        }
    }
}
