using Agoda.HotelManagement.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agoda.HotelManagement.Common.Enums
{
    public sealed class SortType : StringEnum
    {
        public SortType(string value) : base(value) { }
        public const string ASC = "ASC";
        public const string DESC = "DESC";

        public static bool IsDescending(string value)
        {
            switch (value)
            {
                case ASC:
                    return false;
                case DESC:
                    return true;
            }
            return false;
        }
    }
}
