using AutoMapper;
using Cooper.Application.Products.Interfaces;
using Cooper.Core.Entities;
using Cooper.Infrastructure.Context;
using Cooper.Infrastructure.Generic;

namespace Cooper.Infrastructure.Services
{
    public class ProductService : BaseService<Product>, IProductService
    {
        public ProductService(ICooperDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
