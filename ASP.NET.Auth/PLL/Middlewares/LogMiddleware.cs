using ASP.NET.Auth.PLL.Logs;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ASP.NET.Auth.PLL.Middlewares
{
    public class LogMiddleware
    {
        private readonly ILogger _logger;
        private readonly RequestDelegate _next;

        public LogMiddleware(RequestDelegate next, ILogger logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            _logger.WriteEvent("IP-адрес клиента: " + httpContext.Connection.RemoteIpAddress.ToString());
            await _next(httpContext);
        }
    }
}
