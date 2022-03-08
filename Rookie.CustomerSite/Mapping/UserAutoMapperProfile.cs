using AutoMapper;
using Rookie.CustomerSite.ViewModel.User;
using RookieShop.Shared.Dto.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rookie.CustomerSite.Mapping
{
    public class UserAutoMapperProfile : Profile
    {
        public UserAutoMapperProfile()
        {
            CreateMap<UserDto, UserVm>().ReverseMap();
        }

    }
}
