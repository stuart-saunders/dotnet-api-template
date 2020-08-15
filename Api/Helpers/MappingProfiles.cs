using AutoMapper;
using Core.Dtos;
using Core.Entities;

namespace Api.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Entity, EntityDto>()
                .ForMember(d => d.RelatedEntity, o => o.MapFrom(s => s.RelatedEntity.Name));

            CreateMap<RelatedEntity, RelatedEntityDto>();
        }
    }
}