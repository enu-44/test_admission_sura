using Microsoft.Extensions.DependencyInjection;
using Payment.Domain.Application;

namespace Payment.Domain.SertviceCollection
{
    public static class ServiceExtension
    {
        public static void AddDomainLayer(this IServiceCollection service)
        {
            service.AddTransient<PaymentOrderUseCase, PaymentOrderUseCase>();
        }
    }
}