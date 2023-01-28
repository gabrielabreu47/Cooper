
using Cooper.Design.Templates;
using Microsoft.Extensions.DependencyInjection;

namespace Cooper.Design
{
    internal static class IoC
    {
        public static IServiceCollection AddForms(this IServiceCollection services)
        {
            services.AddTransient<Forms.Index>();
            return services;
        }

        public static IServiceCollection AddComponents(this IServiceCollection services)
        {
            services.AddTransient<Components.ProductForm>();
            services.AddTransient<Components.Bill.CreateBill>();
            services.AddTransient<Components.Bill.ProductSearch>();
            services.AddTransient<Components.Product.Product>();
            services.AddTransient<Components.Product.ProductDetail>();
            services.AddTransient<Components.Product.UpdatePrice>();
            services.AddTransient<Components.Product.UpdateStock>();
            services.AddTransient<Components.ProductForm>();
            services.AddTransient<Components.Report.IncomesReport>();
            services.AddTransient<Components.Report.BillReport>();
            services.AddTransient<Components.Report.BillDetail>();
            services.AddTransient<Components.Report.Report>();
            return services;
        }

        public static IServiceCollection AddTemplates(this IServiceCollection services)
        {
            services.AddTransient<invoice>();
            services.AddTransient<invoiceDetail>();
            return services;
        }

        public static IServiceCollection AddControllers(this IServiceCollection services)
        {
            return services;
        }
    }
}
