using Microsoft.OpenApi.Models;
using music.CrossCutting.DependecyInjection;

namespace music.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public readonly IConfiguration Configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddMediator();
            services.AddRepository(Configuration);
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo 
                { 
                    Version = "v1",
                    Title = "MUSIC API",
                    Description = "API de músicas",
                    Contact = new OpenApiContact
                    {
                        Name = "Gabriel",
                        Email = "pottergryff8@gmail.com"
                    }
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Seu API v1");
                });
            }
            else
            {
                app.UseExceptionHandler("/error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}