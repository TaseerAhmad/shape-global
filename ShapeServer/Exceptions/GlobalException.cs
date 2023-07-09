using ShapeServer.Helpers;
using System.Net;
using System.Text.Json;

namespace ShapeServer.Exceptions
{

    public class GlobalExceptionHandler
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
                if (environment == "Development")
                {
                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "text/plain";
                    await context.Response.WriteAsync(ex.Message);
                }
                else
                {
                    var apiResponse = new ApiResponse<object>(
                        type: ErrorTypeDocument.GetDocumentUri((int)HttpStatusCode.InternalServerError),
                        title: "An unknown error has occurred while processing the request. Retrying may or may not fix the error.",
                        status: (int)HttpStatusCode.InternalServerError
                    );

                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsync(JsonSerializer.Serialize(apiResponse));
                }
            }
        }
    }
}
