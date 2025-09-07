using System.IdentityModel.Tokens.Jwt;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using TheRestaurantMvc.HttpClients;
using TheRestaurantMvc.Models;
using TheRestaurantMvc.Models.ViewModels;

namespace TheRestaurantMvc.Controllers;

public class AuthController(RegisteredClients clients) : Controller
{
    public IActionResult Login() => View();
    
    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel loginViewModel)
    {
        var response = await clients.TheRestaurantApiClient().PostAsJsonAsync("auth/login", loginViewModel);
        var authResponse = await response.Content.ReadFromJsonAsync<ApiResponse<AuthResponse>>();
        
        if (!authResponse!.IsSuccess)
        {
            TempData["ErrorMessage"] = authResponse.StatusCode != HttpStatusCode.UnprocessableEntity
                ? authResponse.Message
                : null;
            return View(loginViewModel);
        }

        var jwt = authResponse.Value!.AccessToken;
        var jwtObject = new JwtSecurityTokenHandler().ReadJwtToken(jwt);
        
        HttpContext.Response.Cookies.Append("jsonWebToken", jwt, new CookieOptions
        {
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.Strict,
            Expires = jwtObject.ValidTo
        });

        return RedirectToAction("Index", "Home");
    }
}