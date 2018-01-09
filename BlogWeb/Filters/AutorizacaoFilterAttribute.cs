using System.Web.Mvc;
using System.Web.Routing;

namespace BlogWeb.Filters
{
    /// <summary>
    /// [DEPRECATED]
    /// </summary>
    public class AutorizacaoFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!WebMatrix.WebData.WebSecurity.IsAuthenticated)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(
                        new {
                            controller = "Login",
                            action = "Index"
                        }));
            }
        }
    }
}