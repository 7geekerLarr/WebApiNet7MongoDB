using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace ApiSystemCQRS.Middleware
{
    public class TraceMiddleware : IMiddleware
    {
        private readonly ILogger<TraceMiddleware> _logger;
        private readonly ActivitySource _activitySource;

        public TraceMiddleware(ILogger<TraceMiddleware> logger, ActivitySource activitySource)
        {
            _logger = logger;
            _activitySource = activitySource;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            // Generar un identificador de correlación
            var activity = _activitySource.StartActivity("MyTransaction");
            activity?.AddTag("RequestPath", context.Request.Path);
            activity?.AddTag("RequestMethod", context.Request.Method);

            try
            {
                // Agregar log de inicio de la transacción
                _logger.LogDebug($"[{DateTime.UtcNow}] Starting transaction");

                // Agregar log con información de la petición
                _logger.LogDebug($"[{DateTime.UtcNow}] Request from {context.Connection.RemoteIpAddress} to {context.Request.Path} with method {context.Request.Method}");
                string requestBody = await GetRequestBodyAsync(context.Request);
                _logger.LogDebug($"Request body: {requestBody}");

                // Medir el tiempo que tarda en ejecutarse la acción
                var stopwatch = Stopwatch.StartNew();

                // Ejecutar la acción
                await next(context);

                stopwatch.Stop();

                // Agregar log con información de la respuesta
                _logger.LogDebug($"[{DateTime.UtcNow}] Response with status code {context.Response.StatusCode} in {stopwatch.ElapsedMilliseconds} ms");

                // Agregar log de fin de la transacción
                _logger.LogDebug($"[{DateTime.UtcNow}] Ending transaction");
            }
            catch (Exception ex)
            {
                // Agregar log de error
                _logger.LogError(ex, $"[{DateTime.UtcNow}] An error occurred while processing the request");
                throw;
            }
            finally
            {
                // Finalizar la actividad de correlación
                activity?.Stop();
            }
        }

        private async Task<string> GetRequestBodyAsync(HttpRequest request)
        {
            if (!request.Body.CanSeek)
            {
                return string.Empty;
            }

            request.EnableBuffering();

            var buffer = new byte[Convert.ToInt32(request.ContentLength)];
            await request.Body.ReadAsync(buffer.AsMemory(0, buffer.Length));

            request.Body.Position = 0;

            return Encoding.UTF8.GetString(buffer);
        }
    }
}
