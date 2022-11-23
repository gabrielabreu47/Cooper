
using Cooper.Application.Bills.Handlers;
using Cooper.Application.Bills.Interfaces;
using Cooper.Application.Products.Handlers;
using Cooper.Application.Products.Interfaces;
using Cooper.Application.Reports.Handlers;
using Cooper.Application.Reports.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Cooper.Application
{
    public static class IoC
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IBillHandler, BillHandler>();

            services.AddTransient<IDebtHandler, DebtHandler>();

            services.AddTransient<IIncomesPerDateRangeHandler, IncomesPerDateRangeHanlder>();

            services.AddTransient<IProductHandler, ProductAndPriceHandler>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }
    }
}
