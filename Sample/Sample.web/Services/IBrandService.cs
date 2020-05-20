using Sample.web.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.web.Services
{
    public interface IBrandService
    {
        Task<Brand> GetBrandByIdAsync(int brandId);

        Task<Brand> GetBrandByNameAsync(string brandName);

        Task<bool> CreateBrandAsync(Brand brand);

        Task<bool> UpdateBrandAsync(Brand brand);

        Task<bool> DeleteBrandAsync(int brandId);
    }
}
