using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using music.Domain.Repository;
using music.Infrastructure.Repository;

namespace music.CrossCutting.DependecyInjection
{
    public static class RepositoryServiceCollectionExtension
    {
        public static IServiceCollection AddRepository(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetSection("DBConfig")["ConnectionString"];
            services.AddScoped<IDbConnection>(provider => new SqlConnection(connectionString));
            services.AddScoped<IMusicRepository, MusicRepository>();

            return services;
        }
    }
}