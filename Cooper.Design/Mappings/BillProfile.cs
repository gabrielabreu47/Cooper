
using AutoMapper;
using Cooper.Application.Bills.Dtos;
using Cooper.Application.Bills.Enums;
using Cooper.Core.Extensions;
using Cooper.Design.Components.Bill;

namespace Cooper.Design.Mappings
{
    public class BillProfile : Profile
    {
        public BillProfile()
        {
            MapCreateBill();
        }

        private void MapCreateBill()
        {
            const string Retail = "Al detalle";
            const string Wholesale = "Por mayor";
            CreateMap<CreateBill, ProductTableModel>()
                .ForMember(dest => dest.Id, op => op.MapFrom(source => source._currentProduct!.Id!.Value))
                .ForMember(dest => dest.Product, op => op.MapFrom(source => source._currentProduct!.Name))
                .ForMember(dest => dest.SaleType, op => op.MapFrom(source => source.wholesaleRadioButton.Checked ? Wholesale : Retail))
                .ForMember(dest => dest.Stock, op => op.MapFrom(source => source.stockTextBox.Text.ToInt()))
                .ForMember(dest => dest.Total, op => op.MapFrom(source => source.wholesaleRadioButton.Checked
                    ? source._currentProduct!.WholesalePrice * source.stockTextBox.Text.ToInt() 
                    : source._currentProduct!.UnitPrice * source.stockTextBox.Text.ToInt()));

            CreateMap<CreateBill, CreateBillDto>()
                .ForMember(dest => dest.ClientName, op => op.MapFrom(source => source.clientNameTextBox.Text))
                .ForMember(dest => dest.Phone, op => op.MapFrom(source => source.telephoneTextBox.Text))
                .ForMember(dest => dest.Status, op => op.MapFrom(source => source.outstandingCheckBox.Checked ? BillStatus.Pending : BillStatus.Invoiced))
                .ForMember(dest => dest.Products, op => op.MapFrom(source => source.Products));

            CreateMap<ProductTableModel, CreateBillProductDto>()
                .ForMember(dest => dest.ProductId, op => op.MapFrom(source => source.Id))
                .ForMember(dest => dest.Name, op => op.MapFrom(source => source.Product))
                .ForMember(dest => dest.SelledAsWholesale, op => op.MapFrom(source => source.SaleType == Wholesale));
        }
    }
}
