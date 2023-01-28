using Cooper.Application.Bills.Interfaces;
using Cooper.Application.Products.Interfaces;
using Cooper.Infrastructure.Context;
using Cooper.Infrastructure.Services;
using DinkToPdf.Contracts;
using DinkToPdf;
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
            .UseSqlite(@"Data Source= C:\Users\Gabriel\source\repos\Cooper\Cooper.Design\Cooper.sqlite"), ServiceLifetime.Transient);

            services.AddTransient<ICooperDbContext, CooperDbContext>();

            services.AddTransient<IBillService, BillService>();

            services.AddTransient<IProductService, ProductService>();

            services.AddTransient<IProductPriceService, ProductPriceService>();

            services.AddTransient<IDocumentService, DocumentService>();

            services.AddTransient<IHtmlToPdfHelper, HtmlToPdfHelper>();

            services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));

            return services;
        }
    }
}
