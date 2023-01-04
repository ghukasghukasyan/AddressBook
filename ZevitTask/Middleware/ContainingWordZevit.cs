using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ZevitTask.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ContainingWordZevit
    {
        private readonly RequestDelegate _next;

        public ContainingWordZevit(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {

            var url = httpContext.Request.Path.ToString();
            if (url.Contains("zevit"))
                Console.WriteLine("Zevit Key found");
            await _next(httpContext); 
            

        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder ContainingZevitWordMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ContainingWordZevit>();
        }
    }
}
