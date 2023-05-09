using Microsoft.AspNetCore.Mvc.Filters;

namespace API.Attributes
{
    public class AuthorizedApiAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            throw new NotImplementedException();
        }
    }
}
