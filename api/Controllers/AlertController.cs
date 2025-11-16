using api.DTOs.Alert;
using api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlertsController : ControllerBase
    {
        private readonly IAlertService _alertService;

        public AlertsController(IAlertService alertService)
        {
            _alertService = alertService;
        }

        // GET api/alerts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AlertDto>>> GetAll()
        {
            var alerts = await _alertService.GetAllAsync();
            return Ok(alerts);
        }

        // GET api/alerts/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<AlertDto>> GetById(int id)
        {
            var alert = await _alertService.GetByIdAsync(id);
            if (alert == null) return NotFound();
            return Ok(alert);
        }

        // POST api/alerts
        [HttpPost]
        public async Task<ActionResult<AlertDto>> Create(AlertDto dto)
        {
            var created = await _alertService.CreateAsync(dto);
            return Ok(created);
        }

        // PUT api/alerts/{id}/escalate
        [HttpPut("{id:int}/escalate")]
        public async Task<IActionResult> Escalate(int id)
        {
            var success = await _alertService.EscalateAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}