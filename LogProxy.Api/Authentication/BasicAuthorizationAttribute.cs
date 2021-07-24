using Microsoft.AspNetCore.Authorization;

namespace LogProxy.Api.Authentication
{
    public class BasicAuthorizationAttribute : AuthorizeAttribute
    {
        public BasicAuthorizationAttribute()
        {
            Policy = "BasicAuthentication";
        }
    }
}
