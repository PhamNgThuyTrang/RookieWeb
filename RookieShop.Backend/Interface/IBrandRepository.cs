using RookieShop.Backend.Data;
using RookieShop.Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RookieShop.Backend.Interface
{
    public interface IBrandRepository
    {
        IQueryable<Brand> GetAll();
        Brand GetById(int id);
        Brand FindById(int id);

        void Put(Brand brand);
        void Post(Brand brand);
        void Delete(Brand brand);

    }
}
