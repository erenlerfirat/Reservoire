using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.Concrete;
using Business.DependencyResolver;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ReservoireApi.Middlewares;
using Utiliy.Helper;

namespace Reservoire
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

            builder.Host.ConfigureContainer<ContainerBuilder>(
               builder => builder.RegisterModule(new AutofacBusinessModule()));

            // Add services to the container.
            //builder.Services.AddAuthorization();
            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });

            builder.Services.AddDbContext<CoreDbContext>(options => options.UseSqlServer(AppSettingsHelper.GetValue("ConnectionString","")));

            builder.Services.AddHttpClient();

            builder.Services.RegisterDependencies();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseCors("CorsPolicy");
            }
            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthorization();

            app.UseMiddleware<ExceptionHandlingMiddleware>();

            app.MapControllers();
            app.Run();
        }
    }
}
