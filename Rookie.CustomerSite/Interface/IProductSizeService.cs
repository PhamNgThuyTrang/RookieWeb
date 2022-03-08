using RookieShop.Shared.Dto;
using RookieShop.Shared.Dto.ProductSize;
using System.Threading.Tasks;

public interface IProductSizeService
{
    Task<PagedResponseDto<ProductSizeDto>> GetProductSizesAsync(ProductSizeCriteriaDto productSizeCriteriaDto);
    Task<ProductSizeDto> GetProductSizeAsyncById(int id);
}
