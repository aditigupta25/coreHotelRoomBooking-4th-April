﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace coreAPIHotelRoomBooking.Models
{
    public class Booking
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookingId { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        //public int NumberOfRooms { get; set; }
        public double TotalAmount { get; set; }
        public DateTime BookingDate { get; set; }
        //public int RoomId { get; set; }
        //public int HotelId { get; set; }
        //Relationship
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        //public virtual List<HotelRoom> HotelRooms { get; set; }
    }
}
