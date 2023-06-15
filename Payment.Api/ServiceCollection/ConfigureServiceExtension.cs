using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Payment.Domain.SertviceCollection;
using Payment.Infraesrtucture.ServiceCollection;

namespace Payment.Api.ServiceCollection
{
    public static class ConfigureServiceExtension
    {

        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            //Services
            services.AddDomainLayer();
            services.AddCommonLayer();
            services.AddPersistenceLayer(configuration);

            services.AddControllers();
            services.AddSwaggerGen();
        }
    }
}