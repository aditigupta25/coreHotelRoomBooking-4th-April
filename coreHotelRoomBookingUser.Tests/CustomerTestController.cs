using coreHotelRoomBookingUserPanel.Controllers;
using coreHotelRoomBookingUserPanel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace coreHotelRoomBookingUser.Tests
{
    public class CustomerTestController
    {

        private coreHotelRoomBookingFinalDatabaseContext context;

        public static DbContextOptions<coreHotelRoomBookingFinalDatabaseContext> dbContextOptions { get; set; }

        public static string connectionString = "Data Source=TRD-513; Initial Catalog=coreHotelRoomBookingFinalDatabase; Integrated Security=True;";

        static CustomerTestController()
        {
            dbContextOptions = new DbContextOptionsBuilder<coreHotelRoomBookingFinalDatabaseContext>().UseSqlServer(connectionString).Options;
        }

        public CustomerTestController()
        {
            context = new coreHotelRoomBookingFinalDatabaseContext(dbContextOptions);
        }

        [Fact]
        public void Task_Add_Customer_Return_OkResult()
        {
            var controller = new CustomerController(context);
            var customer = new Customers()
            {
                CustomerFirstName = "Aditi",
                CustomerLastName = "Gupta",
                CustomerAddress = "21-A",
                CustomerContactNumber = 7685468399,
                CustomerEmailId = "aditi@gmail.com",
                CustomerPassword = "1",
                State="New Delhi",
                Country="India",
                Zip=110034
            };

            var data =controller.Create(customer);
            Assert.IsType<RedirectToActionResult>(data);
        }

        //[Fact]
        //public void Task_Edit_Customer_Return_OkResult()
        //{
        //    var controller = new CustomerController(context);
        //    int id = 54;
        //    var customer = new Customers(id)
        //    {
        //        CustomerId=54,
        //        CustomerFirstName = "Aditi123",
        //        CustomerLastName = "Gupta",
        //        CustomerAddress = "21-A",
        //        CustomerContactNumber = 7685468399,
        //        CustomerEmailId = "aditi@gmail.com",
        //        CustomerPassword = "1",
        //        State = "New Delhi",
        //        Country = "India",
        //        Zip = 110034
        //    };

        //    var data = controller.Edit(customer);
        //    Assert.IsType<RedirectToActionResult>(data);
        //}

        //[Fact]
        //public void Task_GetAllCustomerReturn_OkResult()
        //{
        //    //Arrange
        //    var controller = new CustomerController(context);

        //    //Act
        //    var data = controller.Details();
        //    Assert.IsType<ViewResult>(data);
        //}

        //public void Task_Add_Feedback_Return_OkResult()
        //{
        //    var controller = new CustomerController(context);
        //    var feedback = new Feeds()
        //    {
        //        HotelId=1,
        //        Appearance="Good",
        //        Expectations="Good",
        //        Comments="very Nice",
        //        ImproveServices="nothing",
        //        CustomerId=17

        //    };

        //    var data = controller.Feedback(Appearance, Expectations,feedback);
        //    Assert.IsType<RedirectToActionResult>(data);
        //}
    }
}
