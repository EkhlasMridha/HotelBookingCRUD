using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthorizationService.CorsConfig;
using Microsoft.AspNetCore.Builder;

namespace AuthorizationService
{
    public static class MiddlewareConfig
    {
        public static void UseCustomCors(this IApplicationBuilder app)
        {
            app.UseMiddleware<CorsPolicyMiddleware>();
        }
    }
}
