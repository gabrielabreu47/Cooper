using Cooper.Application.Generic.Interfaces;
using Cooper.Core.Entities;

namespace Cooper.Application.Products.Interfaces
{
    public interface IProductService : IBaseService<Product>
    {
        Task<bool> UpdateRange(List<Product> products);
    }
}
