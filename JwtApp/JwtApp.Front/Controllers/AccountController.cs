using JwtApp.Front.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace JwtApp.Front.Controllers
{
    public class AccountController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AccountController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Login()
        {
            return View(new UserLoginModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginModel model)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient("ApiService1");
                var outComingJsonData = JsonSerializer.Serialize(model);
                StringContent content = new StringContent(outComingJsonData, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("api/Auths/Login", content);
                if (response.IsSuccessStatusCode)
                {
                    var inComingJsonData = await response.Content.ReadAsStringAsync();
                    var tokenModel = JsonSerializer.Deserialize<JwtTokenResponseModel>(inComingJsonData, new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    });
                    if (tokenModel != null)
                    {
                        JwtSecurityTokenHandler handler = new();

                        var token = handler.ReadJwtToken(tokenModel.AccessToken);

                        var claims = token.Claims.ToList();
                        if (tokenModel.AccessToken != null)
                            claims.Add(new Claim("accessToken", tokenModel.AccessToken));

                        var claimsIdentity = new ClaimsIdentity(claims,JwtBearerDefaults.AuthenticationScheme);

                        var authProps = new AuthenticationProperties
                        {
                            ExpiresUtc = tokenModel.Expiration,
                            IsPersistent = true,
                        };
                        await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProps);
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                    ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı");

            }

            return View(model);
        }
    }
}
