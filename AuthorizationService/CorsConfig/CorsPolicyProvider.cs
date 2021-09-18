using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace AuthorizationService.CorsConfig
{
    class CorsPolicyProvider : ICorsPolicyProvider
    {
        private ICorsHosts _corsHosts;
        public CorsPolicyProvider(ICorsHosts corsHosts)
        {
            _corsHosts = corsHosts;
        }

        public async Task<CorsPolicy> GetPolicyAsync(HttpContext context, string policyName)
        {
            string hostList = await Task.Run(() => _corsHosts.AllowedHost); 

            var allowedHosts = hostList.Split(",");

            var policy = new CorsPolicyBuilder()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials()
                        .WithOrigins(allowedHosts)
                        .Build();

            return policy;
        }
    }
}
