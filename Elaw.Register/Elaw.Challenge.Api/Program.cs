using Elaw.Challenge.Ioc;
using Microsoft.AspNetCore.Builder;
using Microsoft.OpenApi.Models;

namespace Elaw.Challenge.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
           
            builder.Services.AddControllers();
            builder.Services.AddOpenApi();

            // Database Context
            builder.Services.AddContext(builder);

            // Dependency Injectors
            builder.Services.Inject();

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Customer API", Version = "v1" });
            });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseSwagger(); 
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minha API v1");
            });

            app.UseAuthorization();
            app.MapControllers();

            // Web App Controller Interceptros
            app.ConfigureControllers();

            app.Run();
        }
    }
}