using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class RelatedEntityRepository : IRelatedEntityRepository
    {
        private readonly ApplicationDbContext _context;

        public RelatedEntityRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<RelatedEntity>> GetRelatedEntitiesAsync()
        {
            return await _context.RelatedEntities.ToListAsync();
        }

        public async Task<RelatedEntity> GetRelatedEntityByIdAsync(int id)
        {
            return await _context.RelatedEntities.FindAsync(id);
        }
    }
}