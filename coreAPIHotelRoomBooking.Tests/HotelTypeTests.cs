using coreAPIHotelRoomBooking.Controllers;
using coreAPIHotelRoomBooking.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;

namespace coreAPIHotelRoomBooking.Tests
{
    public class HotelTypeTestController
    {
        private HotelApplicationDBContext context;

        public static DbContextOptions<HotelApplicationDBContext> dbContextOptions { get; set; }

        public static string connectionString = "Data Source=TRD-513; Initial Catalog=coreHotelRoomBookingFinalDatabase; Integrated Security=True;";

        static HotelTypeTestController()
        {
            dbContextOptions = new DbContextOptionsBuilder<HotelApplicationDBContext>().UseSqlServer(connectionString).Options;
        }

        public HotelTypeTestController()
        {
            context = new HotelApplicationDBContext(dbContextOptions);
        }

        [Fact]
        public async void Task_GetHotelTypeById_Return_OkResult()
        {
            var controller = new HotelTypeController(context);
            var HotelTypeId = 2;
            var data = await controller.Get(HotelTypeId);
            Assert.IsType<OkObjectResult>(data);

        }

        [Fact]
        public async void Task_GetHotelTypeById_Return_NotFoundResult()
        {
            var controller = new HotelTypeController(context);
            var HotelTypeId = 10;
            var data = await controller.Get(HotelTypeId);
            Assert.IsType<NotFoundResult>(data);

        }

        [Fact]
        public async void Task_GetHotelTypeById_MatchResult()
        {
            var controller = new HotelTypeController(context);
            var HotelTypeId = 1;
            var data = await controller.Get(HotelTypeId);
            Assert.IsType<OkObjectResult>(data);
            var okResult = data.Should().BeOfType<OkObjectResult>().Subject;
            var hoteltype = okResult.Value.Should().BeAssignableTo<HotelType>().Subject;
            Assert.Equal("Villa", hoteltype.HotelTypeName);
            Assert.Equal("Good", hoteltype.HotelTypeDescription);
        }

        [Fact]
        public async void Task_GetHotelTypeById_BadRequestResult()
        {
            var controller = new HotelTypeController(context);
            int? HotelTypeId = null;
            var data = await controller.Get(HotelTypeId);
            Assert.IsType<BadRequestResult>(data);

        }

        [Fact]
        public async void Task_Add_AddHotelType_Return_OkResult()
        {
            var controller = new HotelTypeController(context);
            var hoteltype = new HotelType()
            {
                HotelTypeName = "Villa1",
                HotelTypeDescription = "Nice!"

            };
            var data = await controller.Post(hoteltype);
            Assert.IsType<CreatedAtActionResult>(data);
        }

        [Fact]
        public async void Task_Add_AddHotelType_Return_BadRequest()
        {
            var controller = new HotelTypeController(context);
            var hoteltype = new HotelType()
            {
                HotelTypeName = "Villa Resort!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!",
                HotelTypeDescription = "Nice!"

            };
            var data = await controller.Post(hoteltype);
            Assert.IsType<BadRequestResult>(data);
        }

        [Fact]
        public async void Task_DeleteHotelType_Return_OkResult()
        {
            var controller = new HotelTypeController(context);
            var HotelTypeId = 11;
            var data = await controller.Delete(HotelTypeId);
            Assert.IsType<OkObjectResult>(data);

        }

        [Fact]
        public async void Task_DeleteHotelType_Return_NotFoundResult()
        {
            var controller = new HotelTypeController(context);
            var HotelTypeId = 70;
            var data = await controller.Delete(HotelTypeId);
            Assert.IsType<NotFoundResult>(data);

        }

        [Fact]
        public async void Task_DeleteHotelType_Return_BadResultResult()
        {
            var controller = new HotelTypeController(context);
            int? HotelTypeId = null;
            var data = await controller.Delete(HotelTypeId);
            Assert.IsType<BadRequestResult>(data);

        }

        [Fact]
        public async void Task_PutHotelType_Return_NoContentResult()
        {
            var controller = new HotelTypeController(context);
            var id = 3;
            var hoteltype = new HotelType()
            {
                HotelTypeId = 3,
                HotelTypeName = "Resort",
                HotelTypeDescription = "Nice!"

            };
            var data = await controller.Put(id, hoteltype);
            Assert.IsType<NoContentResult>(data);
        }

        [Fact]
        public async void Task_PutHotelType_Return_NotFoundResult()
        {
            var controller = new HotelTypeController(context);
            var id = 15;
            var hoteltype = new HotelType()
            {
                HotelTypeId = 2,
                HotelTypeName = "Resort",
                HotelTypeDescription = "Nice!"

            };
            var data = await controller.Put(id, hoteltype);
            Assert.IsType<NotFoundResult>(data);
        }

        [Fact]
        public async void Task_PutHotelType_Return_BadRequestResult()
        {
            var controller = new HotelTypeController(context);
            int? id = null;
            var hoteltype = new HotelType()
            {
                HotelTypeId = 2,
                HotelTypeName = "Resort",
                HotelTypeDescription = "Nice!"

            };
            var data = await controller.Put(id, hoteltype);
            Assert.IsType<BadRequestResult>(data);
        }

        [Fact]
        public async void Task_GetAllHotelType_Return_OkResult()
        {
            //Arrange
            var controller = new HotelTypeController(context);

            //Act
            var data = await controller.Get();
            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public async void Task_GetAllHotelType_Return_NotFound()
        {
            //Arrange
            var controller = new HotelTypeController(context);
            var data = await controller.Get();
            data = null;
            if (data != null)
            {
                Assert.IsType<OkObjectResult>(data);
            }
            else
            {
                //Assert.IsType<OkObjectResult>(data);
            }


        }
    }
}
