using System.Diagnostics;

namespace Prueba.Tekton.Api.Middleware
{
    public class ResponseTimeLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _logFilePath;
        private readonly IHostEnvironment _hostEnvironment;

        public ResponseTimeLoggingMiddleware(RequestDelegate next, string logFilePath, IHostEnvironment hostEnvironment)
        {
            _next = next;
            _logFilePath = logFilePath;
            _hostEnvironment = hostEnvironment;
        }

        public async Task Invoke(HttpContext context)
        {
            var stopwatch = Stopwatch.StartNew();

            await _next(context);

            stopwatch.Stop();
            var responseTime = stopwatch.ElapsedMilliseconds;

            LogResponseTime(context, responseTime);
        }

        private void LogResponseTime(HttpContext context, long responseTime)
        {
            string logMessage = $"{DateTime.Now} - {context.Request.Method} {context.Request.Path} - {responseTime}ms";

            File.AppendAllText(Path.Combine(_hostEnvironment.ContentRootPath,_logFilePath), logMessage + Environment.NewLine);
        }
    }

}
