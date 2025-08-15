using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmartClean.Application.DTOs;
using SmartClean.Application.Features.Worksites.Commands.CreateWorksite;
using SmartClean.Application.Features.Worksites.Commands.DeleteWorksite;
using SmartClean.Application.Features.Worksites.Commands.UpdateWorksite;
using SmartClean.Application.Features.Worksites.Queries.GetAllWorksites;
using SmartClean.Application.Features.Worksites.Queries.GetWorksiteById;

namespace SmartClean.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorksitesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WorksitesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<WorksiteDto>), 200)]
        public async Task<ActionResult<IEnumerable<WorksiteDto>>> GetAll()
        {
            var query = new GetAllWorksitesQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(WorksiteDto), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<WorksiteDto>> GetById(string id)
        {
            var query = new GetWorksiteByIdQuery { Id = id };
            var result = await _mediator.Send(query);
            
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(WorksiteDto), 201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<WorksiteDto>> Create([FromBody] CreateWorksiteDto createWorksiteDto)
        {
            var command = new CreateWorksiteCommand { Worksite = createWorksiteDto };
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(WorksiteDto), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<WorksiteDto>> Update(string id, [FromBody] UpdateWorksiteDto updateWorksiteDto)
        {
            updateWorksiteDto.Id = id;
            var command = new UpdateWorksiteCommand { Worksite = updateWorksiteDto };
            var result = await _mediator.Send(command);
            
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> Delete(string id)
        {
            var command = new DeleteWorksiteCommand { Id = id };
            var result = await _mediator.Send(command);
            
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
