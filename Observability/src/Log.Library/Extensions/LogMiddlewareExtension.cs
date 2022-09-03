using LogLibrary.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace LogLibrary.Extensions
{
    public static class LogMiddlewareExtension
    {
        public static IApplicationBuilder UseLog(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LogMiddleware>();
        }
    }
}
