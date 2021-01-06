using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace TasksManagement.Filters
{
    [AttributeUsage(validOn: AttributeTargets.Class)]
    public class ApiKeyAuthorizationAttribute : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            string apiKeyAttributeName = "ApiKey";

            if(!context.HttpContext.Request.Headers.TryGetValue(apiKeyAttributeName, out var potencialApiKey))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            IConfiguration configuration = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
            string apiKey = configuration.GetValue<string>(apiKeyAttributeName);

            if(!apiKey.Equals(potencialApiKey))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            await next();
        }
    }
}
