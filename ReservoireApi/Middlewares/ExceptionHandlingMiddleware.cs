using Newtonsoft.Json;
using System.Net;
using Utiliy.CustomException;
using Utiliy.Messages;

namespace ReservoireApi.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (CustomException ex)
            {
                //Log
                await HandleCustomExceptionAsync(context, ex);
            }
            catch (Exception ex)
            {                
                //Log
                await HandleExceptionAsync(context, ex);
            }
        }
        public static async Task HandleCustomExceptionAsync(HttpContext context, CustomException ex)
        {
            context.Response.StatusCode = (int)HttpStatusCode.NotFound;

            context.Response.ContentType = "application/json";

            var response = new
            {
                error = new
                {
                    message = "An error occurred while processing your request.",
                    details = ex.Message
                }
            };

            await context.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }
        public static async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.StatusCode = (int)HttpStatusCode.NotFound;
            string msg = "An error occurred while processing your request.";

            if (context.Response.StatusCode == (int)HttpStatusCode.Unauthorized)
            {
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                msg = Messages.AuthorizationDenied;
            }

            context.Response.ContentType = "application/json";

            var response = new
            {
                error = new
                {
                    message = msg,
                    details = ex.Message
                }
            };

            await context.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }
    }
}
