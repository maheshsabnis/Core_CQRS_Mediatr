using System.Security.Cryptography;

namespace Core_CQRS_Mediatr.CustomMIddlewares
{
    public class ErrorResponse
    {
        public string? ErrorMessage { get; set; }
        public int ErrorCode { get; set; }
    }

    /// <summary>
    /// The Custom Middeware Logic class
    /// </summary>
    public class ExceptinHandlerMidleware
    {
        RequestDelegate _next;

        public ExceptinHandlerMidleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// When this Middeware is applied in HttpPipeline, teh RequestDelegate will
        /// Auto-Invoke this method
        /// THis method will contain the Logic for the MIddleware
        /// </summary>
        /// <param name="ctx"></param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext ctx)
        {
            try
            {
                // If no Error Then Continue with the HTTP Pipeline Execution
                // by invoking the next middleware in the Pipeline
                await _next(ctx);
            }
            catch (Exception ex)
            {
                // If error occures, handle the exception by 
                // listeng to the exception and send the error response
                // This will directly start the Http Response Process

                // Set the Response Error Code
                // Either Hard-Code it or therwise read it from
                // THe database or other configuration respures

                ctx.Response.StatusCode = 500;
                
                string message = ex.Message;

                var errorResponse = new ErrorResponse()
                { 
                   ErrorCode = ctx.Response.StatusCode,
                   ErrorMessage = message
                };

                // Generate the error response
                
                await ctx.Response.WriteAsJsonAsync(errorResponse);

            }
        }
    }

    // Create an Extension MEthod class that will register the ExceptinHandlerMidleware class
    // as custom Middlware

    public static class ErrorHandlerMiddlewareExtension
    {
        public static void UseErrorExtender(this IApplicationBuilder builder)
        {
            // Register the ExceptinHandlerMidleware class as custome middleware
            builder.UseMiddleware<ExceptinHandlerMidleware>();
        }
    }
}
