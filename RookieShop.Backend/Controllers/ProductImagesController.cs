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
using RookieShop.Shared.Dto.ProductImage;
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
    [EnableCors("AllowOrigins")]
    [Authorize("Bearer")]
    [ApiController]
    public class ProductImagesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IFileStorageService _fileStorageService;

        public ProductImagesController(
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
        public async Task<ActionResult<PagedResponseDto<ProductImageDto>>> GetProductImages(
            [FromQuery] ProductImageCriteriaDto productImageCriteriaDto,
            CancellationToken cancellationToken)
        {
            var productImages = _context
                                .ProductImages
                                .Where(x => !x.IsDeleted)
                                .AsQueryable();

            var pagedProductImages = await productImages
                                .AsNoTracking()
                                .PaginateAsync(productImageCriteriaDto, cancellationToken);

            var productImagesDtos = _mapper.Map<IEnumerable<ProductImageDto>>(pagedProductImages.Items);

            return new PagedResponseDto<ProductImageDto>
            {
                CurrentPage = pagedProductImages.CurrentPage,
                TotalPages = pagedProductImages.TotalPages,
                TotalItems = pagedProductImages.TotalItems,
                Search = productImageCriteriaDto.Search,
                SortColumn = productImageCriteriaDto.SortColumn,
                SortOrder = productImageCriteriaDto.SortOrder,
                Limit = productImageCriteriaDto.Limit,
                Items = productImagesDtos
            };
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        //[Authorize(Policy = SecurityConstants.ADMIN_ROLE_POLICY)]
        public async Task<ActionResult<ProductImageVm>> GetProductImage(int id)
        {
            var productImage = await _context
                                .ProductImages
                                .Where(x => !x.IsDeleted && x.ProductImageId == id)
                                .FirstOrDefaultAsync();

            if (productImage == null)
            {
                return NotFound();
            }

            var productImageVm = new ProductImageVm
            {
                ProductImageId = productImage.ProductImageId,
                ProductId = productImage.ProductId,
                ImagePath = _fileStorageService.GetFileUrl(productImage.ImagePath),
            };

            return productImageVm;
        }

        [HttpPut("{id}")]
        [Authorize(Policy = SecurityConstants.ADMIN_ROLE_POLICY)]
        public async Task<ActionResult> PutProductImage([FromRoute] int id, [FromForm] ProductImageCreateRequest productImageCreateRequest)
        {
            var productImage = await _context.ProductImages.FindAsync(id);

            if (productImage == null)
            {
                return NotFound();
            }

            if (productImageCreateRequest.ProductId != 0)
            {
                productImage.ProductId = productImageCreateRequest.ProductId;
            }
            if (productImageCreateRequest.ImageFile != null)
            {
                productImage.ImagePath = await _fileStorageService.SaveFileAsync(productImageCreateRequest.ImageFile);
            }

            _context.ProductImages.Update(productImage);
            await _context.SaveChangesAsync();

            return Ok(productImage);
        }

        [HttpPost]
        [Authorize(Policy = SecurityConstants.ADMIN_ROLE_POLICY)]
        public async Task<ActionResult<BannerVm>> PostProductImage([FromForm] ProductImageCreateRequest productImageCreateRequest)
        {
            var productImage = new ProductImage
            {
                ProductId = productImageCreateRequest.ProductId,
            };
            if (productImageCreateRequest.ImageFile != null)
            {
                productImage.ImagePath = await _fileStorageService.SaveFileAsync(productImageCreateRequest.ImageFile);
            }

            _context.ProductImages.Add(productImage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductImage",
                                    new { id = productImage.ProductImageId },
                                    new ProductImageVm
                                    {
                                        ProductImageId = productImage.ProductImageId,
                                        ProductId = productImage.ProductId,
                                        ImagePath = productImage.ImagePath
                                    });
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = SecurityConstants.ADMIN_ROLE_POLICY)]
        public async Task<IActionResult> DeleteProductImage(int id)
        {
            var productImage = await _context.ProductImages.FindAsync(id);
            if (productImage == null)
            {
                return NotFound();
            }

            //_context.ProductImages.Remove(productImage);
            productImage.IsDeleted = true;
            _context.ProductImages.Update(productImage);
            await _context.SaveChangesAsync();
            return Ok(true);
        }

        #region Private Method
        private IQueryable<ProductImage> ProductImageFilter(
            IQueryable<ProductImage> productImages,
            ProductImageCriteriaDto productImageCriteriaDto)
        {
            if (productImageCriteriaDto.ProductId != 0)
            {
                productImages = productImages.Where(x => x.ProductId == productImageCriteriaDto.ProductId);
            }

            if (!String.IsNullOrEmpty(productImageCriteriaDto.Search))
            {
                productImages = productImages.Where(b =>
                    b.ProductImageId.ToString() == productImageCriteriaDto.Search);
            }

            return productImages;
        }
        #endregion
    }
}
