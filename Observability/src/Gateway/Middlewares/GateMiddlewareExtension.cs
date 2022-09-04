namespace Gateway.Middlewares
{
    public static class GateMiddlewareExtension
    {
        public static IApplicationBuilder UseGateMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<GateMiddleware>();
        }
    }
}
