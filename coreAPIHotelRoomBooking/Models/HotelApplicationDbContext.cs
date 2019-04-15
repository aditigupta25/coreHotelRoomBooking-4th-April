using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coreAPIHotelRoomBooking.Models
{
    public class HotelApplicationDBContext : DbContext
    {
        public DbSet<HotelType> HotelTypes { get; set; }

        public DbSet<Hotel> Hotels { get; set; }

        public DbSet<HotelRoom> HotelRooms { get; set; }

        public DbSet<RoomFacility> RoomFacilities { get; set; }

        public DbSet<UserDetail> UserDetails { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Booking> Bookings { get; set; }

        public DbSet<BookingRecord> BookingRecords { get; set; }
        public DbSet<Feed> Feeds { get; set; }

        public HotelApplicationDBContext()
        {

        }

        public HotelApplicationDBContext(DbContextOptions<HotelApplicationDBContext> options)
           : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotel>().HasOne(h => h.HotelType).WithMany(b => b.Hotels).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<HotelType>().HasOne(h => h.UserDetail).WithMany(b => b.HotelTypes).OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Booking>().HasOne(h => h.Customer).WithMany(b => b.Bookings).OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<HotelRoom>().HasOne(h => h.Hotel).WithMany(b => b.HotelRooms).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<HotelType>(entity =>
            {
                entity.Property(e => e.HotelTypeName)
                .HasColumnName("HotelTypeName")
                .HasMaxLength(20)
                .IsUnicode(false);
            });

            modelBuilder.Entity<Hotel>(entity =>
            {
                entity.Property(e => e.HotelName)
                .HasColumnName("HotelName")
                .HasMaxLength(20)
                .IsUnicode(false);
            });

            modelBuilder.Entity<HotelRoom>(entity =>
            {
                entity.Property(e => e.RoomType)
                .HasColumnName("RoomType")
                .HasMaxLength(20)
                .IsUnicode(false);
            });

            modelBuilder.Entity<RoomFacility>(entity =>
            {
                entity.Property(e => e.RoomFacilityDescription)
                .HasColumnName("RoomFacilityDescription")
                .HasMaxLength(20)
                .IsUnicode(false);
            });


            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<BookingRecord>(
                build =>
                {
                    build.HasKey(t => new { t.BookingId, t.RoomId });
                }
                );

        }

    }
}
