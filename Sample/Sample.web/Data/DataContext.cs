using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sample.web.Domain;
using System.Security.Cryptography.X509Certificates;

namespace Sample.web.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().Ignore(x => x.Category).Ignore(x => x.Brand);
        }

        public DbSet<Product> Products  { get; set; }

        public DbSet<Category> Categories { get; set; }
        
        public DbSet<Brand> Brands { get; set; }

        
    }
}