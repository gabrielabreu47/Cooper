using Cooper.Application.Bills.Dtos;
using Cooper.Application.Products.Dtos;
using Cooper.Core.Entities;
using System.Linq.Expressions;

namespace Cooper.Application.Products.Interfaces
{
    public interface IProductHandler
    {
        Task<List<ListProductDto>> Get(int top = 10, int skip = 0, Expression<Func<Product,
            object>>? orderBy = null, bool orderByAscending = true);
        Task<ProductDto> GetById(int id);
        Task<bool> Create(CreateProductDto productDto);
        Task<bool> Update(int id, UpdateProductDto productDto);
        Task<bool> UpdateProductPrice(UpdateProductPriceDto productPriceDto);
        Task<bool> Delete(int id);
        Task<bool> ValidateAvailabilityInStock(int productId, int amount);
        Task ValidateProductCanBeBilled(CreateBillProductDto product);
    }
}
