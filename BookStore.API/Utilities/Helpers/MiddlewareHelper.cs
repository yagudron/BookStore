using BookStore.API.Utilities.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace BookStore.API.Utilities.Helpers
{
    public static class MiddlewareHelper
    {
        public static IApplicationBuilder UseErrorLogging(this IApplicationBuilder builder) => builder.UseMiddleware<ErrorLoggingMiddleware>();

        public static IApplicationBuilder UseErrorHandling(this IApplicationBuilder builder) => builder.UseMiddleware<ErrorHandlingMiddleware>();
    }
}
