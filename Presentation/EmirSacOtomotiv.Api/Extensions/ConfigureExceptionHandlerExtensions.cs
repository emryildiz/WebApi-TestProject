using System.Net;
using System.Net.Mime;
using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics;

namespace EmirSacOtomotiv.Api.Extensions
{
    public static class ConfigureExceptionHandlerExtensions
    {
        public static void ConfigureExceptionHandler<T>(this WebApplication webApplication, ILogger<T> logger)
        {
            webApplication.UseExceptionHandler(builder =>
                                               {
                                                   builder.Run(async context =>
                                                               {
                                                                   context.Response.StatusCode  = (int)HttpStatusCode.InternalServerError;
                                                                   context.Response.ContentType = MediaTypeNames.Application.Json;

                                                                   IExceptionHandlerFeature contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                                                                   if (contextFeature != null)
                                                                   {
                                                                       logger.LogError(contextFeature.Error.Message);

                                                                       await context.Response.WriteAsync(JsonSerializer.Serialize(new
                                                                       {
                                                                           StatusCode = context.Response.StatusCode,
                                                                           Message    = contextFeature.Error.Message,
                                                                           Title      = "Hata alındı!"
                                                                       }));
                                                                   }
                                                               });
                                               });
        }
    }
}
