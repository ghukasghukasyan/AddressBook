using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using ZevitTask.Middleware;
using ZevitTask.NotificationSender;

namespace ZevitTask.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class FirstMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IRequestCounter _request;

        public FirstMiddleware(RequestDelegate next, IRequestCounter request)
        {
            _next = next;
            _request = request;
        }


       
        public async Task Invoke(HttpContext httpContext)
        {

           
            Console.WriteLine("Start Processing 1" + " Request Count ");
            _request.RequestCount();
            await _next(httpContext);
            Console.WriteLine("End Processing 1");

        }
    }
}

// Extension method used to add the middleware to the HTTP request pipeline.
public static class FirstMiddlewareExtensions
{
    public static IApplicationBuilder UseFirstMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<FirstMiddleware>();
    }
}

