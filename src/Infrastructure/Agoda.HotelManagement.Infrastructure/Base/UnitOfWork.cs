using Agoda.HotelManagement.Infrastructure.DbContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agoda.HotelManagement.Infrastructure.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        public HotelManagementDbContext QueriesContext { get; }
        public UnitOfWork(HotelManagementDbContext queriesContext)
        {
            QueriesContext = queriesContext;
        }
    }
}
