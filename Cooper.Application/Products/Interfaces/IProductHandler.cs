using Cooper.Application.Bills.Dtos;
using Cooper.Application.Products.Dtos;
using Cooper.Core.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;

namespace Cooper.Application.Products.Interfaces
{
    public interface IProductHandler
    {
        Task<List<ListProductDto>> Get(Expression<Func<Product,bool>>? filter = null);
        Task<ProductDto> GetById(int id);
        Task<ProductDto> GetByIdAsNoTracking(int id);
        Task<List<PriceDto>> GetProductPrices(int productId);
        Task<bool> Create(CreateProductDto productDto);
        Task<bool> Update(int id, UpdateProductDto productDto);
        Task<bool> UpdateProductPrice(UpdateProductPriceDto productPriceDto);
        Task<bool> UpdateProductsStock(List<UpdateProductStockDto> updateProductStocks, bool isBilling = false);
        Task<bool> Delete(int id);
        Task<bool> ValidateAvailabilityInStock(int productId, int amount);
        Task ValidateProductCanBeBilled(CreateBillProductDto product);
    }
}
