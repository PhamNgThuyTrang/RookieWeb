using AutoMapper;
using Rookie.CustomerSite.ViewModel.SubCategory;
using Rookie.CustomerSite.ViewModel;
using RookieShop.Shared.Dto.SubCategory;
using RookieShop.Shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rookie.CustomerSite.Mapping
{
    public class SubCategoryAutoMapperProfile : Profile
    {
        public SubCategoryAutoMapperProfile()
        {
            CreateMap<SubCategoryDto, SubCategoryVm>().ReverseMap();
            CreateMap<BaseQueryCriteriaDto, BaseQueryCriteriaVM>().ReverseMap();
            CreateMap<PagedResponseDto<SubCategoryDto>, PagedResponseVM<SubCategoryVm>>().ReverseMap();
        }
    }
}
