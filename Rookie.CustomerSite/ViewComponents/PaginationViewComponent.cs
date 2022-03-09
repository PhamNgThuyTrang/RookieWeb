using Microsoft.AspNetCore.Mvc;
using Rookie.CustomerSite.ViewModel;
using Rookie.CustomerSite.ViewModel.Product;
using System.Threading.Tasks;

namespace Rookie.CustomerSite.ViewComponents
{
    public class PaginationViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(PagedResponseVM<ProductVm> pagedProducts)
        {
            return View(pagedProducts);
        }
    }
}
