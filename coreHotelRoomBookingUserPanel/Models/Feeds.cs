using System;
using System.Collections.Generic;

namespace coreHotelRoomBookingUserPanel.Models
{
    public partial class Feeds
    {
        public int FeedbackId { get; set; }
        public int HotelId { get; set; }
        public int CustomerId { get; set; }
        public string Appearance { get; set; }
        public string ImproveServices { get; set; }
        public string Expectations { get; set; }
        public string Comments { get; set; }
    }
}
