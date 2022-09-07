using Inventex.API.Security.Authorization.Handlers.Interfaces;
using Inventex.API.Security.Authorization.Settings;
using Inventex.API.Security.Domain.Services;
using Microsoft.Extensions.Options;

namespace Inventex.API.Security.Authorization.Middleware;

public class JwtMiddleware
{
    private readonly RequestDelegate _next;
    private readonly AppSettings _appSettings;

    public JwtMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings)
    {
        _next = next;
        _appSettings = appSettings.Value;
    }

    public async Task Invoke(HttpContext context, IUserService userService, IJwtHandler handler)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        var userId = handler.ValidateToken(token);
        if (userId != null)
        {
            // Attach user to context on successful JWT validation
            context.Items["User"] = await userService.GetByIdAsync(userId.Value);
        }

        await _next(context);

    }
}