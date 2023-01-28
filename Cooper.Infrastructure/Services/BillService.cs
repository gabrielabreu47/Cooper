using AutoMapper;
using Cooper.Application.Bills.Interfaces;
using Cooper.Core.Entities;
using Cooper.Infrastructure.Context;
using Cooper.Infrastructure.Generic;

namespace Cooper.Infrastructure.Services
{
    public class BillService : BaseService<Bill>, IBillService
    {
        public BillService(ICooperDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
