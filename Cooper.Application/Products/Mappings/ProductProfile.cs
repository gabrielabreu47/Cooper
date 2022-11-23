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
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.WholesalePrice, op => op.MapFrom(source => source.GetProductPrice().WholesalePrice))
                .ForMember(dest => dest.UnitPrice, op => op.MapFrom(source => source.GetProductPrice().UnitPrice));

            CreateMap<ProductDto, Product>();
        }

        private void MapCreateProductDto()
        {
            CreateMap<CreateProductDto, Product>()
                .ForMember(dest => dest.ProductPrices, op => op.MapFrom(source => 
                    new List<ProductPrice> 
                    { 
                        new ProductPrice
                        {
                            PurchasePrice = source.PurchasePrice,
                            UnitPrice = source.UnitPrice,
                            WholesalePrice= source.WholesalePrice
                        }
                    }));
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
            CreateMap<Product, ListProductDto>()
               .ForMember(dest => dest.WholesalePrice, op => op.MapFrom(source => source.GetProductPrice().WholesalePrice))
               .ForMember(dest => dest.UnitPrice, op => op.MapFrom(source => source.GetProductPrice().UnitPrice));

            CreateMap<ListProductDto, Product>();
        }
    }
}
