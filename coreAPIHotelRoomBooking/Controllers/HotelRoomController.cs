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
    public class HotelRoomController : ControllerBase
    {
        private readonly HotelApplicationDBContext _context;
        public HotelRoomController(HotelApplicationDBContext context)
        {
            _context = context;
        }

        //HotelApplicationDBContext context = new HotelApplicationDBContext();
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            List<HotelRoom> h= await _context.HotelRooms.ToListAsync();
            if (h != null)
            {
                return Ok(h);
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
                var hr = await _context.HotelRooms.FindAsync(id);
            if (hr == null)
            {
                return NotFound();
            }
            return Ok(hr);

            }

            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody]HotelRoom hr)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            else
            {
                try
                {
                    _context.HotelRooms.Add(hr);
                    await _context.SaveChangesAsync();
                    return CreatedAtAction(nameof(Get), new { id = hr.RoomId }, hr);
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

            var hr = await _context.HotelRooms.FindAsync(id);
            if (hr == null)
            {
                return NotFound();
            }
            _context.HotelRooms.Remove(hr);
            await _context.SaveChangesAsync();
            return Ok(hr);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int? id, [FromBody] HotelRoom newhr)
        {

            if (id == null)
            {
                return BadRequest();
            }

            if (id != newhr.RoomId)
            {
                return NotFound();
            }

            _context.Entry(newhr).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
