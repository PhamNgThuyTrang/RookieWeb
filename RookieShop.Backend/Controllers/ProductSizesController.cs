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
using RookieShop.Shared.Dto.ProductSize;
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
    public class ProductSizesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IFileStorageService _fileStorageService;

        public ProductSizesController(
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
        public async Task<ActionResult<PagedResponseDto<ProductSizeDto>>> GetProductSizes(
            [FromQuery] ProductSizeCriteriaDto productSizeCriteriaDto,
            CancellationToken cancellationToken)
        {
            var productSizes = _context
                                .ProductSizes
                                .Where(x => !x.IsDeleted)
                                .AsQueryable();
            productSizes = ProductSizeFilter(productSizes, productSizeCriteriaDto);


            var pagedProductSizes = await productSizes
                                .AsNoTracking()
                                .PaginateAsync(productSizeCriteriaDto, cancellationToken);

            var productSizesDtos = _mapper.Map<IEnumerable<ProductSizeDto>>(pagedProductSizes.Items);
            return new PagedResponseDto<ProductSizeDto>
            {
                CurrentPage = pagedProductSizes.CurrentPage,
                TotalPages = pagedProductSizes.TotalPages,
                TotalItems = pagedProductSizes.TotalItems,
                Search = productSizeCriteriaDto.Search,
                SortColumn = productSizeCriteriaDto.SortColumn,
                SortOrder = productSizeCriteriaDto.SortOrder,
                Limit = productSizeCriteriaDto.Limit,
                Items = productSizesDtos
            };
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        //[Authorize(Policy = SecurityConstants.ADMIN_ROLE_POLICY)]
        public async Task<ActionResult<ProductSizeVm>> GetProductSize(int id)
        {
            var productSize = await _context
                                .ProductSizes
                                .Where(x => !x.IsDeleted && x.ProductSizeId == id)
                                .FirstOrDefaultAsync();

            if (productSize == null)
            {
                return NotFound();
            }

            var productSizeVm = new ProductSizeVm
            {
                ProductSizeId = productSize.ProductSizeId,
                Size = productSize.Size,
                Quantity = productSize.Quantity,
                ProductId = productSize.ProductId,
            };

            return productSizeVm;
        }

        [HttpPut("{id}")]
        [Authorize(Policy = SecurityConstants.ADMIN_ROLE_POLICY)]
        public async Task<ActionResult> PutProductSize(
                [FromRoute] int id, 
                [FromForm] ProductSizeCreateRequest productSizeCreateRequest)
        {
            var productSize = await _context.ProductSizes.FindAsync(id);

            if (productSize == null)
            {
                return NotFound();
            }

            productSize.Size = productSizeCreateRequest.Size;
            productSize.Quantity = productSizeCreateRequest.Quantity;
            productSize.ProductId = productSizeCreateRequest.ProductId;

            _context.ProductSizes.Update(productSize);
            await _context.SaveChangesAsync();

            return Ok(productSize);
        }

        [HttpPost]
        [Authorize(Policy = SecurityConstants.ADMIN_ROLE_POLICY)]
        public async Task<ActionResult<BannerVm>> PostProductSize([FromForm] ProductSizeCreateRequest productSizeCreateRequest)
        {
            var productSize = new ProductSize
            {
                Size = productSizeCreateRequest.Size,
                Quantity = productSizeCreateRequest.Quantity,
                ProductId = productSizeCreateRequest.ProductId
            };

            _context.ProductSizes.Add(productSize);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductSize", new { id = productSize.ProductId },
                                    new ProductSizeVm
                                    {
                                        ProductSizeId = productSize.ProductSizeId,
                                        Size = productSize.Size,
                                        Quantity = productSize.Quantity,
                                        ProductId = productSize.ProductId
                                    });
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = SecurityConstants.ADMIN_ROLE_POLICY)]
        public async Task<IActionResult> DeleteProductSize(int id)
        {
            var productSize = await _context.ProductSizes.FindAsync(id);
            if (productSize == null)
            {
                return NotFound();
            }

            //_context.ProductSizes.Remove(productSize);
            productSize.IsDeleted = true;
            _context.ProductSizes.Update(productSize);
            await _context.SaveChangesAsync();

            return Ok(true);
        }

        #region Private Method
        private IQueryable<ProductSize> ProductSizeFilter(
            IQueryable<ProductSize> products,
            ProductSizeCriteriaDto productSizeCriteriaDto)
        {
            if (productSizeCriteriaDto.ProductId != 0)
            {
                products = products.Where(x => x.ProductId == productSizeCriteriaDto.ProductId);
            }

            if (!String.IsNullOrEmpty(productSizeCriteriaDto.Search))
            {
                products = products.Where(b =>
                    b.Size.Contains(productSizeCriteriaDto.Search));
            }

            return products;
        }
        #endregion
    }
}
