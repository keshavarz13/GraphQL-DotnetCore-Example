using System.Collections.Generic;
using System.Security.Claims;

namespace GraphQLDotNetCore
{
    public class GraphQLUserContext : Dictionary<string, object>
    {
        public ClaimsPrincipal User { get; set; }
    }
}
