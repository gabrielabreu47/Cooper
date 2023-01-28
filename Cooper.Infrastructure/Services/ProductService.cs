using AutoMapper;
using Cooper.Application.Products.Interfaces;
using Cooper.Core.Entities;
using Cooper.Core.Extensions;
using Cooper.Infrastructure.Context;
using Cooper.Infrastructure.Enums;
using Cooper.Infrastructure.Generic;

namespace Cooper.Infrastructure.Services
{
    public class ProductService : BaseService<Product>, IProductService
    {
        public ProductService(ICooperDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public override async Task Delete(int id)
        {
            var entity = await GetByIdAsync(id);

            if (entity == null) throw new Exception(ErrorMessages.EntityNotFound.GetDescription());

            entity.Disabled = true;

            await Update(entity);
        }

        public async Task<bool> UpdateRange(List<Product> products)
        {
            _dbSet.UpdateRange(products);

            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
