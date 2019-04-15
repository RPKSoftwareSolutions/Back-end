using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;
using TKD.Framework.Core;
using TKD.Framework.ExceptionHandler.Contract;

namespace TKD.Framework.ExceptionHandler
{

    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next.Invoke(httpContext);
            }
            catch (Exception ex)

            {

                await HandleExceptionAsync(httpContext, ex);

            }
        }
        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var response = context.Response;
            var statusCode = (int)HttpStatusCode.InternalServerError;

            ExceptionResponse customException = new ExceptionResponse();

            if (exception is DomainException)
            {
                customException.Message = customException.Message;
                statusCode = ((DomainException)exception).Code;
            }
            else
            {
                customException.Message = "Unexpected error";
            }

            response.ContentType = "application/json";
            response.StatusCode = statusCode;
            await response.WriteAsync(JsonConvert.SerializeObject(customException));
        }
    }
}
