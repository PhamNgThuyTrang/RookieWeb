using AutoMapper;
using Rookie.CustomerSite.ViewModel;
using Rookie.CustomerSite.ViewModel.Review;
using RookieShop.Shared.Dto;
using RookieShop.Shared.Dto.Review;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rookie.CustomerSite.Mapping
{
    public class ReviewAutoMapperProfile: Profile
    {
        public ReviewAutoMapperProfile()
        {
            CreateMap<ReviewDto, ReviewVm>().ReverseMap();
            CreateMap<BaseQueryCriteriaDto, BaseQueryCriteriaVM>().ReverseMap();
            CreateMap<PagedResponseDto<ReviewDto>, PagedResponseVM<ReviewVm>>().ReverseMap();
        }
    }
}
