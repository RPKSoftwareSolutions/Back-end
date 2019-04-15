using Microsoft.AspNetCore.Builder;

namespace TKD.Framework.ExceptionHandler
{
    public static class ExceptionHandlerExtension
    {
        public static IApplicationBuilder UseCustomUseExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}
