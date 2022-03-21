using Moq;
using RookieShop.Backend.Controllers;
using RookieTest.Mock;
using System;
using Xunit;

namespace RookieTest
{
    public class UnitTest1
    {
        [Fact]
        public void TeamService_Search_OlderThan_Valid()
        {
            //Arrange
            var mockProductControl = new MockProductsController()
                                   .MockGetProduct(new Team())
                                   .VerifyGetProduct(new List<Team>());

            var teamService = new ProductsController(mockProductControl.Object);

            //Act
            var result = teamService.GetProduct();

            //Assert
            mockProductControl.VerifyGetProduct(Times.Once());//Expect this to be called exactly once.
        }
    }
}
