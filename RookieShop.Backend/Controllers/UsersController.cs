using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RookieShop.Backend.Data;
using RookieShop.Backend.Models;
using RookieShop.BackEnd.Extension;
using RookieShop.BackEnd.Services;
using RookieShop.Shared.Constants;
using RookieShop.Shared.Dto;
using RookieShop.Shared.Dto.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RookieShop.Backend.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowOrigins")]
    [ApiController]
    [Authorize("Bearer")]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IFileStorageService _fileStorageService;

        public UsersController(
            ApplicationDbContext context,
            IFileStorageService fileStorageService,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _fileStorageService = fileStorageService;
        }

        [HttpGet]
        //[AllowAnonymous]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<PagedResponseDto<UserDto>>> GetUsers(
            [FromQuery] UserCritetiaDto userCriteriaDto,
            CancellationToken cancellationToken)
        {
            var users = _context
                                .Users
                                .Where(x => !x.IsDeleted)
                                .AsQueryable();

            users = UserFilter(users, userCriteriaDto);

            var pagedUsers = await users
                                .AsNoTracking()
                                .PaginateAsync(userCriteriaDto, cancellationToken);

            var userDtos = _mapper.Map<IEnumerable<UserDto>>(pagedUsers.Items);

            return new PagedResponseDto<UserDto>
            {
                CurrentPage = pagedUsers.CurrentPage,
                TotalPages = pagedUsers.TotalPages,
                TotalItems = pagedUsers.TotalItems,
                Search = userCriteriaDto.Search,
                SortColumn = userCriteriaDto.SortColumn,
                SortOrder = userCriteriaDto.SortOrder,
                Limit = userCriteriaDto.Limit,
                Items = userDtos
            };
        }

        #region Private Method
        private IQueryable<User> UserFilter(
            IQueryable<User> users,
            UserCritetiaDto userCritetiaDto)
        {
            if (!String.IsNullOrEmpty(userCritetiaDto.Search))
            {
                users = users.Where(b =>
                    b.UserName.Contains(userCritetiaDto.Search));
            }

            return users;
        }
        #endregion
    }
}
