
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace ShopBridge.API
{
    public class GlobalErrorHandler
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalErrorHandler> _logger;


        public GlobalErrorHandler(
            RequestDelegate next, 
            ILogger<GlobalErrorHandler> logger)
        {
            _next = next;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                context.Response.StatusCode = 500;

                var result = JsonConvert.SerializeObject(new { error = ex.Message });
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(result);
            }
            finally
            {
                HandleResponse(context);
            }
        }

        private void HandleResponse(HttpContext context)
        {
            if (context.Response.StatusCode == StatusCodes.Status401Unauthorized)
            {
                _logger.LogWarning($"Unauthorized access exception on path: '{context.Request.Path}'");
                return;
            }
            if (context.Response.StatusCode == StatusCodes.Status400BadRequest)
            {
                _logger.LogWarning($"Bad request on path: '{context.Request.Path}'");
                return;
            }
        }
    }
}
