using Agoda.HotelManagement.Infrastructure.DbContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agoda.HotelManagement.Infrastructure.Base
{
    public interface IUnitOfWork
    {
        HotelManagementDbContext QueriesContext { get; }
    }
}
