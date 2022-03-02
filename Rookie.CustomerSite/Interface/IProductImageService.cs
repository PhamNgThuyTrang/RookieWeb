using RookieShop.Shared.Dto;
using RookieShop.Shared.Dto.ProductImage;
using System.Threading.Tasks;

public interface IProductImageService
{
    Task<PagedResponseDto<ProductImageDto>> GetProductImageAsync(ProductImageCriteriaDto productImageCriteriaDto);
    Task<ProductImageDto> GetProductImageAsyncById(int? id);
}

