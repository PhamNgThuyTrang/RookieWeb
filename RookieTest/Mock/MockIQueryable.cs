using Moq;
using RookieShop.Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RookieTest.Mock
{
	class MockIQueryable
	{
		public class FakeBrandIQueryable
		{
			public FakeBrandIQueryable()
			{
				var data = new List<Brand>
				{
					new Brand(){
						BrandId = 10000,
						Name = "AAA",
						Type = 1,
						ImagePath = "",
						IsDeleted = false
					},

					new Brand() {
						BrandId = 13000,
						Name = "BBB",
						Type = 1,
						ImagePath = "",
						IsDeleted = false
					},
					new Brand() {
						BrandId = 20000,
						Name = "CCC",
						Type = 1,
						ImagePath = "",
						IsDeleted = false
					},
				}.AsQueryable();

				MockBrands = new Mock<IQueryable<Brand>>();
				MockBrands.As<IQueryable<Brand>>().Setup(m => m.Provider).Returns(data.Provider);
				MockBrands.As<IQueryable<Brand>>().Setup(m => m.Expression).Callback(() => ExpressionCalls++).Returns(data.Expression);
				MockBrands.As<IQueryable<Brand>>().Setup(m => m.ElementType).Returns(data.ElementType);
				MockBrands.As<IQueryable<Brand>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

				Brands = MockBrands.Object;
			}

			public int ExpressionCalls { get; private set; }

			public IQueryable<Brand> Brands { get; }

			public Mock<IQueryable<Brand>> MockBrands { get; }
		}
	}
}
