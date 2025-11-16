namespace sims.Controllers;
using sims.Data;
using sims.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]


public class AlertsController : ControllerBase
{
    private readonly SimsContext _context;
    public AlertsController(SimsContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAlerts()
    {
        return Ok(_context.Alerts.ToList());
    }

    [HttpGet("{id}")]
    public IActionResult GetAlert(int id)
    {
        var alert = _context.Alerts.Find(id);
        if (alert == null)
        {
            return NotFound();
        }
        return Ok(alert);
    }

    [HttpPost]
    public IActionResult CreateAlert(Alert alert)
    {
        _context.Alerts.Add(alert);
        _context.SaveChanges();
        return Ok(alert);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteAlert(int id)
    {
        
    }
}