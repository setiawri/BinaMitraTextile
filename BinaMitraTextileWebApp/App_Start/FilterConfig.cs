using BinaMitraTextileWebApp.Controllers;
using System.Web.Mvc;
using System.Web.Routing;

namespace BinaMitraTextileWebApp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new LoginValidationAttribute());
        }

        public class LoginValidationAttribute : FilterAttribute, IActionFilter
        {
            public void OnActionExecuting(ActionExecutingContext context)
            {
                if (context.ActionDescriptor.ActionName != nameof(UsersController.Login))
                {
                    if (!UsersController.isLoggedIn(context.HttpContext.Session))
                    {
                        context.Result = new RedirectToRouteResult(
                            new RouteValueDictionary(new
                            {
                                action = UsersController.ACTIONNAME_Login,
                                controller = UsersController.CONTROLLERNAME,
                                returnUrl = context.HttpContext.Request.RawUrl
                            })
                        );
                    }
                }
            }

            public void OnActionExecuted(ActionExecutedContext context) { }
        }
    }
}
