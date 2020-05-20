using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Sample.web.Data;
using Sample.web.Domain;
using System;
using System.Collections.Generic;
using System.IO.Pipelines;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.web.Services
{
    public class BrandService : IBrandService
    {
        private readonly DataContext _dataContext;

        public BrandService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Brand> GetBrandByIdAsync(int brandId)
        {
            return await _dataContext.Brands
                .SingleOrDefaultAsync(x => x.Id == brandId);
        }

        public async Task<Brand> GetBrandByNameAsync(string brandName)
        {
            return await _dataContext.Brands
                .SingleOrDefaultAsync(x => x.Name.ToLower() == brandName.ToLower());
        }

        public async Task<bool> CreateBrandAsync(Brand brand)
        {
            var existing = await _dataContext.Brands.AsNoTracking().SingleOrDefaultAsync(x => x.Name == brand.Name);
            if (existing != null)
                return true;

            await _dataContext.Brands.AddAsync(brand);
            var created = await _dataContext.SaveChangesAsync();
            return created > 0;
        }

        public async Task<bool> DeleteBrandAsync(int id)
        {
            var brand = await _dataContext.Brands.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);

            if (brand == null)
                return true;

            _dataContext.Brands.Remove(brand);
            var deleted = await _dataContext.SaveChangesAsync() > 0;
            return deleted;
        }

        public async Task<bool> UpdateBrandAsync(Brand brand)
        {
            var existing = await _dataContext.Brands.AsNoTracking().SingleOrDefaultAsync(x => x.Name == brand.Name);
            if (existing != null)
                return false;
            _dataContext.Brands.Update(brand);
            var updated = await _dataContext.SaveChangesAsync();
            return updated > 0;
        }
    }
}
