using Log.Library.Services;
using LogLibrary.Constants;
using LogLibrary.Structs;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using System.Text.Json;

namespace LogLibrary.Middlewares
{
    public class LogMiddleware
    {
        private readonly RequestDelegate _next;

        public LogMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, ILogRequestService logRequestService)
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

            logRequestService.Log = logRequestObject;

            var watch = Stopwatch.StartNew();

            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                logRequestService.Log.ExceptionMessage = ex.Message;
                logRequestService.Log.ExceptionStackTrace = ex.StackTrace;
            }
            finally
            {
                watch.Stop();

                logRequestService.Log.ElapsedMilliseconds = watch.ElapsedMilliseconds;

                Serilog.Log.Information(JsonSerializer.Serialize(logRequestObject));
            }
        }
    }
}
