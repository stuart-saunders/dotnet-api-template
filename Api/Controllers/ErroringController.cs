using Api.Errors;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErroringController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ErroringController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(StatusCodes.Status400BadRequest));
        }

        [HttpGet("notfound")]
        public ActionResult GetNotFoundRequest()
        {
            var entity = _context.Entities.Find(99);

            if (entity == null) 
            {
                return NotFound(new ApiResponse(StatusCodes.Status404NotFound));
            }

            return Ok();
        }

        [HttpGet("servererror")]
        public ActionResult GetServerError()
        {
            var entity = _context.Entities.Find(99);
            var str = entity.ToString();

            return Ok();
        }
    }
}