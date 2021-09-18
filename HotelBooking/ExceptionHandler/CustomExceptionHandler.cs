using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace HotelBooking.ExceptionHandler
{
    public class CustomExceptionHandler
    {
        private RequestDelegate _next;
        public CustomExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception e)
            {
                var source = $"{e.TargetSite.DeclaringType} --> {e.TargetSite.Name}";
                await HandleExceptionAsync(httpContext, e);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            await Task.Run(()=> context.Response.WriteAsync(new ErrorModel()
            {
                StatusCode = context.Response.StatusCode,
                Source = $"{exception.TargetSite.DeclaringType} --> {exception.TargetSite.Name}",
                Message = exception.Message,
                StackTrace = exception.StackTrace
            }.ToString()));
        }
    }
}
