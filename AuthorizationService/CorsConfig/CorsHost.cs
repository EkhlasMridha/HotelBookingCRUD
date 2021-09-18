using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorizationService.CorsConfig
{
    class CorsHost : ICorsHosts
    {
        public string AllowedHost { get; set; }
    }

    public interface ICorsHosts
    {
        public string AllowedHost { get; set; }
    }
}
