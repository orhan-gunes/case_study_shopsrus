

using AutoFixture;
using Microsoft.AspNetCore.Http;
using Moq;
using shopsrus.Infrastructure;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.TestHelpers;
using Xunit;


namespace Tests
{
    public class UserServiceTests
    {
        private readonly Fixture _fixture;
        private Mock<IAppDbContext> _dbMock;
        private Mock<IRedisService> _redisMock;   
        private Mock<IHttpContextAccessor> _accessorMock;
      
       
        public UserServiceTests()
        {
             _fixture = new Fixture();
             _dbMock = new Mock<IAppDbContext>();  
            _redisMock = new Mock<IRedisService>(); 
            _accessorMock = new Mock<IHttpContextAccessor>();

               
        }

        [Fact]
        public async Task GetAppDinemsions_test() 
        {


            var result = "";

            /// Assert
            result.ShouldNotBeNull();
            


        }

    }
}
