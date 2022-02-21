using AutoMapper;
using RookieShop.Backend.Helpers;
using RookieShop.Backend.Models;
using RookieShop.BackEnd.Services;
using RookieShop.Shared.Dto.Banner;
using RookieShop.Shared.Dto.Brand;
using RookieShop.Shared.Dto.Category;
using RookieShop.Shared.Dto.SubCategory;

namespace RookieShop.Backend.Data.Mapping
{
    public class AutoMapperProfile : Profile  
    {
        public AutoMapperProfile()  
        {  
            CreateMap<Brand, BrandDto>()
                .ForMember(src => src.ImagePath,
                           opts => opts
                                    .MapFrom(src => ImageHelper
                                                        .GetFileUrl(src.ImagePath)
                                            ));
            CreateMap<Banner, BannerDto>().ForMember(src => src.ImagePath,
                           opts => opts
                                    .MapFrom(src => ImageHelper
                                                        .GetFileUrl(src.ImagePath)
                                            ));
            CreateMap<Category, CategoryDto>().ForMember(src => src.ImagePath,
                           opts => opts
                                    .MapFrom(src => ImageHelper
                                                        .GetFileUrl(src.ImagePath)
                                            ));
            CreateMap<SubCategory, SubCategoryDto>().ForMember(src => src.ImagePath,
                           opts => opts
                                    .MapFrom(src => ImageHelper
                                                        .GetFileUrl(src.ImagePath)
                                            ));

        }
    }
}