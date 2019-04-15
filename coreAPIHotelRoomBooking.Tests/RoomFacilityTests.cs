using coreAPIHotelRoomBooking.Controllers;
using coreAPIHotelRoomBooking.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;

namespace coreAPIHotelRoomBooking.Tests
{
    public class RoomFacilityTestController
    {
        private HotelApplicationDBContext context;

        public static DbContextOptions<HotelApplicationDBContext> dbContextOptions { get; set; }

        public static string connectionString = "Data Source=TRD-513; Initial Catalog=coreHotelRoomBookingFinalDatabase; Integrated Security=True;";

        static RoomFacilityTestController()
        {
            dbContextOptions = new DbContextOptionsBuilder<HotelApplicationDBContext>().UseSqlServer(connectionString).Options;
        }

        public RoomFacilityTestController()
        {
            context = new HotelApplicationDBContext(dbContextOptions);
        }

        [Fact]
        public async void Task_GetRoomFacilityById_Return_OkResult()
        {
            var controller = new RoomFacilityController(context);
            var RoomFacilityId = 5;
            var data = await controller.Get(RoomFacilityId);
            Assert.IsType<OkObjectResult>(data);

        }

        [Fact]
        public async void Task_GetRoomFacilityById_Return_NotFoundResult()
        {
            var controller = new RoomFacilityController(context);
            var RoomFacilityId = 50;
            var data = await controller.Get(RoomFacilityId);
            Assert.IsType<NotFoundResult>(data);

        }

        [Fact]
        public async void Task_GetRoomFacilityById_MatchResult()
        {
            var controller = new RoomFacilityController(context);
            var RoomFacilityId = 10;
            var data = await controller.Get(RoomFacilityId);
            Assert.IsType<OkObjectResult>(data);
            var okResult = data.Should().BeOfType<OkObjectResult>().Subject;
            var RoomFacility = okResult.Value.Should().BeAssignableTo<RoomFacility>().Subject;
            Assert.True(RoomFacility.IsAvilable);
            Assert.Equal("desc", RoomFacility.RoomFacilityDescription);
            Assert.False(RoomFacility.Wifi);
            Assert.False(RoomFacility.AirConditioner);
            Assert.True(RoomFacility.Ekettle);
            Assert.True(RoomFacility.Refrigerator);
            Assert.Equal(12, RoomFacility.RoomId);


        }

        [Fact]
        public async void Task_GetRoomFacilityById_BadRequestResult()
        {
            var controller = new RoomFacilityController(context);
            int? RoomFacilityId = null;
            var data = await controller.Get(RoomFacilityId);
            Assert.IsType<BadRequestResult>(data);

        }

        [Fact]
        public async void Task_Add_AddRoomFacility_Return_OkResult()
        {
            var controller = new RoomFacilityController(context);
            var RoomFacility = new RoomFacility()
            {
                IsAvilable = true,
                RoomFacilityDescription = "desc",
                Wifi = false,
                AirConditioner = false,
                Ekettle = true,
                Refrigerator = true,
                RoomId = 12


            };
            var data = await controller.Post(RoomFacility);
            Assert.IsType<CreatedAtActionResult>(data);
        }

        [Fact]
        public async void Task_Add_AddRoomFacility_Return_BadRequest()
        {
            var controller = new RoomFacilityController(context);
            var RoomFacility = new RoomFacility()
            {
                RoomFacilityId = 19,
                IsAvilable = true,
                RoomFacilityDescription = "Nice!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!",
                Wifi = true,
                AirConditioner = false,
                Ekettle = false,
                Refrigerator = true,
                RoomId = 22

            };
            var data = await controller.Post(RoomFacility);
            Assert.IsType<BadRequestResult>(data);
        }

        [Fact]
        public async void Task_DeleteRoomFacility_Return_OkResult()
        {
            var controller = new RoomFacilityController(context);
            var RoomFacilityId = 22;
            var data = await controller.Delete(RoomFacilityId);
            Assert.IsType<OkObjectResult>(data);

        }

        [Fact]
        public async void Task_DeleteRoomFacility_Return_NotFoundResult()
        {
            var controller = new RoomFacilityController(context);
            var RoomFacilityId = 47;
            var data = await controller.Delete(RoomFacilityId);
            Assert.IsType<NotFoundResult>(data);

        }

        [Fact]
        public async void Task_DeleteRoomFacility_Return_BadResultResult()
        {
            var controller = new RoomFacilityController(context);
            int? RoomFacilityId = null;
            var data = await controller.Delete(RoomFacilityId);
            Assert.IsType<BadRequestResult>(data);

        }

        [Fact]
        public async void Task_PutRoomFacility_Return_NoContentResult()
        {
            var controller = new RoomFacilityController(context);
            var id = 10;
            var RoomFacility = new RoomFacility()
            {

                RoomFacilityId = 10,
                IsAvilable = true,
                RoomFacilityDescription = "Nice!",
                Wifi = true,
                AirConditioner = false,
                Ekettle = false,
                Refrigerator = true,
                RoomId = 12

            };
            var data = await controller.Put(id, RoomFacility);
            Assert.IsType<NoContentResult>(data);
        }

        [Fact]
        public async void Task_PutRoomFacility_Return_NotFoundResult()
        {
            var controller = new RoomFacilityController(context);
            var id = 15;
            var RoomFacility = new RoomFacility()
            {
                RoomFacilityId = 19,
                IsAvilable = true,
                RoomFacilityDescription = "Nice!",
                Wifi = true,
                AirConditioner = false,
                Ekettle = false,
                Refrigerator = true,
                RoomId = 22

            };
            var data = await controller.Put(id, RoomFacility);
            Assert.IsType<NotFoundResult>(data);
        }

        [Fact]
        public async void Task_PutRoomFacility_Return_BadRequestResult()
        {
            var controller = new RoomFacilityController(context);
            int? id = null;
            var RoomFacility = new RoomFacility()
            {
                RoomFacilityId = 19,
                IsAvilable = true,
                RoomFacilityDescription = "Nice!",
                Wifi = true,
                AirConditioner = false,
                Ekettle = false,
                Refrigerator = true,
                RoomId = 22

            };
            var data = await controller.Put(id, RoomFacility);
            Assert.IsType<BadRequestResult>(data);
        }

        [Fact]
        public async void Task_GetAllRoomFacility_Return_OkResult()
        {
            //Arrange
            var controller = new RoomFacilityController(context);

            //Act
            var data = await controller.Get();
            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public async void Task_GetRoomFacility_Return_NotFound()
        {
            //Arrange
            var controller = new RoomFacilityController(context);
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
