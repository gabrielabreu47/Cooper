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
                .ForPath(dest => dest.phoneLabel.Text, op => op.MapFrom(source => source.Phone))
                .ForPath(dest => dest.dateLabel.Text, op => op.MapFrom(source => source.Date.ToString("dd/MM/yyyy")))
                .ForPath(dest => dest.clientNameLabel.Text, op => op.MapFrom(source => source.ClientName))
                .ForPath(dest => dest.productTable.DataSource, op => op.MapFrom(source => 
                    new BindingSource
                    {
                        DataSource = source.Products
                    }));
        }

        private void MapBillReport()
        {
            CreateMap<BillDto, BillReportTable>()
                .ForMember(dest => dest.Status, op => op.MapFrom(source => source.State.GetDescription()))
                .ForMember(dest => dest.Date, op => op.MapFrom(source => source.Date.ToString("dd/MM/yyyy")));
        }
    }
}
