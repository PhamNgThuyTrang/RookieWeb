using Moq;
using RookieShop.Backend.Interface;
using RookieShop.Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RookieTest.Mock
{
    class MockBrandRepository : Mock<IBrandRepository>
    {
        public MockBrandRepository MockGetAll(IQueryable<Brand> results)
        {
            Setup(x => x.GetAll())
                .Returns(results);
            return this;
        }

        public MockBrandRepository MockGetById(Brand result)
        {
            Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(result);
            return this;
        }
    }
}
