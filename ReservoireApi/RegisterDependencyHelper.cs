using Business.Abstract;
using Business.Concrete;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Utiliy.Abstract;
using Utiliy.Helper;

namespace Reservoire
{
    public static class RegisterDependencyHelper
    {
        public static void RegisterDependencies(this IServiceCollection services)
        {
            #region Swagger Settings

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ReservoireAPI", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                {
                    new OpenApiSecurityScheme {
                        Reference = new OpenApiReference {
                            Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                        }
                    }, Array.Empty<string>()}
                });
            });
            #endregion

            #region JWT Settings
            // Add JWT Authentication Middleware - This code will intercept HTTP request and validate the JWT.
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = SymmetricKeyHelper.GetSymmetricKey(),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            #endregion

            #region Dependencies

            services.AddDbContext<CoreDbContext>(options => options.UseSqlServer(AppSettingsHelper.GetValue("ConnectionString", "")));
            
            services.AddScoped<IJwtHelper, JwtHelper>();
            services.AddSingleton<IHashHelper, HashHelper>();

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IReservationService, ReservationService>();

            services.AddScoped<IUserService, UserService>();
            #endregion
        }
    }
}
