using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmartClean.Application.DTOs;
using SmartClean.Core.Interfaces;

namespace SmartClean.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorksiteAreasController : ControllerBase
    {
        private readonly IWorksiteAreaRepository _worksiteAreaRepository;

        public WorksiteAreasController(IWorksiteAreaRepository worksiteAreaRepository)
        {
            _worksiteAreaRepository = worksiteAreaRepository;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<WorksiteAreaDto>), 200)]
        public async Task<ActionResult<IEnumerable<WorksiteAreaDto>>> GetAll()
        {
            var worksiteAreas = await _worksiteAreaRepository.GetAllAsync();
            var dtos = worksiteAreas.Select(w => new WorksiteAreaDto
            {
                Id = w.Id,
                Name = w.Name,
                Description = w.Description,
                Type = w.Type,
                Priority = w.Priority,
                IsActive = w.IsActive,
                EstimatedCleaningTimeMinutes = w.EstimatedCleaningTimeMinutes,
                RequiredStaffCount = w.RequiredStaffCount,
                CleaningInstructions = w.CleaningInstructions,
                RequiredEquipment = w.RequiredEquipment,
                RequiredSupplies = w.RequiredSupplies,
                WorksiteId = w.WorksiteId,
                DateCreated = w.DateCreated,
                DateUpdated = w.DateUpdated
            });
            return Ok(dtos);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(WorksiteAreaDto), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<WorksiteAreaDto>> GetById(string id)
        {
            var worksiteArea = await _worksiteAreaRepository.GetByIdAsync(id);
            if (worksiteArea == null)
                return NotFound();

            var dto = new WorksiteAreaDto
            {
                Id = worksiteArea.Id,
                Name = worksiteArea.Name,
                Description = worksiteArea.Description,
                Type = worksiteArea.Type,
                Priority = worksiteArea.Priority,
                IsActive = worksiteArea.IsActive,
                EstimatedCleaningTimeMinutes = worksiteArea.EstimatedCleaningTimeMinutes,
                RequiredStaffCount = worksiteArea.RequiredStaffCount,
                CleaningInstructions = worksiteArea.CleaningInstructions,
                RequiredEquipment = worksiteArea.RequiredEquipment,
                RequiredSupplies = worksiteArea.RequiredSupplies,
                WorksiteId = worksiteArea.WorksiteId,
                DateCreated = worksiteArea.DateCreated,
                DateUpdated = worksiteArea.DateUpdated
            };
            return Ok(dto);
        }

        [HttpGet("worksite/{worksiteId}")]
        [ProducesResponseType(typeof(IEnumerable<WorksiteAreaDto>), 200)]
        public async Task<ActionResult<IEnumerable<WorksiteAreaDto>>> GetByWorksite(string worksiteId)
        {
            var worksiteAreas = await _worksiteAreaRepository.GetWorksiteAreasByWorksiteAsync(worksiteId);
            var dtos = worksiteAreas.Select(w => new WorksiteAreaDto
            {
                Id = w.Id,
                Name = w.Name,
                Description = w.Description,
                Type = w.Type,
                Priority = w.Priority,
                IsActive = w.IsActive,
                EstimatedCleaningTimeMinutes = w.EstimatedCleaningTimeMinutes,
                RequiredStaffCount = w.RequiredStaffCount,
                CleaningInstructions = w.CleaningInstructions,
                RequiredEquipment = w.RequiredEquipment,
                RequiredSupplies = w.RequiredSupplies,
                WorksiteId = w.WorksiteId,
                DateCreated = w.DateCreated,
                DateUpdated = w.DateUpdated
            });
            return Ok(dtos);
        }
    }
}
