using Agoda.HotelManagement.Common.Extensions;
using Agoda.HotelManagement.Common.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agoda.HotelManagement.Common.Exceptions
{
    public sealed class ApplicationErrorCodes : StringEnum
    {
        public ApplicationErrorCodes(string value) : base(value)
        {
        }
        public const string EmptyName = "EMPTY_CITY_NAME";
        public const string DatabaseError = "DATABASE_CONFIGURATION_ERROR";
        public const string InternalSeverError = "INTERNAL_SERVER_ERROR";
        public const string NotFound = "NOT_FOUND";

        public static string GetMessage(string value)
        {
            switch (value)
            {
                case EmptyName:
                    return ErrorMessage.EmptyName;
                case DatabaseError:
                    return ErrorMessage.DatabaseError;
                case InternalSeverError:
                    return ErrorMessage.InternalSeverError;
                case NotFound:
                    return ErrorMessage.NotFound;
                default:
                    throw new ArgumentOutOfRangeException(nameof(value), value, null);
            }
        }
    }
}
