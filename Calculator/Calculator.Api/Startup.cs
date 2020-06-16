using System.Reflection;
using System.Text.Json.Serialization;
using Calculator.Api.Services;
using Calculator.Api.Services.Abstracts;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Calculator.Api
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                })
                .AddFluentValidation(opt => { opt.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()); });

            services.AddRouting();

            services.AddTransient<ICalculationService, CalculationService>();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder =>
                        builder.WithOrigins("https://localhost:44363")
                            .AllowCredentials()
                            .AllowAnyMethod()
                            .AllowAnyHeader());
            });
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseCors("AllowSpecificOrigin");
        }
    }
}