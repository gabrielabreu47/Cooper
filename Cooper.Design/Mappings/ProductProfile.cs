using AutoMapper;
using Cooper.Application.Products.Dtos;
using Cooper.Core.Extensions;
using Cooper.Design.Components;

namespace Cooper.Design.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            MapCreateProduct();
        }

        private void MapCreateProduct()
        {
            CreateMap<CreateProduct, CreateProductDto>()
                .ForMember(dest => dest.Description, op => op.MapFrom(source => source.descriptionRichTextBox.Text))
                .ForMember(dest => dest.Name, op => op.MapFrom(source => source.nameTextBox.Text))
                .ForMember(dest => dest.Stock, op => op.MapFrom(source => source.stockTextBox.Text.ToInt()))
                .ForMember(dest => dest.WholesalePrice, op => op.MapFrom(source => source.priceWholesaleTextBox.Text.ToDecimal()))
                .ForMember(dest => dest.UnitPrice, op => op.MapFrom(source => source.priceTextBox.Text.ToDecimal()));
        }
    }
}
