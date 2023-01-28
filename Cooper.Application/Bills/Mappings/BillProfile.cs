using AutoMapper;
using Cooper.Application.Bills.Dtos;
using Cooper.Application.Bills.Enums;
using Cooper.Core.Entities;
using Cooper.Core.Extensions;

namespace Cooper.Application.Bills.Mappings
{
    public class BillProfile : Profile
    {
        public BillProfile()
        {
            MapBillDto();
            MapCreateBillDto();
            MapPrintBillDto();
        }

        private void MapBillDto()
        {
            CreateMap<Bill, BillDto>()
                .ForMember(dest => dest.State, op => op.MapFrom(source => source.State.ToEnum<BillStatus>()));

            CreateMap<BillDto, Bill>()
                .ForMember(dest => dest.State, op => op.MapFrom(source => source.State.ToInt()));

            CreateMap<BillProduct, BillProductDto>()
                .ForPath(dest => dest.Name, op => op.MapFrom(source => source.Product.Name))
                .ForPath(dest => dest.Price, op => op.Ignore());

            CreateMap<BillProductDto, BillProduct>();
        }
        private void MapCreateBillDto()
        {
            CreateMap<CreateBillDto, Bill>()
                .ForMember(dest => dest.State, op => op.MapFrom(source => source.Status.ToInt()))
                .ForMember(dest => dest.Date, op => op.MapFrom(source => DateTime.Now));

            CreateMap<CreateBillProductDto, BillProduct>();
        }
        private void MapPrintBillDto()
        {

        }
    }
}
