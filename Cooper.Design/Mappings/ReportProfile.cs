using AutoMapper;
using Cooper.Application.Bills.Dtos;
using Cooper.Core.Extensions;
using Cooper.Design.Components.Report;

namespace Cooper.Design.Mappings
{
    public class ReportProfile : Profile
    {
        public ReportProfile()
        {
            MapBillDetail();
            MapBillReport();
        }
        private void MapBillDetail()
        {
            CreateMap<BillDto, BillDetail>()
                .ForPath(dest => dest.billIdLabel.Text, op => op.MapFrom(source => $"Factura - {source.Id}"))
                .ForPath(dest => dest.totalLabel.Text, op => op.MapFrom(source => source.Total.ToString()))
                .ForPath(dest => dest.statusLabel.Text, op => op.MapFrom(source => source.State.GetDescription()))
                .ForMember(dest => dest.IsPending, op => op.MapFrom(source => source.State == Application.Bills.Enums.BillStatus.Pending))
                .ForMember(dest => dest.BillId, op => op.MapFrom(source => source.Id))
                .ForPath(dest => dest.phoneLabel.Text, op => op.MapFrom(source => source.Phone))
                .ForPath(dest => dest.dateLabel.Text, op => op.MapFrom(source => source.Date.ToString("dd/MM/yyyy")))
                .ForPath(dest => dest.clientNameLabel.Text, op => op.MapFrom(source => source.ClientName));

            CreateMap<BillProductDto, BillProductDetailModel>()
                .ForMember(x => x.ProductName, op => op.MapFrom(x => x.Name))
                .ForMember(x => x.SaleType, op => op.MapFrom(x => x.SelledAsWholesale ? "Por mayor" : "Al detalle"))
                .ForMember(x => x.Total, op => op.MapFrom(x => x.PriceTotal));
        }

        private void MapBillReport()
        {
            CreateMap<BillDto, BillReportTable>()
                .ForMember(dest => dest.Status, op => op.MapFrom(source => source.State.GetDescription()))
                .ForMember(dest => dest.Date, op => op.MapFrom(source => source.Date.ToString("dd/MM/yyyy")));
        }
    }
}
