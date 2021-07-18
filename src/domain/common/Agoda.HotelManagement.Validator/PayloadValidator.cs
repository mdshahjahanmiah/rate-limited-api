using Agoda.HotelManagement.Common.Enums;
using Agoda.HotelManagement.Common.Exceptions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using ApplicationException = Agoda.HotelManagement.Common.Exceptions.ApplicationException;

namespace Agoda.HotelManagement.Validator
{
    public class PayloadValidator : IValidator
    {
        (int, ApplicationException) IValidator.PayloadValidator(string payloadType, string name, string type)
        {
            int statusCode = StatusCodes.Status200OK;
            ApplicationException result = null;
            switch (payloadType)
            {
                case PayloadType.City:
                    if (string.IsNullOrEmpty(name))
                    {
                        statusCode = StatusCodes.Status422UnprocessableEntity;
                        result = new ApplicationException { ErrorCode = ApplicationErrorCodes.EmptyName, Data = new ErrorData() { Field = "city name", Message = ApplicationErrorCodes.GetMessage(ApplicationErrorCodes.EmptyName) } };
                    }
                    return (statusCode, result);

                case PayloadType.Room:
                    if (string.IsNullOrEmpty(type))
                    {
                        statusCode = StatusCodes.Status422UnprocessableEntity;
                        result = new ApplicationException { ErrorCode = ApplicationErrorCodes.EmptyName, Data = new ErrorData() { Field = "room type", Message = ApplicationErrorCodes.GetMessage(ApplicationErrorCodes.EmptyName) } };
                    }
                    return (statusCode, result);
            }

           
            return (statusCode, result);
        }
    }
}
