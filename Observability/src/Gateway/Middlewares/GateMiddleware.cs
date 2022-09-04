using Gateway.Configuration;
using System.Net;

namespace Gateway.Middlewares
{
    public class GateMiddleware
    {
        private readonly RequestDelegate _next;

        private readonly GatewayConfig _gatewayConfig;

        public GateMiddleware(
            RequestDelegate next,
            GatewayConfig gatewayConfig)
        {
            _next = next;
            _gatewayConfig = gatewayConfig;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var requestConfiguration = _gatewayConfig.Routes
                .FirstOrDefault(r => r.Path == context.Request.Path && r.Method == context.Request.Method);

            if (requestConfiguration is null)
            {
                ReturnBadRequestResponse(context);

                return;
            }

            await _next.Invoke(context);
        }

        private void ReturnBadRequestResponse(HttpContext context)
        {
            context.Response.StatusCode = (int) HttpStatusCode.BadRequest;
        }
    }
}