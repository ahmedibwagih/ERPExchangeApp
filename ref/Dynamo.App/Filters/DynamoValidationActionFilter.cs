using Dynamo.Core.Other;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Dynamo.App.Filters
{
    public class DynamoValidationActionFilter : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                //Customize your error message
                var messages = string.Join("; ", context.ModelState.Values
                         .SelectMany(x => x.Errors)
                         .Select(x => !string.IsNullOrWhiteSpace(x.ErrorMessage) ? x.ErrorMessage : x.Exception?.Message.ToString()));
                context.RouteData.Values.Add("message", messages);

                throw new DynamoException(messages);
            }

            await next();
        }
    }
}
