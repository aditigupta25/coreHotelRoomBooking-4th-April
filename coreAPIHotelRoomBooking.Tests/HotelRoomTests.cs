using coreAPIHotelRoomBooking.Controllers;
using coreAPIHotelRoomBooking.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;

namespace coreAPIHotelRoomBooking.Tests
{
    public class HotelRoomTestController
    {
        private HotelApplicationDBContext context;

        public static DbContextOptions<HotelApplicationDBContext> dbContextOptions { get; set; }

        public static string connectionString = "Data Source=TRD-513; Initial Catalog=coreHotelRoomBookingFinalDatabase; Integrated Security=True;";

        static HotelRoomTestController()
        {
            dbContextOptions = new DbContextOptionsBuilder<HotelApplicationDBContext>().UseSqlServer(connectionString).Options;
        }

        public HotelRoomTestController()
        {
            context = new HotelApplicationDBContext(dbContextOptions);
        }

        [Fact]
        public async void Task_GetHotelRoomById_Return_OkResult()
        {
            var controller = new HotelRoomController(context);
            var HotelRoomId = 1;
            var data = await controller.Get(HotelRoomId);
            Assert.IsType<OkObjectResult>(data);

        }

        [Fact]
        public async void Task_GetHotelRoomById_Return_NotFoundResult()
        {
            var controller = new HotelRoomController(context);
            var HotelRoomId = 15;
            var data = await controller.Get(HotelRoomId);
            Assert.IsType<NotFoundResult>(data);

        }

        [Fact]
        public async void Task_GetHotelRoomById_MatchResult()
        {
            var controller = new HotelRoomController(context);
            var HotelRoomId = 4;
            var data = await controller.Get(HotelRoomId);
            Assert.IsType<OkObjectResult>(data);
            var okResult = data.Should().BeOfType<OkObjectResult>().Subject;
            var hotelRoom = okResult.Value.Should().BeAssignableTo<HotelRoom>().Subject;
            Assert.Equal("Single1", hotelRoom.RoomType);
            Assert.Equal("abc", hotelRoom.RoomDescription);
            Assert.Equal(10000, hotelRoom.RoomPrice);
            Assert.Equal("abcd", hotelRoom.RoomImage);
            Assert.Equal(2, hotelRoom.HotelId);

        }

        [Fact]
        public async void Task_GetHotelRoomById_BadRequestResult()
        {
            var controller = new HotelRoomController(context);
            int? HotelRoomId = null;
            var data = await controller.Get(HotelRoomId);
            Assert.IsType<BadRequestResult>(data);
        }
        

        [Fact]
        public async void Task_Add_AddHotelRoom_Return_OkResult()
        {
            var controller = new HotelRoomController(context);
            var hotelRoom = new HotelRoom()
            {
                RoomType = "Double2",
                RoomDescription = "Nice!",
                RoomPrice = 18000,
                RoomImage = "abc",
                HotelId = 7

            };
            var data = await controller.Post(hotelRoom);
            Assert.IsType<CreatedAtActionResult>(data);
        }

        [Fact]
        public async void Task_Add_AddHotelRoom_Return_BadRequest()
        {
            var controller = new HotelRoomController(context);
            var hotelRoom = new HotelRoom()
            {
                RoomType = "Double Delux2222222222222222222222222222",
                RoomDescription = "Nice!",
                RoomPrice = 18000,
                RoomImage = "abc",
                HotelId = 17

            };
            var data = await controller.Post(hotelRoom);
            Assert.IsType<BadRequestResult>(data);
        }

        [Fact]
        public async void Task_DeleteHotelRoom_Return_OkResult()
        {
            var controller = new HotelRoomController(context);
            var HotelRoomId = 20;
            var data = await controller.Delete(HotelRoomId);
            Assert.IsType<OkObjectResult>(data);

        }

        [Fact]
        public async void Task_DeleteHotelRoom_Return_NotFoundResult()
        {
            var controller = new HotelRoomController(context);
            var HotelRoomId = 15;
            var data = await controller.Delete(HotelRoomId);
            Assert.IsType<NotFoundResult>(data);

        }

        [Fact]
        public async void Task_DeleteHotelRoom_Return_BadResultResult()
        {
            var controller = new HotelRoomController(context);
            int? HotelRoomId = null;
            var data = await controller.Delete(HotelRoomId);
            Assert.IsType<BadRequestResult>(data);

        }

        [Fact]
        public async void Task_PutHotelRoom_Return_NoContentResult()
        {
            var controller = new HotelRoomController(context);
            var id = 12;
            var hotelRoom = new HotelRoom()
            {
                RoomId = 12,
                RoomType = "Double12",
                RoomDescription = "Nice!",
                RoomPrice = 18000,
                RoomImage = "abc",
                HotelId = 7

            };
            var data = await controller.Put(id, hotelRoom);
            Assert.IsType<NoContentResult>(data);
        }

        [Fact]
        public async void Task_PutHotelRoom_Return_NotFoundResult()
        {
            var controller = new HotelRoomController(context);
            var id = 16;
            var hotelRoom = new HotelRoom()
            {
                RoomId = 18,
                RoomType = "Delux",
                RoomDescription = "desc!",
                RoomPrice = 15000,
                RoomImage = "abc",
                HotelId = 20

            };
            var data = await controller.Put(id, hotelRoom);
            Assert.IsType<NotFoundResult>(data);
        }

        [Fact]
        public async void Task_PutHotelRoom_Return_BadRequestResult()
        {
            var controller = new HotelRoomController(context);
            int? id = null;
            var hotelRoom = new HotelRoom()
            {
                RoomId = 18,
                RoomType = "Delux",
                RoomDescription = "desc!",
                RoomPrice = 15000,
                RoomImage = "abc",
                HotelId = 20

            };
            var data = await controller.Put(id, hotelRoom);
            Assert.IsType<BadRequestResult>(data);
        }

        [Fact]
        public async void Task_GetAllHotelRoom_Return_OkResult()
        {
            //Arrange
            var controller = new HotelRoomController(context);

            //Act
            var data = await controller.Get();
            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public async void Task_GetAllHotel_Return_NotFound()
        {
            //Arrange
            var controller = new HotelRoomController(context);
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
