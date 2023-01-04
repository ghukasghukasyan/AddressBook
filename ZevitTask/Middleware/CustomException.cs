using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using ZevitTask.ExceptionZevit;

namespace ZevitTask.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class CustomException
    {
        private readonly RequestDelegate _next;  
        public CustomException(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            
            catch (CustomExceptionZevit ex)
            {
                httpContext.Response.StatusCode = (Convert.ToInt32(ex.Error));
                await httpContext.Response.WriteAsync(ex.Message);
                Console.WriteLine(ex.Message);
                
            }

            catch (Exception)
            {

               await httpContext.Response.WriteAsync("Sommething bad happened");
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class CustomExceptionExtensions
    {
        public static IApplicationBuilder UseCustomException(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomException>();
        }
    }
}
