// Controllers/MaintenanceTicketsController.cs
using MaintainSys.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class MaintenanceTicketsController : ControllerBase
{
    private readonly AppDbContext _context;

    public MaintenanceTicketsController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/MaintenanceTickets
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Maintenancetickets>>> GetMaintenanceTickets()
    {
        return await _context.Maintenancetickets.ToListAsync();
    }

    // GET: api/MaintenanceTickets/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Maintenancetickets>> GetMaintenanceTicket(int id)
    {
        var maintenanceTicket = await _context.Maintenancetickets.FindAsync(id);

        if (maintenanceTicket == null)
        {
            return NotFound();
        }

        return maintenanceTicket;
    }

    // POST: api/MaintenanceTickets
    [HttpPost]
    public async Task<ActionResult<Maintenancetickets>> PostMaintenanceTicket(Maintenancetickets maintenanceTicket)
    {
        _context.Maintenancetickets.Add(maintenanceTicket);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetMaintenanceTicket", new { id = maintenanceTicket.ticket_id }, maintenanceTicket);
    }

    // PUT: api/MaintenanceTickets/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutMaintenanceTicket(int id, Maintenancetickets maintenanceTicket)
    {
        if (id != maintenanceTicket.ticket_id)
        {
            return BadRequest();
        }

        _context.Entry(maintenanceTicket).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!MaintenanceTicketExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // DELETE: api/MaintenanceTickets/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMaintenanceTicket(int id)
    {
        var maintenanceTicket = await _context.Maintenancetickets.FindAsync(id);
        if (maintenanceTicket == null)
        {
            return NotFound();
        }

        _context.Maintenancetickets.Remove(maintenanceTicket);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool MaintenanceTicketExists(int id)
    {
        return _context.Maintenancetickets.Any(e => e.ticket_id == id);
    }
}
