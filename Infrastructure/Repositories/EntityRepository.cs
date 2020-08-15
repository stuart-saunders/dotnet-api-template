using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class EntityRepository : IEntityRepository
    {
        private readonly ApplicationDbContext _context;

        public EntityRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<Entity>> GetEntitiesAsync()
        {
            return await _context.Entities.ToListAsync();
        }

        public async Task<IReadOnlyList<Entity>> GetFullEntitiesAsync()
        {
            return await _context.Entities
                .Include(e => e.RelatedEntity)
                .ToListAsync();
        }

        public async Task<Entity> GetEntityByIdAsync(int id)
        {
            return await _context.Entities.FindAsync(id);
        }

        public async Task<Entity> GetFullEntityByIdAsync(int id)
        {
            return await _context.Entities
                .Include(e => e.RelatedEntity)
                .FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}