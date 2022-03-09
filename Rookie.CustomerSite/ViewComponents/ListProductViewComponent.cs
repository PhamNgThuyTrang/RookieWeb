using Microsoft.AspNetCore.Mvc;
using Rookie.CustomerSite.ViewModel;
using Rookie.CustomerSite.ViewModel.Product;
using System.Threading.Tasks;

namespace Rookie.CustomerSite.ViewComponents
{
    public class ListProductViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(PagedResponseVM<ProductVm> products)
        {
            return View(products);
        }
    }
}
