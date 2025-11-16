using api.DTOs.Incident;
using api.DTOs.Alert;
using api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IncidentsController : ControllerBase
    {
        private readonly IIncidentService _incidentService;

        public IncidentsController(IIncidentService incidentService)
        {
            _incidentService = incidentService;
        }

        // GET api/incidents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IncidentDto>>> GetAll()
        {
            var incidents = await _incidentService.GetAllAsync();
            return Ok(incidents);
        }

        // GET api/incidents/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<IncidentDto>> GetById(int id)
        {
            var incident = await _incidentService.GetByIdAsync(id);
            if (incident == null) return NotFound();
            return Ok(incident);
        }

        // POST api/incidents/from-alert
        [HttpPost("from-alert")]
        public async Task<ActionResult<IncidentDto>> CreateFromAlert(CreateIncidentFromAlertDto dto)
        {
            var incident = await _incidentService.CreateFromAlertAsync(dto);
            return Ok(incident);
        }

        // PUT api/incidents/{id}/status?status=Resolved
        [HttpPut("{id:int}/status")]
        public async Task<IActionResult> UpdateStatus(int id, [FromQuery] string status)
        {
            var success = await _incidentService.UpdateStatusAsync(id, status);
            if (!success) return BadRequest("Invalid status or incident not found.");
            return NoContent();
        }

        // PUT api/incidents/{id}/assign/{userId}
        [HttpPut("{id:int}/assign/{userId:int}")]
        public async Task<IActionResult> AssignUser(int id, int userId)
        {
            var success = await _incidentService.AssignUserAsync(id, userId);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
