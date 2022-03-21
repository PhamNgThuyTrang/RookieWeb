using Microsoft.EntityFrameworkCore;
using RookieShop.Backend.Data;
using RookieShop.Backend.Interface;
using RookieShop.Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RookieShop.Backend.Repository
{
    public class BrandRepository : IBrandRepository
    {
        private readonly ApplicationDbContext _context;

        public BrandRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<Brand> GetAll()
        {
            return _context.Brands
                           .Where(x => !x.IsDeleted)
                           .AsQueryable();
        }

        public Brand GetById(int id)
        {
            return _context
                    .Brands
                    .Where(x => !x.IsDeleted && x.BrandId == id)
                    .FirstOrDefault();
        }

        public Brand FindById(int id)
        {
            return _context
                    .Brands
                    .Find(id);
        }

        public void Put(Brand brand)
        {
            _context.Brands.Update(brand);
            _context.SaveChanges();
        }
        
        public void Post(Brand brand)
        {
            _context.Brands.Add(brand);
            _context.SaveChanges();
        }

        public void Delete(Brand brand)
        {
            brand.IsDeleted = true;
            _context.Brands.Update(brand);
            _context.SaveChangesAsync();
        }


    }
}
