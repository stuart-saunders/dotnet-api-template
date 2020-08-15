using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IRelatedEntityRepository
    {
        Task<IReadOnlyList<RelatedEntity>> GetRelatedEntitiesAsync();
        Task<RelatedEntity> GetRelatedEntityByIdAsync(int id);
    }
}