using Microsoft.Extensions.DependencyInjection;

namespace music.CrossCutting.DependecyInjection
{
    public static class MediatorServiceCollectionExtension
    {
        public static IServiceCollection AddMediator(this IServiceCollection services)
        {
            var assembly = AppDomain.CurrentDomain.Load("music.Application");
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
            return services;
        }
    }
}