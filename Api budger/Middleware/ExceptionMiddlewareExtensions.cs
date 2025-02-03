namespace Api_budger.Middleware
{
    public static class ExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder ExceptionMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
