
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RookieShop.Shared.Constants;

namespace Rookie.CustomerSite.Extensions.ServiceCollection
{
    public static class ServiceRegister
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IBrandService, BrandService>();
            services.AddTransient<IBannerService, BannerService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<ISubCategoryService, SubCategoryService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IProductImageService, ProductImageService>();
            services.AddTransient<IProductSizeService, ProductSizeService>();
        }
    }
}