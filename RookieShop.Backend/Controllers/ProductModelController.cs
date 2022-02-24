using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RookieShop.Backend.Data;
using RookieShop.Backend.Models;
using RookieShop.BackEnd.Extension;
using RookieShop.BackEnd.Services;
using RookieShop.Shared.Constants;
using RookieShop.Shared.Dto;
using RookieShop.Shared.Dto.ProductModel;
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
    public class ProductModelController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IFileStorageService _fileStorageService;

        public ProductModelController(
            ApplicationDbContext context, 
            IMapper mapper,
            IFileStorageService fileStorageService)
        {
            _context = context;
            _mapper = mapper;
            _fileStorageService = fileStorageService;
        }

        [HttpGet]
        [AllowAnonymous]
        //[Authorize(Policy = SecurityConstants.ADMIN_ROLE_POLICY)]
        public async Task<ActionResult<PagedResponseDto<ProductModelDto>>> GetProductModels(
            [FromQuery] ProductModelCriteriaDto productModelCriteriaDto,
            CancellationToken cancellationToken)
        {
            var productModels = _context
                                .ProductModels
                                .Where(x => !x.IsDeleted)
                                .AsQueryable();

            var pagedProductModels = await productModels
                                .AsNoTracking()
                                .PaginateAsync(productModelCriteriaDto, cancellationToken);

            var productModelsDtos = _mapper.Map<IEnumerable<ProductModelDto>>(pagedProductModels.Items);

            return new PagedResponseDto<ProductModelDto>
            {
                CurrentPage = pagedProductModels.CurrentPage,
                TotalPages = pagedProductModels.TotalPages,
                TotalItems = pagedProductModels.TotalItems,
                Search = productModelCriteriaDto.Search,
                SortColumn = productModelCriteriaDto.SortColumn,
                SortOrder = productModelCriteriaDto.SortOrder,
                Limit = productModelCriteriaDto.Limit,
                Items = productModelsDtos
            };
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        //[Authorize(Policy = SecurityConstants.ADMIN_ROLE_POLICY)]
        public async Task<ActionResult<ProductModelVm>> GetProductModel(int id)
        {
            var productModel = await _context
                                .ProductModels
                                .Where(x => !x.IsDeleted && x.ProductModelId == id)
                                .FirstOrDefaultAsync();

            if (productModel == null)
            {
                return NotFound();
            }

            var productModelVm = new ProductModelVm
            {
                ProductModelId = productModel.ProductModelId,
                BrandId = productModel.BrandId,
                SubCategoryId = productModel.SubCategoryId,
                Products = _mapper.Map<List<ProductVm>>(productModel.Products)
            };

            return productModelVm;
        }

        [HttpPut("{id}")]
        [Authorize(Policy = SecurityConstants.ADMIN_ROLE_POLICY)]
        public async Task<ActionResult> PutProductModel([FromRoute] int id, [FromForm] ProductModelCreateRequest productModelCreateRequest)
        {
            var productModel = await _context.ProductModels.FindAsync(id);

            if (productModel == null)
            {
                return NotFound();
            }

            if (productModelCreateRequest.SubCategoryId != 0 )
            {
                productModel.SubCategoryId = productModelCreateRequest.SubCategoryId;
            }
            if (productModelCreateRequest.BrandId != 0 )
            {
                productModel.BrandId = productModelCreateRequest.BrandId;
            }
            
            _context.ProductModels.Update(productModel);
            await _context.SaveChangesAsync();

            return Ok(productModel);
        }

        [HttpPost]
        [Authorize(Policy = SecurityConstants.ADMIN_ROLE_POLICY)]
        public async Task<ActionResult<BannerVm>> PostProductModel([FromForm] ProductModelCreateRequest productModelCreateRequest)
        {
            var productModel = new ProductModel
            {
                BrandId = productModelCreateRequest.BrandId,
                SubCategoryId = productModelCreateRequest.SubCategoryId,
            };

            _context.ProductModels.Add(productModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductModel", 
                                    new { id = productModel.ProductModelId }, 
                                    new ProductModelVm 
                                    { 
                                        ProductModelId = productModel.ProductModelId, 
                                        SubCategoryId = productModel.SubCategoryId, 
                                        BrandId = productModel.BrandId
                                    });
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = SecurityConstants.ADMIN_ROLE_POLICY)]
        public async Task<IActionResult> DeleteProductModel(int id)
        {
            var productModel = await _context.ProductModels.FindAsync(id);
            if (productModel == null)
            {
                return NotFound();
            }

            //_context.Banners.Remove(brand);
            productModel.IsDeleted = true;
            _context.ProductModels.Update(productModel);
            await _context.SaveChangesAsync();
            return Ok(true);
        }
    }
}
