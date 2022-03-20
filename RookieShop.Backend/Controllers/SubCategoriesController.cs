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
using RookieShop.Shared.Dto.SubCategory;
using RookieShop.Shared.Request;
using RookieShop.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RookieShop.Backend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [EnableCors("AllowOrigins")]
    [Authorize("Bearer")]
    public class SubCategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IFileStorageService _fileStorageService;

        public SubCategoriesController(
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
        public async Task<ActionResult<PagedResponseDto<SubCategoryDto>>> GetSubCategories(
            [FromQuery] SubCategoryCriteriaDto subCategoryCriteriaDto,
            CancellationToken cancellationToken)
        {
            var subCategories = _context
                                .SubCategories
                                .Where(x => !x.IsDeleted)
                                .Include(x => x.Category)
                                .AsQueryable();

            subCategories = SubCategoryFilter(subCategories, subCategoryCriteriaDto);

            var pagedSubCategories = await subCategories
                                .AsNoTracking()
                                .PaginateAsync(subCategoryCriteriaDto, cancellationToken);

            var subCategoryDtos = _mapper.Map<IEnumerable<SubCategoryDto>>(pagedSubCategories.Items);
            return new PagedResponseDto<SubCategoryDto>
            {
                CurrentPage = pagedSubCategories.CurrentPage,
                TotalPages = pagedSubCategories.TotalPages,
                TotalItems = pagedSubCategories.TotalItems,
                Search = subCategoryCriteriaDto.Search,
                SortColumn = subCategoryCriteriaDto.SortColumn,
                SortOrder = subCategoryCriteriaDto.SortOrder,
                Limit = subCategoryCriteriaDto.Limit,
                Items = subCategoryDtos
            };
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        //[Authorize(Policy = SecurityConstants.ADMIN_ROLE_POLICY)]
        public async Task<ActionResult<SubCategoryVm>> GetSubCategory(int id)
        {
            var subCategory = await _context
                                .SubCategories
                                .Where(x => !x.IsDeleted && x.SubCategoryId == id)
                                .FirstOrDefaultAsync();

            if (subCategory == null)
            {
                return NotFound();
            }

            var subCategoryVm = new SubCategoryVm
            {
                SubCategoryId = subCategory.SubCategoryId,
                Name = subCategory.Name,
                CategoryId = subCategory.CategoryId
            };

            if (subCategory.ImagePath != null)
            {
                subCategoryVm.ImagePath = _fileStorageService.GetFileUrl(subCategory.ImagePath);
            }

            return subCategoryVm;
        }

        [HttpGet("{categoryId}")]
        [AllowAnonymous]
        //[Authorize(Policy = SecurityConstants.ADMIN_ROLE_POLICY)]
        public async Task<ActionResult<PagedResponseDto<SubCategoryDto>>> GetSubCategoriesByCategoryId(
            int categoryId,
            [FromQuery] SubCategoryCriteriaDto subCategoryCriteriaDto,
            CancellationToken cancellationToken)
        {
            var subCategories = _context
                                .SubCategories
                                .Where(x => !x.IsDeleted)
                                .Where(x => x.CategoryId == categoryId)
                                .AsQueryable();

            subCategories = SubCategoryFilter(subCategories, subCategoryCriteriaDto);

            var pagedSubCategories = await subCategories
                                .AsNoTracking()
                                .PaginateAsync(subCategoryCriteriaDto, cancellationToken);

            var subCategoryDtos = _mapper.Map<IEnumerable<SubCategoryDto>>(pagedSubCategories.Items);
            return new PagedResponseDto<SubCategoryDto>
            {
                CurrentPage = pagedSubCategories.CurrentPage,
                TotalPages = pagedSubCategories.TotalPages,
                TotalItems = pagedSubCategories.TotalItems,
                Search = subCategoryCriteriaDto.Search,
                SortColumn = subCategoryCriteriaDto.SortColumn,
                SortOrder = subCategoryCriteriaDto.SortOrder,
                Limit = subCategoryCriteriaDto.Limit,
                Items = subCategoryDtos
            };
        }

        [HttpPut("{id}")]
        [Authorize(Policy = SecurityConstants.ADMIN_ROLE_POLICY)]
        public async Task<ActionResult> PutSubCategory([FromRoute] int id, [FromForm] SubCategoryCreateRequest subCategoryCreateRequest)
        {
            if (ModelState.IsValid)
                try
                {
                    var subCategory = await _context.SubCategories.FindAsync(id);

                    if (subCategory == null)
                    {
                        return NotFound();
                    }

                    if (!string.IsNullOrEmpty(subCategoryCreateRequest.Name))
                    {
                        subCategory.Name = subCategoryCreateRequest.Name;
                    }

                    if (subCategoryCreateRequest.CategoryId != 0)
                    {
                        subCategory.CategoryId = subCategoryCreateRequest.CategoryId;
                    }

                    if (subCategoryCreateRequest.ImageFile != null)
                    {
                        subCategory.ImagePath = await _fileStorageService.SaveFileAsync(subCategoryCreateRequest.ImageFile);
                    }

                    _context.SubCategories.Update(subCategory);
                    await _context.SaveChangesAsync();

                    return Ok(subCategory);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            else
            {
                return null;
            }
        }

        [HttpPost]
        [Authorize(Policy = SecurityConstants.ADMIN_ROLE_POLICY)]
        public async Task<ActionResult<BannerVm>> PostSubCategory([FromForm] SubCategoryCreateRequest subCategoryCreateRequest)
        {
            if (ModelState.IsValid)
                try
                {
                    var subCategory = new SubCategory
                    {
                        Name = subCategoryCreateRequest.Name,
                    };

                    if (subCategoryCreateRequest.CategoryId != 0)
                    {
                        subCategory.CategoryId = subCategoryCreateRequest.CategoryId;
                    }

                    if (subCategoryCreateRequest.ImageFile != null)
                    {
                        subCategory.ImagePath = await _fileStorageService.SaveFileAsync(subCategoryCreateRequest.ImageFile);
                    }

                    _context.SubCategories.Add(subCategory);
                    await _context.SaveChangesAsync();

                    return CreatedAtAction(
                        "GetSubCategory",
                        new { id = subCategory.SubCategoryId },
                        new SubCategoryVm
                        {
                            SubCategoryId = subCategory.SubCategoryId,
                            Name = subCategory.Name,
                            ImagePath = subCategory.ImagePath,
                            CategoryId = subCategory.CategoryId
                        });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            else
            {
                return null;
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = SecurityConstants.ADMIN_ROLE_POLICY)]
        public async Task<IActionResult> DeleteSubCategory(int id)
        {
            var subCategory = await _context.SubCategories.FindAsync(id);
            if (subCategory == null)
            {
                return NotFound();
            }

            //_context.SubCategories.Remove(subCategory);
            subCategory.IsDeleted = true;
            _context.SubCategories.Update(subCategory);
            await _context.SaveChangesAsync();

            return Ok(true);
        }

        #region Private Method
        private IQueryable<SubCategory> SubCategoryFilter(
            IQueryable<SubCategory> subCategories,
            SubCategoryCriteriaDto subCategoryCriteriaDto)
        {
            if (!String.IsNullOrEmpty(subCategoryCriteriaDto.Search))
            {
                subCategories = subCategories.Where(b =>
                    b.Name.Contains(subCategoryCriteriaDto.Search));
            }
            return subCategories;
        }
        #endregion
    }
}
