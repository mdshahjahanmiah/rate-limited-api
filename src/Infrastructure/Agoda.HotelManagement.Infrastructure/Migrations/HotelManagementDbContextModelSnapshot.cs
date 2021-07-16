﻿// <auto-generated />
using Agoda.HotelManagement.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Agoda.HotelManagement.Infrastructure.Migrations
{
    [DbContext(typeof(HotelManagementDbContext))]
    partial class HotelManagementDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Agoda.HotelManagement.Entities.Hotel", b =>
                {
                    b.Property<int>("HotelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("Room")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HotelId");

                    b.ToTable("Hotel");

                    b.HasData(
                        new
                        {
                            HotelId = 1,
                            City = "Bangkok",
                            Price = 1000,
                            Room = "Deluxe"
                        },
                        new
                        {
                            HotelId = 2,
                            City = "Amsterdam",
                            Price = 2000,
                            Room = "Superior"
                        },
                        new
                        {
                            HotelId = 3,
                            City = "Ashburn",
                            Price = 1300,
                            Room = "Sweet Suite"
                        },
                        new
                        {
                            HotelId = 4,
                            City = "Amsterdam",
                            Price = 2200,
                            Room = "Deluxe"
                        },
                        new
                        {
                            HotelId = 5,
                            City = "Ashburn",
                            Price = 1200,
                            Room = "Sweet Suite"
                        },
                        new
                        {
                            HotelId = 6,
                            City = "Bangkok",
                            Price = 2000,
                            Room = "Superior"
                        },
                        new
                        {
                            HotelId = 7,
                            City = "Ashburn",
                            Price = 1600,
                            Room = "Deluxe"
                        },
                        new
                        {
                            HotelId = 8,
                            City = "Bangkok",
                            Price = 2400,
                            Room = "Superior"
                        },
                        new
                        {
                            HotelId = 9,
                            City = "Amsterdam",
                            Price = 30000,
                            Room = "Sweet Suite"
                        },
                        new
                        {
                            HotelId = 10,
                            City = "Ashburn",
                            Price = 1100,
                            Room = "Superior"
                        },
                        new
                        {
                            HotelId = 11,
                            City = "Bangkok",
                            Price = 60,
                            Room = "Deluxe"
                        },
                        new
                        {
                            HotelId = 12,
                            City = "Ashburn",
                            Price = 1800,
                            Room = "Deluxe"
                        },
                        new
                        {
                            HotelId = 13,
                            City = "Amsterdam",
                            Price = 1000,
                            Room = "Superior"
                        },
                        new
                        {
                            HotelId = 14,
                            City = "Bangkok",
                            Price = 25000,
                            Room = "Sweet Suite"
                        },
                        new
                        {
                            HotelId = 15,
                            City = "Bangkok",
                            Price = 900,
                            Room = "Deluxe"
                        },
                        new
                        {
                            HotelId = 16,
                            City = "Ashburn",
                            Price = 800,
                            Room = "Superior"
                        },
                        new
                        {
                            HotelId = 17,
                            City = "Ashburn",
                            Price = 2800,
                            Room = "Deluxe"
                        },
                        new
                        {
                            HotelId = 18,
                            City = "Bangkok",
                            Price = 5300,
                            Room = "Sweet Suite"
                        },
                        new
                        {
                            HotelId = 19,
                            City = "Ashburn",
                            Price = 1000,
                            Room = "Superior"
                        },
                        new
                        {
                            HotelId = 20,
                            City = "Ashburn",
                            Price = 4444,
                            Room = "Superior"
                        },
                        new
                        {
                            HotelId = 21,
                            City = "Ashburn",
                            Price = 7000,
                            Room = "Deluxe"
                        },
                        new
                        {
                            HotelId = 22,
                            City = "Ashburn",
                            Price = 14000,
                            Room = "Sweet Suite"
                        },
                        new
                        {
                            HotelId = 23,
                            City = "Amsterdam",
                            Price = 5000,
                            Room = "Deluxe"
                        },
                        new
                        {
                            HotelId = 24,
                            City = "Ashburn",
                            Price = 1400,
                            Room = "Superior"
                        },
                        new
                        {
                            HotelId = 25,
                            City = "Ashburn",
                            Price = 1900,
                            Room = "Deluxe"
                        },
                        new
                        {
                            HotelId = 26,
                            City = "Amsterdam",
                            Price = 2300,
                            Room = "Deluxe"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
