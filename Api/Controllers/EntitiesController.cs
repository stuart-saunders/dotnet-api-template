using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Errors;
using AutoMapper;
using Core.Dtos;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EntityDto>> GetEntity(int id)
        {
            var entity = await _entityRepository.GetFullEntityByIdAsync(id);

            if (entity == null)
            {
                return NotFound(new ApiResponse(StatusCodes.Status404NotFound));
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