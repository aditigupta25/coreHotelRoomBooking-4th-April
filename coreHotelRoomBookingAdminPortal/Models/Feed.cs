using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace coreHotelRoomBookingAdminPortal.Models
{
    public class Feed
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int FeedbackId { get; set; }

        public int HotelId { get; set; }

        public int customerId { get; set; }

        public string Appearance { get; set; }

        public string ImproveServices { get; set; }

        public string Expectations { get; set; }

        public string Comments { get; set; }
    }
}
