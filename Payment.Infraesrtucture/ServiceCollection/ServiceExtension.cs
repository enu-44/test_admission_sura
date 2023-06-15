using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Payment.Domain.Interfaces;
using Payment.Infraesrtucture.Persistence;
using Payment.Infraesrtucture.Repositories;

namespace Payment.Infraesrtucture.ServiceCollection
{
    public static class ServiceExtension
    {
        public static void AddCommonLayer(this IServiceCollection service)
        {
            //Repositories
            service.AddTransient<IOrderRepository, OrderRepository>();
            service.AddTransient<IShipmentRepository, ShipmentRepository>();

        }

        public static void AddPersistenceLayer(this IServiceCollection service, IConfiguration configuration)
        {
            //Database context
            service.AddDbContext<PaymentDbContext>(options => { options.UseSqlServer(configuration.GetConnectionString("PaymentDbContext"), b => b.MigrationsAssembly("Payment.Api")); });
            service.AddScoped<Func<PaymentDbContext>>((provider) => () => provider.GetService<PaymentDbContext>());
        }
    }
}