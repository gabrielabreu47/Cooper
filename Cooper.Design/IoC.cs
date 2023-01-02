
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
            services.AddTransient<Components.CreateProduct>();
            services.AddTransient<Components.Bill.CreateBill>();
            return services;
        }
    }
}
