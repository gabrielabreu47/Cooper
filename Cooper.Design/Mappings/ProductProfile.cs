using AutoMapper;
using Cooper.Application.Products.Dtos;
using Cooper.Core.Extensions;
using Cooper.Design.Components;
using Cooper.Design.Components.Product;

namespace Cooper.Design.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            MapProductDetail();
            MapProductForm();
            MapUpdateProductPrice();
        }

        private void MapProductDetail()
        {
            CreateMap<ProductDto, ProductDetail>()
                .ForPath(dest => dest.firstLetterLabel.Text, op => op.MapFrom(source => source.Name[0]))
                .ForPath(dest => dest.productNameIdLabel.Text, op => op.MapFrom(source => $"{source.Name} - {source.Id}"))
                .ForPath(dest => dest.productDetailLabel.Text, op => op.MapFrom(source => source.Description))
                .ForPath(dest => dest.priceLabel.Text, op => op.MapFrom(source => source.UnitPrice))
                .ForPath(dest => dest.wholesalePriceLabel.Text, op => op.MapFrom(source => source.WholesalePrice));
        }

        private void MapProductForm()
        {
            CreateMap<ProductForm, CreateProductDto>()
                .ForMember(dest => dest.Description, op => op.MapFrom(source => source.descriptionRichTextBox.Text))
                .ForMember(dest => dest.Name, op => op.MapFrom(source => source.nameTextBox.Text))
                .ForMember(dest => dest.Stock, op => op.MapFrom(source => source.stockTextBox.Text.ToInt()))
                .ForMember(dest => dest.WholesalePrice, op => op.MapFrom(source => source.priceWholesaleTextBox.Text.ToDecimal()))
                .ForMember(dest => dest.UnitPrice, op => op.MapFrom(source => source.priceTextBox.Text.ToDecimal()))
                .ForMember(dest => dest.StockCountAsRetail, op => op.MapFrom(source => source.amountPerDetailTextBox.Text.ToInt()))
                .ForMember(dest => dest.StockCountAsWholesale, op => op.MapFrom(source => source.amountPerWholesaleTextBox.Text.ToInt()));

            CreateMap<ProductForm, UpdateProductDto>()
                .ForMember(dest => dest.Id, op => op.MapFrom(source => source.ProductId))
                .ForMember(dest => dest.Description, op => op.MapFrom(source => source.descriptionRichTextBox.Text))
                .ForMember(dest => dest.Name, op => op.MapFrom(source => source.nameTextBox.Text))
                .ForMember(dest => dest.StockCountAsRetail, op => op.MapFrom(source => source.amountPerDetailTextBox.Text.ToInt()))
                .ForMember(dest => dest.StockCountAsWholesale, op => op.MapFrom(source => source.amountPerWholesaleTextBox.Text.ToInt()));
        }

        private void MapUpdateProductPrice()
        {
            CreateMap<ProductDto, UpdatePrice>()
                .ForPath(dest => dest.firstLetterLabel.Text, op => op.MapFrom(source => source.Name[0]))
                .ForPath(dest => dest.productNameIdLabel.Text, op => op.MapFrom(source => $"{source.Name} - {source.Id}"))
                .ForPath(dest => dest.productDetailLabel.Text, op => op.MapFrom(source => source.Description))
                .ForPath(dest => dest.priceLabel.Text, op => op.MapFrom(source => source.UnitPrice.ToString()))
                .ForPath(dest => dest.wholesalePriceLabel.Text, op => op.MapFrom(source => source.WholesalePrice.ToString()))
                .ForPath(dest => dest.priceTextBox.Text, op => op.MapFrom(source => source.UnitPrice.ToString()))
                .ForPath(dest => dest.wholesalePriceTextBox.Text, op => op.MapFrom(source => source.WholesalePrice.ToString()));
        }
    }
}
