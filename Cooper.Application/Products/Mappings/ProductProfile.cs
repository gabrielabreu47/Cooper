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
                .ForMember(dest => dest.UnitPrice, op => op.MapFrom(source => source.GetProductPrice().UnitPrice))
                .ForMember(dest => dest.StockCountAsRetail, op => op.MapFrom(source => source.GetProductStockDetail().StockCountAsRetail))
                .ForMember(dest => dest.StockCountAsWholesale, op => op.MapFrom(source => source.GetProductStockDetail().StockCountAsWholesale));

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
                            Date = DateTime.Now,
                            PurchasePrice = source.PurchasePrice,
                            UnitPrice = source.UnitPrice,
                            WholesalePrice= source.WholesalePrice
                        }
                    }))
                .ForMember(dest => dest.ProductStockDetails, op => op.MapFrom(source => 
                    new List<ProductStockDetail>
                    {
                        new ProductStockDetail
                        {
                            Date = DateTime.Now,
                            StockCountAsRetail= source.StockCountAsRetail,
                            StockCountAsWholesale= source.StockCountAsWholesale
                        }
                    }));
        }

        private void MapUpdateProductDto()
        {
            CreateMap<UpdateProductDto, Product>();

            CreateMap<UpdateProductStockDto, Product>()
                .ForMember(dest => dest.Id, op => op.MapFrom(source => source.ProductId))
                .ForMember(dest => dest.Stock, op => op.Ignore());
        }

        private void MapUpdateProductPriceDto()
        {
            CreateMap<UpdateProductPriceDto, ProductPrice>()
                .ForMember(dest => dest.Date, op => op.MapFrom(source => DateTime.Now));
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
