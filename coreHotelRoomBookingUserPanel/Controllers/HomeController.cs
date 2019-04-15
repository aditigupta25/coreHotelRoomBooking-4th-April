using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using coreHotelRoomBookingUserPanel.Models;
using coreHotelRoomBookingUserPanel.Helper;
using Microsoft.AspNetCore.Http;

namespace coreHotelRoomBookingUserPanel.Controllers
{
    public class HomeController : Controller
    {
        private readonly coreHotelRoomBookingFinalDatabaseContext _context;
        public HomeController(coreHotelRoomBookingFinalDatabaseContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            var hotel = _context.Hotels.ToList();
            List<Item> booking = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "Booking");
            int count = 0;
            if (booking != null)
            {
                foreach (var item in booking)
                {
                    count++;
                }
                if (count != 0)
                {
                    HttpContext.Session.SetString("CartItem", count.ToString());
                }
               
            }
            

            return View(hotel);
            
        }
        public ViewResult Details(int id)
        {
            Hotels hotel = _context.Hotels.Where(x => x.HotelId == id).SingleOrDefault();
            ViewBag.Hotel = hotel;

            int hotelTypeId = ViewBag.Hotel.HotelTypeId;
            HotelTypes hotelTypes = _context.HotelTypes.Where(x => x.HotelTypeId == hotelTypeId).SingleOrDefault();
            ViewBag.HotelType = hotelTypes;
            return View();
        }

        public IActionResult HotelRoomsIndex(int id)
        {
            List<Item> booking = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "Booking");
            ViewBag.Booking = booking;
            int count = 0;
            if (booking != null)
            {
                foreach (var item in booking)
                {
                    count++;
                }
                if (count != 0)
                {
                    HttpContext.Session.SetString("CartItem", count.ToString());
                }
            }
            var hotelRoom = _context.HotelRooms.Where(x => x.HotelId == id).ToList();
            ViewBag.HotelRoomIndex = hotelRoom;
            TempData["hotel"] = id;
            return View(hotelRoom);
        }

        public ViewResult RoomsDetails(int id)
         {
            int hotelId = int.Parse(TempData["hotel"].ToString());
            Hotels hotel = _context.Hotels.Where(x => x.HotelId == hotelId).SingleOrDefault();
            ViewBag.Hotel = hotel;

            HotelRooms hotelRoom = _context.HotelRooms.Where(x => x.RoomId == id).SingleOrDefault();
            ViewBag.HotelRoom = hotelRoom;
            RoomFacilities roomFacilities = _context.RoomFacilities.Where(x => x.RoomId == id).SingleOrDefault();
            ViewBag.RoomFacilities = roomFacilities;
            return View();
        }

        [Route("search")]
        [HttpGet]
        public IActionResult Search(string search, string CheckIn , string CheckOut, int guest)
        {
            if (search == null)
            {

                return RedirectToAction("Index","Home");
            }
            HttpContext.Session.SetString("Search", search.ToString());
            HttpContext.Session.SetString("CheckIn", CheckIn.ToString());
            HttpContext.Session.SetString("CheckOut", CheckOut.ToString());
            HttpContext.Session.SetString("Guest", guest.ToString());
            ViewBag.Hotel = _context.Hotels.Where(x => x.HotelName == search || x.HotelCity == search || x.HotelState == search || search == null).ToList();
            return View(_context.Hotels.Where(x => x.HotelName == search || search == null).ToList());
        }

        public ViewResult AboutPage()
        {
            return View();
        }

        public ViewResult ContactPage()
        {
            return View();
        }
    }
}
