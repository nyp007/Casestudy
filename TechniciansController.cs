// Controllers/TechniciansController.cs
using MaintainSys.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class TechniciansController : ControllerBase
{
    private readonly AppDbContext _context;

    public TechniciansController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/Technicians
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Technicians>>> GetTechnicians()
    {
        return await _context.Technicians.ToListAsync();
    }

    // GET: api/Technicians/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Technicians>> GetTechnician(int id)
    {
        var technician = await _context.Technicians.FindAsync(id);

        if (technician == null)
        {
            return NotFound();
        }

        return technician;
    }

    // POST: api/Technicians
    [HttpPost]
    public async Task<ActionResult<Technicians>> PostTechnician(Technicians technician)
    {
        _context.Technicians.Add(technician);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTechnician", new { id = technician.technician_Id }, technician);
    }

    // PUT: api/Technicians/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutTechnician(int id, Technicians technician)
    {
        if (id != technician.technician_Id)
        {
            return BadRequest();
        }

        _context.Entry(technician).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TechnicianExists(id))
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

    // DELETE: api/Technicians/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTechnician(int id)
    {
        var technician = await _context.Technicians.FindAsync(id);
        if (technician == null)
        {
            return NotFound();
        }

        _context.Technicians.Remove(technician);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TechnicianExists(int id)
    {
        return _context.Technicians.Any(e => e.technician_Id == id);
    }
}
