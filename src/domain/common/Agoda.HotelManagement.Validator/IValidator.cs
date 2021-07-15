using System;
using System.Collections.Generic;
using System.Text;
using ApplicationException = Agoda.HotelManagement.Common.Exceptions.ApplicationException;

namespace Agoda.HotelManagement.Validator
{
    public interface IValidator
    {
        (int, ApplicationException) PayloadValidator(string payloadType, string name, string type);
    }
}
