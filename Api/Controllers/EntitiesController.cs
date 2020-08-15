using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Errors;
using AutoMapper;
using Core.Dtos;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EntitiesController : ControllerBase
    {
        private readonly IEntityRepository _entityRepository;
        private readonly IRelatedEntityRepository _relatedEntityRepository;
        private readonly IMapper _mapper;

        public EntitiesController(
            IEntityRepository entityRepository, 
            IRelatedEntityRepository relatedEntityRepository,
            IMapper mapper
        )
        {
            _entityRepository = entityRepository;
            _relatedEntityRepository = relatedEntityRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<EntityDto>>> GetEntities()
        {
            var entities = await _entityRepository.GetFullEntitiesAsync();
            return Ok(_mapper.Map<IReadOnlyList<Entity>, IReadOnlyList<EntityDto>>(entities));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EntityDto>> GetEntity(int id)
        {
            var entity = await _entityRepository.GetFullEntityByIdAsync(id);

            if (entity == null)
            {
                return NotFound(new ApiResponse(404));
            }

            return Ok(_mapper.Map<Entity, EntityDto>(entity));
        }

        [HttpGet("related")]
        public async Task<ActionResult<IReadOnlyList<RelatedEntityDto>>> GetRelatedEntities()
        {
            var relatedEntities = await _relatedEntityRepository.GetRelatedEntitiesAsync();
            return Ok(_mapper.Map<IReadOnlyList<RelatedEntity>, IReadOnlyList<RelatedEntityDto>>(relatedEntities));
        }
    }
}