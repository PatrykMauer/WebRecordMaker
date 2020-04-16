using Microsoft.AspNetCore.Builder;

namespace RecordMaker.Api.Framework
{
    public static class Extensions
    {
        public static IApplicationBuilder UseExceptionHandlerMiddleware(this IApplicationBuilder builder)
            => builder.UseMiddleware(typeof(ExceptionHandlerMiddleware));
    }
}