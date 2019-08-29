using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoSalvo.Data;
using ProyectoSalvo.Models;

namespace ProyectoSalvo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipLocationsController : ControllerBase
    {
        //private readonly SalvoDatabaseContext _context;

        //public ShipLocationsController(SalvoDatabaseContext context)
        //{
        //    _context = context;
        //}

        //// GET: api/ShipLocations
        //[HttpGet]
        //public IEnumerable<ShipLocation> GetLocation()
        //{
        //    return _context.Location;
        //}

        //// GET: api/ShipLocations/5
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetShipLocation([FromRoute] long id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var shipLocation = await _context.Location.FindAsync(id);

        //    if (shipLocation == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(shipLocation);
        //}

        //// PUT: api/ShipLocations/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutShipLocation([FromRoute] long id, [FromBody] ShipLocation shipLocation)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != shipLocation.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(shipLocation).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ShipLocationExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/ShipLocations
        //[HttpPost]
        //public async Task<IActionResult> PostShipLocation([FromBody] ShipLocation shipLocation)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    _context.Location.Add(shipLocation);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetShipLocation", new { id = shipLocation.Id }, shipLocation);
        //}

        //// DELETE: api/ShipLocations/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteShipLocation([FromRoute] long id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var shipLocation = await _context.Location.FindAsync(id);
        //    if (shipLocation == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Location.Remove(shipLocation);
        //    await _context.SaveChangesAsync();

        //    return Ok(shipLocation);
        //}

        //private bool ShipLocationExists(long id)
        //{
        //    return _context.Location.Any(e => e.Id == id);
        //}
    }
}