using System;
using System.Collections.Generic;
using System.Text;
using Agoda.HotelManagement.Entities;
using Microsoft.EntityFrameworkCore;

namespace Agoda.HotelManagement.Infrastructure.DbContext
{
    public class HotelManagementDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public HotelManagementDbContext(DbContextOptions<HotelManagementDbContext> options) : base(options) { }
        public DbSet<Hotel> Hotel { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Hotel>().HasData(new {HotelId = 1, City = "Bangkok", Room = "Deluxe", Price = 1000});
            modelBuilder.Entity<Hotel>().HasData(new {HotelId = 2, City = "Amsterdam", Room = "Superior", Price = 2000 });
        }
    }
}
