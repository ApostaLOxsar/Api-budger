﻿namespace Api_budger.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (UnauthorizedAccessException)
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
            }
            catch(KeyNotFoundException) 
            {
                context.Response.StatusCode = StatusCodes.Status406NotAcceptable;
            }
        }
    }
}
