using LogLibrary.Constants;
using LogLibrary.Structs;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using System.Text.Json;
using Serilog;

namespace LogLibrary.Middlewares
{
    public class LogMiddleware
    {
        private readonly RequestDelegate _next;

        public LogMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var utcNow = DateTime.UtcNow;
            var traceKey = Guid.NewGuid().ToString() + "_" + utcNow;

            if (!context.Request.Headers.TryGetValue(RequestLogConstant.TraceIdHeader, out var traceKeyHeaderValue))
            {
                context.Request.Headers.Add(RequestLogConstant.TraceIdHeader, traceKey);
            } 
            else
            {
                traceKey = traceKeyHeaderValue;
            }

            var logRequestObject = new LogRequestObject(utcNow, traceKey);

            var watch = Stopwatch.StartNew();

            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                logRequestObject.ExceptionMessage = ex.Message;
                logRequestObject.ExceptionStackTrace = ex.StackTrace;
            }
            finally
            {
                watch.Stop();

                logRequestObject.ElapsedMilliseconds = watch.ElapsedMilliseconds;

                Log.Information(JsonSerializer.Serialize(logRequestObject));
            }
        }
    }
}
