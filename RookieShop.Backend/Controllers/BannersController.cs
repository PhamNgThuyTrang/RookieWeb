using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RookieShop.Backend.Data;
using RookieShop.BackEnd.Extension;
using RookieShop.BackEnd.Services;
using RookieShop.Shared.Constants;
using RookieShop.Shared.Dto;
using RookieShop.Shared.Dto.Banner;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using RookieShop.Backend.Models;
using RookieShop.Shared.ViewModels;
using RookieShop.Shared.Request;
using System;

namespace RookieShop.Backend.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowOrigins")]
    [ApiController]
    [Authorize("Bearer")]
    public class BannersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IFileStorageService _fileStorageService;

        public BannersController(
            ApplicationDbContext context,
            IFileStorageService fileStorageService,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _fileStorageService = fileStorageService;
        }

        [HttpGet]
        [AllowAnonymous]
        //[Authorize(Policy = SecurityConstants.ADMIN_ROLE_POLICY)]
        public async Task<ActionResult<PagedResponseDto<BannerDto>>> GetBanners(
            [FromQuery] BannerCriteriaDto bannerCriteriaDto,
            CancellationToken cancellationToken)
        {
            var banners =  _context
                                .Banners
                                .Where(x => !x.IsDeleted)
                                .AsQueryable();
            banners = BannerFilter(banners, bannerCriteriaDto);

            var pagedBanners = await banners
                                .AsNoTracking()
                                .PaginateAsync(bannerCriteriaDto, cancellationToken);

            var bannerDtos = _mapper.Map<IEnumerable<BannerDto>>(pagedBanners.Items);

            return new PagedResponseDto<BannerDto>
            {
                CurrentPage = pagedBanners.CurrentPage,
                TotalPages = pagedBanners.TotalPages,
                TotalItems = pagedBanners.TotalItems,
                Search = bannerCriteriaDto.Search,
                SortColumn = bannerCriteriaDto.SortColumn,
                SortOrder = bannerCriteriaDto.SortOrder,
                Limit = bannerCriteriaDto.Limit,
                Items = bannerDtos
            };
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        //[Authorize(Policy = SecurityConstants.ADMIN_ROLE_POLICY)]
        public async Task<ActionResult<BannerVm>> GetBanner(int id)
        {
            var banner = await _context
                                .Banners
                                .Where(x => !x.IsDeleted && x.BannerId == id)
                                .FirstOrDefaultAsync();

            if (banner == null)
            {
                return NotFound();
            }

            var bannerVm = new BannerVm
            {
                BannerId = banner.BannerId,
                Name = banner.Name,
                ImagePath = _fileStorageService.GetFileUrl(banner.ImagePath),
                DateUpload = banner.DateUpload
            };

            return bannerVm;
        }

        [HttpPut("{id}")]
        [Authorize(Policy = SecurityConstants.ADMIN_ROLE_POLICY)]
        public async Task<ActionResult> PutBanner([FromRoute] int id, [FromForm] BannerCreateRequest bannerCreateRequest)
        {
            var banner = await _context.Banners.FindAsync(id);

            if (banner == null)
            {
                return NotFound();
            }

            if (!string.IsNullOrEmpty(bannerCreateRequest.Name))
            {
                banner.Name = bannerCreateRequest.Name;
            }
            if (bannerCreateRequest.ImageFile != null)
            {
                banner.ImagePath = await _fileStorageService.SaveFileAsync(bannerCreateRequest.ImageFile);
            }

            _context.Banners.Update(banner);
            await _context.SaveChangesAsync();

            return Ok(banner);
        }

        [HttpPost]
        [Authorize(Policy = SecurityConstants.ADMIN_ROLE_POLICY)]
        public async Task<ActionResult<BannerVm>> PostBanner([FromForm] BannerCreateRequest bannerCreateRequest)
        {
            var banner = new Banner
            {
                Name = bannerCreateRequest.Name,
            };

            if (bannerCreateRequest.ImageFile != null)
            {
                banner.ImagePath = await _fileStorageService.SaveFileAsync(bannerCreateRequest.ImageFile);
            }

            _context.Banners.Add(banner);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBanner", new { id = banner.BannerId }, new BannerVm { BannerId = banner.BannerId, Name = banner.Name, ImagePath = banner.ImagePath, DateUpload = banner.DateUpload });
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = SecurityConstants.ADMIN_ROLE_POLICY)]
        public async Task<IActionResult> DeleteBanner(int id)
        {
            var banner = await _context.Banners.FindAsync(id);
            if (banner == null)
            {
                return NotFound();
            }

            //_context.Banners.Remove(banner);
            banner.IsDeleted = true;
            _context.Banners.Update(banner);
            await _context.SaveChangesAsync();

            return Ok(true);
        }

        #region Private Method
        private IQueryable<Banner> BannerFilter(
            IQueryable<Banner> banners,
            BannerCriteriaDto bannerCriteriaDto)
        {
            if (!String.IsNullOrEmpty(bannerCriteriaDto.Search))
            {
                banners = banners.Where(b =>
                    b.Name.Contains(bannerCriteriaDto.Search));
            }

            return banners;
        }
        #endregion
    }
}
