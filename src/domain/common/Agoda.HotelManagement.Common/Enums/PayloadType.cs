using Agoda.HotelManagement.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agoda.HotelManagement.Common.Enums
{
    public sealed class PayloadType : StringEnum
    {
        public PayloadType(string value) : base(value) { }
        public const string City = "city";
        public const string Room = "room";
    }
}
