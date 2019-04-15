using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coreAPIHotelRoomBooking.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace coreAPIHotelRoomBooking.Controllers
{
    [EnableCors("AllowMyOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class RoomFacilityController : ControllerBase
    {
        private readonly HotelApplicationDBContext _context;
        public RoomFacilityController(HotelApplicationDBContext context)
        {
            _context = context;
        }

        //HotelApplicationDBContext context = new HotelApplicationDBContext();
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<RoomFacility> r= await _context.RoomFacilities.ToListAsync();

            if (r != null)
            {
                return Ok(r);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var rf = await _context.RoomFacilities.FindAsync(id);
            if (rf == null)
            {
                return NotFound();
            }
            return Ok(rf);
            }

            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody]RoomFacility rf)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            else
            {
                try
                {
                    _context.RoomFacilities.Add(rf);
                     await _context.SaveChangesAsync();
                     return CreatedAtAction(nameof(Get), new { id = rf.RoomFacilityId }, rf);
                       
                  }

                catch (Exception)
                {
                    return BadRequest();
                }
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var rf = await _context.RoomFacilities.FindAsync(id);
            if (rf == null)
            {
                return NotFound();
            }
            _context.RoomFacilities.Remove(rf);
            await _context.SaveChangesAsync();
            return Ok(rf);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int? id, [FromBody] RoomFacility newrf)
        {
            if (id == null)
            {
                return BadRequest();
            }

            if (id != newrf.RoomFacilityId)
            {
                return NotFound();
            }

            _context.Entry(newrf).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
