﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using coreHotelRoomBookingUserPanel.Models;

namespace coreHotelRoomBookingUserPanel.Migrations
{
    [DbContext(typeof(coreHotelRoomBookingFinalDatabaseContext))]
    [Migration("20190406085102_feed")]
    partial class feed
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("coreHotelRoomBookingUserPanel.Models.BookingRecords", b =>
                {
                    b.Property<int>("BookingId");

                    b.Property<int>("RoomId");

                    b.Property<int>("Quantity");

                    b.HasKey("BookingId", "RoomId");

                    b.HasIndex("RoomId");

                    b.ToTable("BookingRecords");
                });

            modelBuilder.Entity("coreHotelRoomBookingUserPanel.Models.Bookings", b =>
                {
                    b.Property<int>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BookingDate");

                    b.Property<DateTime>("CheckIn")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("('0001-01-01T00:00:00.0000000')");

                    b.Property<DateTime>("CheckOut")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("('0001-01-01T00:00:00.0000000')");

                    b.Property<int?>("CustomerId");

                    b.Property<double>("TotalAmount");

                    b.HasKey("BookingId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("coreHotelRoomBookingUserPanel.Models.Customers", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Country");

                    b.Property<string>("CustomerAddress");

                    b.Property<long>("CustomerContactNumber");

                    b.Property<string>("CustomerEmailId");

                    b.Property<string>("CustomerFirstName");

                    b.Property<string>("CustomerLastName");

                    b.Property<string>("CustomerPassword");

                    b.Property<string>("State");

                    b.Property<int>("Zip");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("coreHotelRoomBookingUserPanel.Models.Feedback", b =>
                {
                    b.Property<int>("FeedbackId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Appearance");

                    b.Property<string>("Comments");

                    b.Property<string>("Expectations");

                    b.Property<int>("HotelId");

                    b.Property<string>("ImproveServices");

                    b.Property<int>("customerId");

                    b.HasKey("FeedbackId");

                    b.ToTable("Feedbacks");
                });

            modelBuilder.Entity("coreHotelRoomBookingUserPanel.Models.HotelRooms", b =>
                {
                    b.Property<int>("RoomId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("HotelId");

                    b.Property<string>("RoomDescription");

                    b.Property<string>("RoomImage");

                    b.Property<int>("RoomPrice");

                    b.Property<string>("RoomType");

                    b.HasKey("RoomId");

                    b.HasIndex("HotelId");

                    b.ToTable("HotelRooms");
                });

            modelBuilder.Entity("coreHotelRoomBookingUserPanel.Models.Hotels", b =>
                {
                    b.Property<int>("HotelId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("HotelAddress");

                    b.Property<string>("HotelCity");

                    b.Property<long>("HotelContactNumber");

                    b.Property<string>("HotelCountry");

                    b.Property<string>("HotelDescription");

                    b.Property<string>("HotelDistrict");

                    b.Property<string>("HotelEmailId");

                    b.Property<string>("HotelImage");

                    b.Property<string>("HotelName");

                    b.Property<string>("HotelRating");

                    b.Property<string>("HotelState");

                    b.Property<int>("HotelTypeId");

                    b.HasKey("HotelId");

                    b.HasIndex("HotelTypeId");

                    b.ToTable("Hotels");
                });

            modelBuilder.Entity("coreHotelRoomBookingUserPanel.Models.HotelTypes", b =>
                {
                    b.Property<int>("HotelTypeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("HotelTypeDescription")
                        .IsRequired();

                    b.Property<string>("HotelTypeName")
                        .IsRequired();

                    b.Property<int?>("UserDetailUserId");

                    b.HasKey("HotelTypeId");

                    b.HasIndex("UserDetailUserId");

                    b.ToTable("HotelTypes");
                });

            modelBuilder.Entity("coreHotelRoomBookingUserPanel.Models.Payments", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookingId");

                    b.Property<int>("CustomerId");

                    b.Property<double>("PaymentAmount");

                    b.Property<DateTime>("PaymentDate");

                    b.Property<string>("PaymentDescription");

                    b.HasKey("PaymentId");

                    b.HasIndex("BookingId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("coreHotelRoomBookingUserPanel.Models.RoomFacilities", b =>
                {
                    b.Property<int>("RoomFacilityId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("AirConditioner");

                    b.Property<bool>("Ekettle");

                    b.Property<bool>("IsAvilable");

                    b.Property<bool>("Refrigerator");

                    b.Property<string>("RoomFacilityDescription");

                    b.Property<int>("RoomId");

                    b.Property<bool>("Wifi");

                    b.HasKey("RoomFacilityId");

                    b.HasIndex("RoomId")
                        .IsUnique();

                    b.ToTable("RoomFacilities");
                });

            modelBuilder.Entity("coreHotelRoomBookingUserPanel.Models.UserDetails", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("UserContactNumber");

                    b.Property<string>("UserEmailId");

                    b.Property<string>("UserName");

                    b.Property<string>("UserPassword");

                    b.Property<string>("UserType");

                    b.HasKey("UserId");

                    b.ToTable("UserDetails");
                });

            modelBuilder.Entity("coreHotelRoomBookingUserPanel.Models.BookingRecords", b =>
                {
                    b.HasOne("coreHotelRoomBookingUserPanel.Models.Bookings", "Booking")
                        .WithMany("BookingRecords")
                        .HasForeignKey("BookingId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("coreHotelRoomBookingUserPanel.Models.HotelRooms", "Room")
                        .WithMany("BookingRecords")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("coreHotelRoomBookingUserPanel.Models.Bookings", b =>
                {
                    b.HasOne("coreHotelRoomBookingUserPanel.Models.Customers", "Customer")
                        .WithMany("Bookings")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("coreHotelRoomBookingUserPanel.Models.HotelRooms", b =>
                {
                    b.HasOne("coreHotelRoomBookingUserPanel.Models.Hotels", "Hotel")
                        .WithMany("HotelRooms")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("coreHotelRoomBookingUserPanel.Models.Hotels", b =>
                {
                    b.HasOne("coreHotelRoomBookingUserPanel.Models.HotelTypes", "HotelType")
                        .WithMany("Hotels")
                        .HasForeignKey("HotelTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("coreHotelRoomBookingUserPanel.Models.HotelTypes", b =>
                {
                    b.HasOne("coreHotelRoomBookingUserPanel.Models.UserDetails", "UserDetailUser")
                        .WithMany("HotelTypes")
                        .HasForeignKey("UserDetailUserId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("coreHotelRoomBookingUserPanel.Models.Payments", b =>
                {
                    b.HasOne("coreHotelRoomBookingUserPanel.Models.Bookings", "Booking")
                        .WithMany("Payments")
                        .HasForeignKey("BookingId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("coreHotelRoomBookingUserPanel.Models.RoomFacilities", b =>
                {
                    b.HasOne("coreHotelRoomBookingUserPanel.Models.HotelRooms", "Room")
                        .WithOne("RoomFacilities")
                        .HasForeignKey("coreHotelRoomBookingUserPanel.Models.RoomFacilities", "RoomId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
