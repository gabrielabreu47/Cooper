using AutoMapper;
using Cooper.Application.Products.Dtos;
using Cooper.Core.Entities;

namespace Cooper.Application.Products.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            MapProductDto();
            MapCreateProductDto();
            MapUpdateProductDto();
            MapUpdateProductPriceDto();
            MapListProductDto();
        }

        private void MapProductDto()
        {
            CreateMap<Product, ProductDto>();
        }

        private void MapCreateProductDto()
        {
            CreateMap<Product, CreateProductDto>();
        }

        private void MapUpdateProductDto()
        {
            CreateMap<Product, UpdateProductDto>();
        }

        private void MapUpdateProductPriceDto()
        {
            CreateMap<ProductPrice, UpdateProductPriceDto>();
        }

        private void MapListProductDto()
        {
            CreateMap<Product, ListProductDto>();
        }
    }
}
