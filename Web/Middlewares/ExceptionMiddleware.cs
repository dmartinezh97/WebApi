using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Text.Json;
using System.Threading.Tasks;
using Web.Middlewares.Exceptions;

namespace Web.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ExceptionMiddleware> logger;
        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                //https://jasonwatmore.com/post/2020/10/02/aspnet-core-31-global-error-handler-tutorial#:~:text=The%20global%20error%20handler%20middleware%20is%20used%20catch%20all%20exceptions,Configure%20method%20of%20the%20Startup.

                switch (ex)
                {
                    case AppException e:
                        response.StatusCode = StatusCodes.Status400BadRequest;
                        break;
                    case ArgumentException e:
                        response.StatusCode = StatusCodes.Status400BadRequest;
                        break;
                    default:
                        //TODO: Guardar todos los errores que no estén controlados en una tabla, convertiendo el ex.gettype para controlarlos en un futuro
                        response.StatusCode = StatusCodes.Status500InternalServerError;
                        break;
                }

                logger.LogError(ex, ex.Message);
                //context.Response.StatusCode = 500;

                
                var result = JsonSerializer.Serialize(new { error = ex.Message });
                await response.WriteAsync(result); //context.Response.WriteAsync(ex.Message);
            }
            
        }
    }
}
