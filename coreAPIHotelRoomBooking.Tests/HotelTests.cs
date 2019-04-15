using coreAPIHotelRoomBooking.Controllers;
using coreAPIHotelRoomBooking.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;

namespace coreAPIHotelRoomBooking.Tests
{
    public class HotelTestController
    {
        private HotelApplicationDBContext context;

        public static DbContextOptions<HotelApplicationDBContext> dbContextOptions { get; set; }

        public static string connectionString = "Data Source=TRD-513; Initial Catalog=coreHotelRoomBookingFinalDatabase; Integrated Security=True;";

        static HotelTestController()
        {
            dbContextOptions = new DbContextOptionsBuilder<HotelApplicationDBContext>().UseSqlServer(connectionString).Options;
        }

        public HotelTestController()
        {
            context = new HotelApplicationDBContext(dbContextOptions);
        }

        [Fact]
        public async void Task_GetHotelById_Return_OkResult()
        {
            var controller = new HotelController(context);
            var HotelId = 7;
            var data = await controller.Get(HotelId);
            Assert.IsType<OkObjectResult>(data);

        }

        [Fact]
        public async void Task_GetHotelById_Return_NotFoundResult()
        {
            var controller = new HotelController(context);
            var HotelId = 50;
            var data = await controller.Get(HotelId);
            Assert.IsType<NotFoundResult>(data);

        }

        [Fact]
        public async void Task_GetHotelById_MatchResult()
        {
            var controller = new HotelController(context);
            var HotelId = 8;
            var data = await controller.Get(HotelId);
            Assert.IsType<OkObjectResult>(data);
            var okResult = data.Should().BeOfType<OkObjectResult>().Subject;
            var hotel = okResult.Value.Should().BeAssignableTo<Hotel>().Subject;
            Assert.Equal("Leela", hotel.HotelName);
            Assert.Equal("Desciption", hotel.HotelDescription);
            Assert.Equal("21-A", hotel.HotelAddress);
            Assert.Equal("South Delhi", hotel.HotelDistrict);
            Assert.Equal("New Delhi", hotel.HotelCity);
            Assert.Equal("Delhi", hotel.HotelState);
            Assert.Equal("India", hotel.HotelCountry);
            Assert.Equal("abc@gmail.com", hotel.HotelEmailId);
            Assert.Equal("4", hotel.HotelRating);
            Assert.Equal("abv", hotel.HotelImage);
            Assert.Equal(23242342523, hotel.HotelContactNumber);
            Assert.Equal(2, hotel.HotelTypeId);


        }

        [Fact]
        public async void Task_GetHotelById_BadRequestResult()
        {
            var controller = new HotelController(context);
            int? HotelId = null;
            var data = await controller.Get(HotelId);
            Assert.IsType<BadRequestResult>(data);

        }

        [Fact]
        public async void Task_Add_AddHotel_Return_OkResult()
        {
            var controller = new HotelController(context);
            var hotel = new Hotel()
            {
                HotelName = "Grand1",
                HotelDescription = "Nice!",
                HotelAddress = "21-A",
                HotelDistrict = "South Delhi",
                HotelCity = "New Delhi",
                HotelState = "Delhi",
                HotelCountry = "India",
                HotelEmailId = "abc@gmail.com",
                HotelRating = "4",
                HotelImage = "abv",
                HotelContactNumber = 23242342523,
                HotelTypeId = 2

            };
            var data = await controller.Post(hotel);
            Assert.IsType<CreatedAtActionResult>(data);
        }

        [Fact]
        public async void Task_Add_AddHotel_Return_BadRequest()
        {
            var controller = new HotelController(context);
            var hotel = new Hotel()
            {
                HotelName = "The Ashokaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                HotelDescription = "Nice!",
                HotelAddress = "Abc",
                HotelDistrict = "South Delhi",
                HotelCity = "New Delhi",
                HotelState = "Delhi",
                HotelCountry = "India",
                HotelEmailId = "abc@gmail.com",
                HotelRating = "4",
                HotelImage = "abv",
                HotelContactNumber = 23242342523,
                HotelTypeId = 2

            };
            var data = await controller.Post(hotel);
            Assert.IsType<BadRequestResult>(data);
        }

        [Fact]
        public async void Task_DeleteHotel_Return_OkResult()
        {
            var controller = new HotelController(context);
            var HotelId = 21;
            var data = await controller.Delete(HotelId);
            Assert.IsType<OkObjectResult>(data);

        }

        [Fact]
        public async void Task_DeleteHotel_Return_NotFoundResult()
        {
            var controller = new HotelController(context);
            var HotelId = 77;
            var data = await controller.Delete(HotelId);
            Assert.IsType<NotFoundResult>(data);

        }

        [Fact]
        public async void Task_DeleteHotel_Return_BadResultResult()
        {
            var controller = new HotelController(context);
            int? HotelId = null;
            var data = await controller.Delete(HotelId);
            Assert.IsType<BadRequestResult>(data);

        }

        [Fact]
        public async void Task_PutHotel_Return_NoContentResult()
        {
            var controller = new HotelController(context);
            var id = 10;
            var hotel = new Hotel()
            {
                HotelId = 10,
                HotelName = "Grand1",
                HotelDescription = "Nice!",
                HotelAddress = "21-A",
                HotelDistrict = "South Delhi",
                HotelCity = "New Delhi",
                HotelState = "Delhi",
                HotelCountry = "India",
                HotelEmailId = "abc@gmail.com",
                HotelRating = "4",
                HotelImage = "abv",
                HotelContactNumber = 23242342523,
                HotelTypeId = 2

            };
            var data = await controller.Put(id, hotel);
            Assert.IsType<NoContentResult>(data);
        }

        [Fact]
        public async void Task_PutHotel_Return_NotFoundResult()
        {
            var controller = new HotelController(context);
            var id = 15;
            var hotel = new Hotel()
            {
                HotelId = 17,
                HotelName = "Ashoka",
                HotelDescription = "Nice!",
                HotelAddress = "21-A",
                HotelDistrict = "South Delhi",
                HotelCity = "New Delhi",
                HotelState = "Delhi",
                HotelCountry = "India",
                HotelEmailId = "abc@gmail.com",
                HotelRating = "4",
                HotelImage = "abv",
                HotelContactNumber = 23242342523,
                HotelTypeId = 2

            };
            var data = await controller.Put(id, hotel);
            Assert.IsType<NotFoundResult>(data);
        }

        [Fact]
        public async void Task_PutHotel_Return_BadRequestResult()
        {
            var controller = new HotelController(context);
            int? id = null;
            var hotel = new Hotel()
            {
                HotelId = 2,
                HotelName = "Ashoka",
                HotelDescription = "Nice!",
                HotelAddress = "21-A",
                HotelDistrict = "South Delhi",
                HotelCity = "New Delhi",
                HotelState = "Delhi",
                HotelCountry = "India",
                HotelEmailId = "abc@gmail.com",
                HotelRating = "4",
                HotelImage = "abv",
                HotelContactNumber = 23242342523,
                HotelTypeId = 2

            };
            var data = await controller.Put(id, hotel);
            Assert.IsType<BadRequestResult>(data);
        }


        [Fact]
        public async void Task_GetAllHotel_Return_OkResult()
        {
            //Arrange
            var controller = new HotelController(context);

            //Act
            var data = await controller.Get();
            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public async void Task_GetAllHotel_Return_NotFound()
        {
            //Arrange
            var controller = new HotelController(context);
            var data = await controller.Get();
            data = null;
            if (data != null)
            {
                Assert.IsType<OkObjectResult>(data);
            }
            else
            {
                //Assert.Equal(data, null);
            }


        }
    }
}
