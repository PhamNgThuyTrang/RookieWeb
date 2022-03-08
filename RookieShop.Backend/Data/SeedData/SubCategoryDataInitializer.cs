using Microsoft.EntityFrameworkCore;
using RookieShop.Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RookieShop.Backend.Data.SeedData
{
    public static class SubCategoryDataInitializer
    {
        public static void SeedSubCategoryData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SubCategory>().HasData(
                new SubCategory
                {
                    SubCategoryId = 1,
                    Name = "Running",
                    CategoryId = 1
                },
                new SubCategory
                {
                    SubCategoryId = 2,
                    Name = "Running",
                    CategoryId = 2
                },
                new SubCategory
                {
                    SubCategoryId = 3,
                    Name = "Basketball",
                    CategoryId = 1
                },
                new SubCategory
                {
                    SubCategoryId = 4,
                    Name = "Basketball",
                    CategoryId = 2
                },
                new SubCategory
                {
                    SubCategoryId = 5,
                    Name = "Tennis",
                    CategoryId = 1
                },
                new SubCategory
                {
                    SubCategoryId = 6,
                    Name = "Tennis",
                    CategoryId = 2
                },
                new SubCategory
                {
                    SubCategoryId = 7,
                    Name = "Sandals & Slides",
                    CategoryId = 1
                },
                new SubCategory
                {
                    SubCategoryId = 8,
                    Name = "Sandals & Slides",
                    CategoryId = 2
                }
            );
        }

    }
}
