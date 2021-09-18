using AuthorizationService.CorsConfig;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace AuthorizationService
{
    public static class ServiceRegister
    {
        public static void AddCorsPolicy(this IServiceCollection services, IConfiguration Configuration)
        {
            services.Configure<CorsHost>(Configuration.GetSection(nameof(CorsHost)));
            services.AddSingleton<ICorsHosts>(cors => cors.GetRequiredService<IOptions<CorsHost>>().Value);
            services.AddCors();
            services.AddSingleton<ICorsPolicyProvider, CorsPolicyProvider>();
        }
    }
}
