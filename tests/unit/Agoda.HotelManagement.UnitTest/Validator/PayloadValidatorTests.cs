using Agoda.HotelManagement.Api;
using Agoda.HotelManagement.Common.Enums;
using Agoda.HotelManagement.Common.Exceptions;
using Agoda.HotelManagement.UnitTest.Helpers;
using Agoda.HotelManagement.Validator;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Agoda.HotelManagement.UnitTest.Validator
{
    public class PayloadValidatorTests
    {
        private DependencyResolverHelper _serviceProvider;

        public PayloadValidatorTests()
        {
            var webHost = WebHost.CreateDefaultBuilder().UseStartup<Startup>().Build();
            _serviceProvider = new DependencyResolverHelper(webHost);
        }

        [Fact]
        public void ShouldReturnStatus422UnprocessableEntityForCity()
        {
            var _validator = _serviceProvider.GetService<IValidator>();
            var (status, errorResult) = _validator.PayloadValidator(PayloadType.City, string.Empty, string.Empty);
            Assert.Equal(StatusCodes.Status422UnprocessableEntity, status);
            Assert.Equal(ApplicationErrorCodes.EmptyName, errorResult.ErrorCode);
        }

        [Fact]
        public void ShouldReturnStatus422UnprocessableEntityForRoom()
        {
            var _validator = _serviceProvider.GetService<IValidator>();
            var (status, errorResult) = _validator.PayloadValidator(PayloadType.Room, string.Empty, string.Empty);
            Assert.Equal(StatusCodes.Status422UnprocessableEntity, status);
            Assert.Equal(ApplicationErrorCodes.EmptyName, errorResult.ErrorCode);
        }
    }
}
