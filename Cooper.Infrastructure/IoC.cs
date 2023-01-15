using Cooper.Application.Bills.Interfaces;
using Cooper.Application.Products.Interfaces;
using Cooper.Infrastructure.Context;
using Cooper.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cooper.Infrastructure
{
    public static class IoC
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CooperDbContext>(optionsAction => optionsAction
            .UseSqlite(@"Data Source= C:\Users\Gabriel\source\repos\Cooper\Cooper.Design\Cooper.sqlite"));

            services.AddTransient<ICooperDbContext, CooperDbContext>();

            services.AddTransient<IBillService, BillService>();

            services.AddTransient<IProductService, ProductService>();

            services.AddTransient<IProductPriceService, ProductPriceService>();

            return services;
        }
    }
}
