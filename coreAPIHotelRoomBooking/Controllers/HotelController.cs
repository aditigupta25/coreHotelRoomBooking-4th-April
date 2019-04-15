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
    public class HotelController : ControllerBase
    {
        private readonly HotelApplicationDBContext _context;
        public HotelController(HotelApplicationDBContext context)
        {
            _context = context;
        }

        //HotelApplicationDBContext context = new HotelApplicationDBContext();

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Hotel> h= await _context.Hotels.ToListAsync();
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
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

            var h = await _context.Hotels.FindAsync(id);
            if (h == null)
            {
                return NotFound();
            }
            return Ok(h);

            }

            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Hotel h)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            else
            {
                try
                {
                    _context.Hotels.Add(h);
                    await _context.SaveChangesAsync();
                    return CreatedAtAction(nameof(Get), new { id = h.HotelId }, h);
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

            var h = await _context.Hotels.FindAsync(id);
            if (h == null)
            {
                return NotFound();
            }
            _context.Hotels.Remove(h);
            await _context.SaveChangesAsync();
            return Ok(h);
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int? id, [FromBody] Hotel newh)
        {

            if (id == null)
            {
                return BadRequest();
            }

            if (id != newh.HotelId)
            {
                return NotFound();
            }

            _context.Entry(newh).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
