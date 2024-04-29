using Business.Abstract;
using Business.Concrete;
using Microsoft.Extensions.DependencyInjection;
using Utiliy.Abstract;
using Utiliy.Helper;

namespace Reservoire
{
    public static class RegisterDependencyHelper
    {
        public static void RegisterDependencies(this IServiceCollection services)
        {
            services.AddScoped<ILoginService,LoginService>();
            services.AddScoped<IJwtHelper, JwtHelper>();
            services.AddSingleton<IHashHelper, HashHelper>();
        }
    }
}
