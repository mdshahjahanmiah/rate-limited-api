using Agoda.HotelManagement.Common.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Agoda.HotelManagement.Api.Filters
{
    public class GlobalExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var exceptionType = context.Exception.GetType();
            string errorCode, message, field;
            HttpStatusCode statusCode;
            
            if (exceptionType == typeof(DivideByZeroException))
            {
                message = ApplicationErrorCodes.GetMessage(ApplicationErrorCodes.InternalSeverError);
                errorCode = ApplicationErrorCodes.InternalSeverError;
                field = ApplicationErrorCodes.GetMessage(ApplicationErrorCodes.InternalSeverError);
                statusCode = HttpStatusCode.InternalServerError;
            }
            else if (exceptionType == typeof(SqlException))
            {
                message = ApplicationErrorCodes.GetMessage(ApplicationErrorCodes.DatabaseError);
                errorCode = ApplicationErrorCodes.DatabaseError;
                field = ApplicationErrorCodes.GetMessage(ApplicationErrorCodes.DatabaseError);
                statusCode = HttpStatusCode.BadGateway;
            }
            else
            {
                message = ApplicationErrorCodes.GetMessage(ApplicationErrorCodes.NotFound);
                errorCode = ApplicationErrorCodes.NotFound;
                field = ApplicationErrorCodes.GetMessage(ApplicationErrorCodes.NotFound);
                statusCode = HttpStatusCode.NotFound;
            }

            var error = new Common.Exceptions.ApplicationException
            {
                ErrorCode = errorCode,
                Data = new ErrorData(field, message)
            };

            context.HttpContext.Response.StatusCode = (int)statusCode;
            context.Result = new JsonResult(error);
        }
    }
}
