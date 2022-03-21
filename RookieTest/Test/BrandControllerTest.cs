using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Rookie.CustomerSite.Controllers;
using RookieShop.Backend.Controllers;
using RookieShop.Backend.Data.Mapping;
using RookieShop.Backend.Models;
using RookieShop.BackEnd.Services;
using RookieShop.Shared.Dto.Brand;
using RookieTest.Mock;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Xunit;
using static RookieTest.Mock.MockIQueryable;

namespace RookieTest.Test
{
    public class BrandControllerTest
    {
        
        private static IMapper _mapper;
        private readonly IFileStorageService _fileStorageService;

        public BrandControllerTest()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new AutoMapperProfile());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
        }

        [Fact]
        public void GetBrands_CheckNameAndType_BrandsExist()
        {
            //Arrange
            var fakeBrandIQueryable = new FakeBrandIQueryable();

            var mockBrandRepository = new MockBrandRepository().MockGetAll(fakeBrandIQueryable.Brands);

            var controller = new BrandsController(mockBrandRepository.Object, _mapper, _fileStorageService);
            var brandCriteriaDto = new BrandCriteriaDto();
            var cancellationToken = new CancellationToken();

            ////Act
            var result = controller.GetBrands(brandCriteriaDto, cancellationToken);

            ////Assert
            var products = result.Result.Value.Items;
            var fisrtProduct = products.FirstOrDefault();
            var lastProduct = products.LastOrDefault();
            Assert.NotEmpty(products);
            Assert.Equal("AAA", fisrtProduct.Name);
            Assert.Equal("CCC", lastProduct.Name);
        }
        
        [Fact]
        public void GetBrands_SearchName_BrandsExist()
        {
            //Arrange
            var fakeBrandIQueryable = new FakeBrandIQueryable();

            var mockBrandRepository = new MockBrandRepository().MockGetAll(fakeBrandIQueryable.Brands);

            var controller = new BrandsController(mockBrandRepository.Object, _mapper, _fileStorageService);
            var brandCriteriaDto = new BrandCriteriaDto()
            {
                Search = "A"
            };
            var cancellationToken = new CancellationToken();

            ////Act
            var result = controller.GetBrands(brandCriteriaDto, cancellationToken);

            ////Assert
            var products = result.Result.Value.Items;
            var fisrtProduct = products.FirstOrDefault();
            Assert.NotEmpty(products);
            Assert.Contains("A", fisrtProduct.Name);
        }
        
        [Fact]
        public void GetBrands_SearchName_BrandsNotExist()
        {
            //Arrange
            var fakeBrandIQueryable = new FakeBrandIQueryable();

            var mockBrandRepository = new MockBrandRepository().MockGetAll(fakeBrandIQueryable.Brands);

            var controller = new BrandsController(mockBrandRepository.Object, _mapper, _fileStorageService);
            var brandCriteriaDto = new BrandCriteriaDto()
            {
                Search = "D"
            };
            var cancellationToken = new CancellationToken();

            ////Act
            var result = controller.GetBrands(brandCriteriaDto, cancellationToken);

            ////Assert
            var products = result.Result.Value.Items;
            var fisrtProduct = products.FirstOrDefault();
            Assert.Empty(products);
        }


        [Fact]
        public void GetBrand_CheckExist_BrandExist()
        {
            //Arrange
            var mockBrand = new Brand() {
                BrandId = 10000,
                Name = "AAA",
                Type = 1,
                ImagePath = "",
                IsDeleted = false
            };

            var mockBrandRepository = new MockBrandRepository().MockGetById(mockBrand);

            var controller = new BrandsController(mockBrandRepository.Object, _mapper, _fileStorageService);

            ////Act
            var result = controller.GetBrand(10000);

            ////Assert
            Assert.NotNull(result);
        }
    }
}

