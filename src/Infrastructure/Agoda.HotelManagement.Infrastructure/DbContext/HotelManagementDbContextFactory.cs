using Agoda.HotelManagement.DataObjects.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agoda.HotelManagement.Infrastructure.DbContext
{
    public class HotelManagementDbContextFactory : IDesignTimeDbContextFactory<HotelManagementDbContext>
    {
        private readonly AppSettings _appSettings;
        public HotelManagementDbContextFactory(AppSettings appSettings)
        {
            _appSettings = appSettings;
        }
        public HotelManagementDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<HotelManagementDbContext>();
            optionsBuilder.UseSqlServer(_appSettings.ConnectionStrings.SqlServer.Queries);
            return new HotelManagementDbContext(optionsBuilder.Options);
        }
    }
}
