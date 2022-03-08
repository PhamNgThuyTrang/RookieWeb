using Microsoft.EntityFrameworkCore;
using RookieShop.Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RookieShop.Backend.Data.SeedData
{
    public static class CategoryDataInitializer
    {
        public static void SeedCategoryData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    CategoryId = 1,
                    Name = "Men",
                },
                new Category
                {
                    CategoryId = 2,
                    Name = "Adidas",
                },
                new Category
                {
                    CategoryId = 3,
                    Name = "Kid",
                }
            );
        }

    }
}
