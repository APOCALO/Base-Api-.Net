using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Application.Common
{
    public abstract class ApiBaseHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        protected readonly ILogger<ApiBaseHandler<TRequest, TResponse>> _logger;

        protected ApiBaseHandler(ILogger<ApiBaseHandler<TRequest, TResponse>> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
        {
            var stopwatch = Stopwatch.StartNew();

            // Log Inicio de la gestión de solicitudes
            _logger.LogInformation("Handling {RequestName} with request: {@Request}", typeof(TRequest).Name, request);

            TResponse response;
            try
            {
                // Llamar a la implementación específica de la clase derivada
                response = await HandleRequest(request, cancellationToken);
            }
            catch (Exception ex)
            {
                // Log los errores que puedan producirse
                _logger.LogError(ex, "An error occurred while handling {RequestName}", typeof(TRequest).Name);
                throw;
            }
            finally
            {
                // Parar el cronómetro y registrar el tiempo transcurrido
                stopwatch.Stop();
                _logger.LogInformation("{RequestName} completed in {ElapsedTime} ms.", typeof(TRequest).Name, stopwatch.Elapsed.TotalMilliseconds);
            }

            // Si el tipo de respuesta es ApiResponse, incluya el ResponseTime
            if (response is ApiResponse<TResponse> apiResponse)
            {
                apiResponse.ResponseTime = stopwatch.Elapsed.TotalMilliseconds;
            }

            return response;
        }

        // Método abstracto que debe implementar la clase derivada
        protected abstract Task<TResponse> HandleRequest(TRequest request, CancellationToken cancellationToken);
    }
}
