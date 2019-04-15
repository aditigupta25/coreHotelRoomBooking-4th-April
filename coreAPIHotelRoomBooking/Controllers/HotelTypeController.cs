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
    public class HotelTypeController : ControllerBase
    {
        private readonly HotelApplicationDBContext _context;
        public HotelTypeController(HotelApplicationDBContext context)
        {
            _context = context;
        }

        //HotelApplicationDBContext context = new HotelApplicationDBContext();

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<HotelType> r= await _context.HotelTypes.ToListAsync();
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

                var ht = await _context.HotelTypes.FindAsync(id);
                if (ht == null)
                {
                    return NotFound();
                }
                return Ok(ht);

            }

            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]HotelType ht)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            else
            {
                try
                {
                    _context.HotelTypes.Add(ht);
                    await _context.SaveChangesAsync();
                    return CreatedAtAction(nameof(Get), new { id = ht.HotelTypeId }, ht);
                }

                catch (Exception)
                {
                    return BadRequest();
                }
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id==null)
            {
                return BadRequest();
            }

            var ht = await _context.HotelTypes.FindAsync(id);
            if (ht == null)
            {
                return NotFound();
            }
            _context.HotelTypes.Remove(ht);
            await _context.SaveChangesAsync();
            return Ok(ht);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int? id, [FromBody] HotelType newht)
        {
            if (id == null)
            {
                return BadRequest();
            }
            
            if (id != newht.HotelTypeId)
            {
                return NotFound();
            }
            
            _context.Entry(newht).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
