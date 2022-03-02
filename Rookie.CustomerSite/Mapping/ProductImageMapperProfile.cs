using AutoMapper;
using Rookie.CustomerSite.ViewModel;
using Rookie.CustomerSite.ViewModel.ProductImage;
using RookieShop.Shared.Dto;
using RookieShop.Shared.Dto.ProductImage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rookie.CustomerSite.Mapping
{
    public class ProductImageMapperProfile : Profile
    {
        public ProductImageMapperProfile()
        {
            CreateMap<ProductImageDto, ProductImageVm>().ReverseMap();
            CreateMap<BaseQueryCriteriaDto, BaseQueryCriteriaVM>().ReverseMap();
            CreateMap<PagedResponseDto<ProductImageDto>, PagedResponseVM<ProductImageVm>>().ReverseMap();
        }
    }
}
