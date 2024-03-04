using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Dynamo.App.Filters
{
    public class DynamoAuthorize : AuthorizeAttribute, IAsyncAuthorizationFilter
    {
        public string Permissions { get; set; }
        public int UserType { get; set; }
        public virtual async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var userName = context.HttpContext.User.Identity?.Name;
            var userId = context.HttpContext.User.Identities.FirstOrDefault()?.FindFirst("userId")?.Value;
          //  var lang = context.HttpContext.Request.Headers.FirstOrDefault(x => x.Key == "lang").Value;

            ////resturantId
            //var typeId = context.HttpContext.User.Identities.FirstOrDefault()?.FindFirst("typeId")?.Value;

            ////user type (system, resturant, delivery, customer)
            //var type = context.HttpContext.User.Identities.FirstOrDefault()?.FindFirst("type")?.Value;

            OnReadAuthorizations(userId, userName);

            var allowAnonymous = context.ActionDescriptor.EndpointMetadata
                            .Any(em => em.GetType() == typeof(AllowAnonymousAttribute));

            //allow when Anonymous
            if (allowAnonymous) return;

            ////allow when user type matched
            //var typeInt = int.Parse(type);
            //if ((UserType>0 && UserType != 1) //if userType==System then we should authorize by permission not by user type
            //    && UserType ==typeInt) 
            //    return;

            //allow when permission granted
            //var permissions = Permissions?.Split(',');
            //if (permissions?.Length > 0)
            //{
            //    var granted = await OnCheckPermissions(permissions);

            //    if (!granted)
            //    {
            //        context.Result = new UnauthorizedResult();
            //        return;
            //    }
            //}

            return;
        }

        protected virtual void OnReadAuthorizations(string userId, string userName)
        {

        }

        protected virtual async Task<bool> OnCheckPermissions(string[] permissions)
        {
            return true;
        }

    }
}