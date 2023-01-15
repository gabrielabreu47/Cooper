using Cooper.Core.Entities;
using Cooper.Core.Entities.Generic;
using Cooper.Infrastructure.Generic;
using Microsoft.EntityFrameworkCore;

namespace Cooper.Infrastructure.Context
{
    public class CooperDbContext : BaseDbContext, ICooperDbContext
    {
        public CooperDbContext(DbContextOptions<CooperDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductPrice> ProductPrices { get; set; }
        public DbSet<ProductStockDetail> ProductStockDetails { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillProduct> BillProducts { get; set; }

        public DbSet<T> GetDbSet<T>() where T : class, IBaseEntity => Set<T>();
    }
}
