using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IEntityRepository
    {
        Task<IReadOnlyList<Entity>> GetEntitiesAsync();
        Task<IReadOnlyList<Entity>> GetFullEntitiesAsync();
        Task<Entity> GetEntityByIdAsync(int id);
        Task<Entity> GetFullEntityByIdAsync(int id);
        
    }
}