using AutoMapper;
using RookieShop.Backend.Helpers;
using RookieShop.Backend.Models;
using RookieShop.BackEnd.Services;
using RookieShop.Shared.Dto.Banner;
using RookieShop.Shared.Dto.Brand;
using RookieShop.Shared.Dto.Category;
using RookieShop.Shared.Dto.Product;
using RookieShop.Shared.Dto.ProductImage;
using RookieShop.Shared.Dto.ProductModel;
using RookieShop.Shared.Dto.ProductSize;
using RookieShop.Shared.Dto.Review;
using RookieShop.Shared.Dto.SubCategory;
using RookieShop.Shared.Dto.User;
using RookieShop.Shared.ViewModels;
using System.Collections.Generic;

namespace RookieShop.Backend.Data.Mapping
{
    public class AutoMapperProfile : Profile  
    {
        public AutoMapperProfile()  
        {
            CreateMap<Brand, BrandDto>();

            CreateMap<Banner, BannerDto>().ForMember(src => src.ImagePath,
                           opts => opts
                                    .MapFrom(src => ImageHelper
                                                        .GetFileUrl(src.ImagePath)
                                            ));

            CreateMap<Category, CategoryDto>();
            CreateMap<Category, CategoryVm>();

            CreateMap<SubCategory, SubCategoryDto>();
            CreateMap<SubCategory, SubCategoryVm>();

            CreateMap<ProductModel, ProductModelDto>();
            CreateMap<ProductModel, ProductModelVm>();

            CreateMap<Product, ProductDto>().ForMember(src => src.ImagePath,
                           opts => opts
                                    .MapFrom(src => ImageHelper
                                                        .GetFileUrl(src.ImagePath)
                                            ));

            CreateMap<ProductImage, ProductImageDto>().ForMember(src => src.ImagePath,
                           opts => opts
                                    .MapFrom(src => ImageHelper
                                                        .GetFileUrl(src.ImagePath)
                                            ));
            CreateMap<ProductImage, ProductImageVm>().ForMember(src => src.ImagePath,
                           opts => opts
                                    .MapFrom(src => ImageHelper
                                                        .GetFileUrl(src.ImagePath)
                                                ));
            CreateMap<List<ProductImage>, List<ProductImageVm>>();

            CreateMap<ProductSize, ProductSizeDto>();

            CreateMap<Review, ReviewDto>();

            CreateMap<User, UserDto>();

        }
    }
}