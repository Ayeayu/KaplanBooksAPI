using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace KaplanBooksAPI.Attribute
{

    /// <summary>
    /// This Custom Atrtribute is created, if we want to access a private book library using Google APIKEY.
    /// </summary>
    [AttributeUsage(validOn: AttributeTargets.Class | AttributeTargets.Method)]
   
    public class ApiKeyAttribute : System.Attribute, IAsyncActionFilter
    {
        private const string ApiKeyName = "ApiKey";
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.HttpContext.Request.Headers.TryGetValue(ApiKeyName, out var extractedApiKey))

            {
                context.Result = new UnauthorizedResult();

                return;
            }

            var configuration = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();

            var apiKey = configuration.GetValue<string>(ApiKeyName);

            if (!apiKey.Equals(extractedApiKey))

            {
                context.Result = new UnauthorizedResult();
               
                return;
            }
            await next();


        }
    }
    
}
