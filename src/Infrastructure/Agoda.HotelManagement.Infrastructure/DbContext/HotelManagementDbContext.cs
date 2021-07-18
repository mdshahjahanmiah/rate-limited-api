using System;
using System.Collections.Generic;
using System.Text;
using Agoda.HotelManagement.DataObjects.Settings;
using Agoda.HotelManagement.Entities;
using Microsoft.EntityFrameworkCore;

namespace Agoda.HotelManagement.Infrastructure.DbContext
{
    public class HotelManagementDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        
        public HotelManagementDbContext(DbContextOptions<HotelManagementDbContext> options) : base(options)
        {
           
        }
        public DbSet<Hotel> Hotel { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Hotel>().HasData(new { HotelId = 1, City = "Bangkok", Room = "Deluxe", Price = 1000 });
            modelBuilder.Entity<Hotel>().HasData(new { HotelId = 2, City = "Amsterdam", Room = "Superior", Price = 2000 });
            modelBuilder.Entity<Hotel>().HasData(new { HotelId = 3, City = "Ashburn", Room = "Sweet Suite", Price = 1300 });
            modelBuilder.Entity<Hotel>().HasData(new { HotelId = 4, City = "Amsterdam", Room = "Deluxe", Price = 2200 });
            modelBuilder.Entity<Hotel>().HasData(new { HotelId = 5, City = "Ashburn", Room = "Sweet Suite", Price = 1200 });
            modelBuilder.Entity<Hotel>().HasData(new { HotelId = 6, City = "Bangkok", Room = "Superior", Price = 2000 });
            modelBuilder.Entity<Hotel>().HasData(new { HotelId = 7, City = "Ashburn", Room = "Deluxe", Price = 1600 });
            modelBuilder.Entity<Hotel>().HasData(new { HotelId = 8, City = "Bangkok", Room = "Superior", Price = 2400 });
            modelBuilder.Entity<Hotel>().HasData(new { HotelId = 9, City = "Amsterdam", Room = "Sweet Suite", Price = 30000 });
            modelBuilder.Entity<Hotel>().HasData(new { HotelId = 10, City = "Ashburn", Room = "Superior", Price = 1100 });
            modelBuilder.Entity<Hotel>().HasData(new { HotelId = 11, City = "Bangkok", Room = "Deluxe", Price = 60 });
            modelBuilder.Entity<Hotel>().HasData(new { HotelId = 12, City = "Ashburn", Room = "Deluxe", Price = 1800 });
            modelBuilder.Entity<Hotel>().HasData(new { HotelId = 13, City = "Amsterdam", Room = "Superior", Price = 1000 });
            modelBuilder.Entity<Hotel>().HasData(new { HotelId = 14, City = "Bangkok", Room = "Sweet Suite", Price = 25000 });
            modelBuilder.Entity<Hotel>().HasData(new { HotelId = 15, City = "Bangkok", Room = "Deluxe", Price = 900 });
            modelBuilder.Entity<Hotel>().HasData(new { HotelId = 16, City = "Ashburn", Room = "Superior", Price = 800 });
            modelBuilder.Entity<Hotel>().HasData(new { HotelId = 17, City = "Ashburn", Room = "Deluxe", Price = 2800 });
            modelBuilder.Entity<Hotel>().HasData(new { HotelId = 18, City = "Bangkok", Room = "Sweet Suite", Price = 5300 });
            modelBuilder.Entity<Hotel>().HasData(new { HotelId = 19, City = "Ashburn", Room = "Superior", Price = 1000 });
            modelBuilder.Entity<Hotel>().HasData(new { HotelId = 20, City = "Ashburn", Room = "Superior", Price = 4444 });
            modelBuilder.Entity<Hotel>().HasData(new { HotelId = 21, City = "Ashburn", Room = "Deluxe", Price = 7000 });
            modelBuilder.Entity<Hotel>().HasData(new { HotelId = 22, City = "Ashburn", Room = "Sweet Suite", Price = 14000 });
            modelBuilder.Entity<Hotel>().HasData(new { HotelId = 23, City = "Amsterdam", Room = "Deluxe", Price = 5000 });
            modelBuilder.Entity<Hotel>().HasData(new { HotelId = 24, City = "Ashburn", Room = "Superior", Price = 1400 });
            modelBuilder.Entity<Hotel>().HasData(new { HotelId = 25, City = "Ashburn", Room = "Deluxe", Price = 1900 });
            modelBuilder.Entity<Hotel>().HasData(new { HotelId = 26, City = "Amsterdam", Room = "Deluxe", Price = 2300 });
        }
    }
}
