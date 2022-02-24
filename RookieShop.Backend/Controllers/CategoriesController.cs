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
using RookieShop.Shared.Dto.Category;
using RookieShop.Shared.Request;
using RookieShop.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RookieShop.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigins")]
    [Authorize("Bearer")]
    public class CategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IFileStorageService _fileStorageService;

        public CategoriesController(
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
        public async Task<ActionResult<PagedResponseDto<CategoryDto>>> GetCategories(
            [FromQuery] CategoryCriteriaDto categoryCriteriaDto,
            CancellationToken cancellationToken)
        {
            var categories = _context
                                .Categories
                                .Where(x => !x.IsDeleted)
                                .AsQueryable();
            categories = CategoryFilter(categories, categoryCriteriaDto);


            var pagedCategories = await categories
                                .AsNoTracking()
                                .PaginateAsync(categoryCriteriaDto, cancellationToken);

            var categoryDtos = _mapper.Map<IEnumerable<CategoryDto>>(pagedCategories.Items);
            return new PagedResponseDto<CategoryDto>
            {
                CurrentPage = pagedCategories.CurrentPage,
                TotalPages = pagedCategories.TotalPages,
                TotalItems = pagedCategories.TotalItems,
                Search = categoryCriteriaDto.Search,
                SortColumn = categoryCriteriaDto.SortColumn,
                SortOrder = categoryCriteriaDto.SortOrder,
                Limit = categoryCriteriaDto.Limit,
                Items = categoryDtos
            };
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        //[Authorize(Policy = SecurityConstants.ADMIN_ROLE_POLICY)]
        public async Task<ActionResult<CategoryVm>> GetCategory(int id)
        {
            var category = await _context
                                .Categories
                                .Where(x => !x.IsDeleted && x.CategoryId == id)
                                .FirstOrDefaultAsync();

            if (category == null)
            {
                return NotFound();
            }

            var categoryVm = new CategoryVm
            {
                CategoryId = category.CategoryId,
                Name = category.Name,
            };

            if(category.ImagePath != null)
            {
                categoryVm.ImagePath = _fileStorageService.GetFileUrl(category.ImagePath);
            }

            return categoryVm;
        }

        [HttpPut("{id}")]
        [Authorize(Policy = SecurityConstants.ADMIN_ROLE_POLICY)]
        public async Task<ActionResult> PutCategory([FromRoute] int id, [FromForm] CategoryCreateRequest categoryCreateRequest)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            if (!string.IsNullOrEmpty(categoryCreateRequest.Name))
            {
                category.Name = categoryCreateRequest.Name;
            }
            if (categoryCreateRequest.ImageFile != null)
            {
                category.ImagePath = await _fileStorageService.SaveFileAsync(categoryCreateRequest.ImageFile);
            }

            _context.Categories.Update(category);
            await _context.SaveChangesAsync();

            return Ok(category);
        }

        [HttpPost]
        [Authorize(Policy = SecurityConstants.ADMIN_ROLE_POLICY)]
        public async Task<ActionResult<BannerVm>> PostCategory([FromForm] CategoryCreateRequest categoryCreateRequest)
        {
            var category = new Category
            {
                Name = categoryCreateRequest.Name,
            };

            if (categoryCreateRequest.ImageFile != null)
            {
                category.ImagePath = await _fileStorageService.SaveFileAsync(categoryCreateRequest.ImageFile);
            }

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategory", new { id = category.CategoryId }, new CategoryVm { CategoryId = category.CategoryId, Name = category.Name, ImagePath = category.ImagePath });
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = SecurityConstants.ADMIN_ROLE_POLICY)]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            //_context.Categories.Remove(brand);
            category.IsDeleted = true;
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();

            return Ok(true);
        }

        #region Private Method
        private IQueryable<Category> CategoryFilter(
            IQueryable<Category> categories,
            CategoryCriteriaDto categoryCriteriaDto)
        {
            if (!String.IsNullOrEmpty(categoryCriteriaDto.Search))
            {
                categories = categories.Where(b =>
                    b.Name.Contains(categoryCriteriaDto.Search));
            }

            return categories;
        }
        #endregion
    }
}
