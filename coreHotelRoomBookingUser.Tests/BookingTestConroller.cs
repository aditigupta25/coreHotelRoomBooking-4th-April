//using coreHotelRoomBookingUserPanel.Models;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace coreHotelRoomBookingUser.Tests
//{
//    public class BookingTestConroller
//    {
//        private coreHotelRoomBookingFinalDatabaseContext context;

//        public static DbContextOptions<coreHotelRoomBookingFinalDatabaseContext> dbContextOptions { get; set; }

//        public static string connectionString = "Data Source=TRD-513; Initial Catalog=coreHotelRoomBookingFinalDatabase; Integrated Security=True;";

//        static BookingTestConroller()
//        {
//            dbContextOptions = new DbContextOptionsBuilder<coreHotelRoomBookingFinalDatabaseContext>().UseSqlServer(connectionString).Options;
//        }

//        public BookingTestConroller()
//        {
//            context = new coreHotelRoomBookingFinalDatabaseContext(dbContextOptions);
//        }
         

//    }
//}
