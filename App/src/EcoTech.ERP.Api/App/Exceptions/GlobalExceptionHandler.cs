using EcoTech.ERP.Api.App.Common.Responses;
using Microsoft.AspNetCore.Diagnostics;

namespace EcoTech.ERP.Api.App.Exceptions
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken)
        {

            var response = new ApiResponse<object>(
                new List<object>(), 
                $"Ocurrió un error inesperado: {exception.Message}", 
                false
            );
            httpContext.Response.StatusCode = 500;

            await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);

            return true;
        }
    }
}
