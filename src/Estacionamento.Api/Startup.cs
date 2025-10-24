using Estacionamento.Api.Middlewares;
using Estacionamento.Infra.CrossCutting.AppSettings;
using Estacionamento.Infra.IoC;
using Newtonsoft.Json.Serialization;

namespace Estacionamento.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<AppSettings>(Configuration);
            var appSettings = Configuration.Get<AppSettings>() ?? new AppSettings();

            services.AddOpenApi();
            _ = services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Estacionamento API",
                    Version = "v1"
                });
            });

            services.AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                });


            services.ResolveDependencias(appSettings);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Estacionamento API v1");
                });

                
            }

            //app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthorization();
            app.UseWelcomePage("/");
            app.UseExceptionHandlerMiddleware();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
