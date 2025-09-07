using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TheRestaurantMvc.Utilities;

namespace TheRestaurantMvc.ActionFilters;

public class JwtAuthenticActionFilter(RegisteredClients clients) : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var jwt = context.HttpContext.Request.Cookies["jsonWebToken"];
        
        if (string.IsNullOrEmpty(jwt))
        {
            context.Result = new RedirectToActionResult("Login", "Auth", null);
            return;
        }

        clients.TheRestaurantApiClient().DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", jwt);
    }
}