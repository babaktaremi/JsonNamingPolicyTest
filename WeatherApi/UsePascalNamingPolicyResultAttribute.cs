using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WeatherApi;

public class UsePascalNamingPolicyResultAttribute : ResultFilterAttribute
{
    public override void OnResultExecuting(ResultExecutingContext context)
    {
        if (context.HttpContext.Request.Headers.ContainsKey("UsePascalCase")
            && bool.TryParse(context.HttpContext.Request.Headers["UsePascalCase"], out var usePascalCase)
            && usePascalCase)
        {
            var serializer = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = new PascalCaseNamingPolicy(),
                PropertyNameCaseInsensitive=true
            };

            if (context.Result is ObjectResult obj)
            {
                context.Result = new JsonResult(obj.Value, serializer);
            }
            else
                context.Result = context.Result switch
                {

                    OkObjectResult okObjectResult => new JsonResult(okObjectResult.Value, serializer)
                    {
                        StatusCode = StatusCodes.Status200OK
                    },
                    BadRequestObjectResult badRequestObjectResult => new JsonResult(badRequestObjectResult.Value, serializer)
                    {
                        StatusCode = StatusCodes.Status400BadRequest
                    },
                    _ => context.Result
                };
        }

        else
            base.OnResultExecuting(context);
    }
}