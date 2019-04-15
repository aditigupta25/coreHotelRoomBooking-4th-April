using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using coreAPIHotelRoomBooking.Models;

namespace coreAPIHotelRoomBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingRecordController : ControllerBase
    {
        private readonly HotelApplicationDBContext _context;

        public BookingRecordController(HotelApplicationDBContext context)
        {
            _context = context;
        }

        // GET: api/BookingRecord
        [HttpGet]
        public IEnumerable<BookingRecord> GetBookingRecords()
        {
            return _context.BookingRecords;
        }

        // GET: api/BookingRecord/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookingRecord([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bookingRecord = await _context.BookingRecords.FindAsync(id);

            if (bookingRecord == null)
            {
                return NotFound();
            }

            return Ok(bookingRecord);
        }

        // PUT: api/BookingRecord/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookingRecord([FromRoute] int id, [FromBody] BookingRecord bookingRecord)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bookingRecord.BookingId)
            {
                return BadRequest();
            }

            _context.Entry(bookingRecord).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingRecordExists(id))
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

        // POST: api/BookingRecord
        [HttpPost]
        public async Task<IActionResult> PostBookingRecord([FromBody] BookingRecord bookingRecord)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.BookingRecords.Add(bookingRecord);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BookingRecordExists(bookingRecord.BookingId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBookingRecord", new { id = bookingRecord.BookingId }, bookingRecord);
        }

        // DELETE: api/BookingRecord/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookingRecord([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bookingRecord = await _context.BookingRecords.FindAsync(id);
            if (bookingRecord == null)
            {
                return NotFound();
            }

            _context.BookingRecords.Remove(bookingRecord);
            await _context.SaveChangesAsync();

            return Ok(bookingRecord);
        }

        private bool BookingRecordExists(int id)
        {
            return _context.BookingRecords.Any(e => e.BookingId == id);
        }
    }
}