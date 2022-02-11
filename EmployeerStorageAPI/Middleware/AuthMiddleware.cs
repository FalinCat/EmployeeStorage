using BLL.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace EmployeerStorageAPI.Middleware
{
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IUserService userService)
        {
            if (!context.Request.Headers.Authorization.ToString().StartsWith("Bearer ")) {
                await _next.Invoke(context);
                return;
            }
            var token = context.Request.Headers.Authorization.ToString().Replace("Bearer ", "");

            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);
            var userName = jwtSecurityToken.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name).Value;

            if (userName == null) {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("Token is invalid");
                return;
            }
            var user = userService.Get(x => x.Username == userName); // On real application we need separete table or maby even in-memory database for such search
            if (user == null)
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("Token is invalid");
                return;
            }

            if (user.Role == DAL.Enums.UserRole.Ban)
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Account locked");
            }
            else
            {
                await _next.Invoke(context);
            }
        }
    }
}
