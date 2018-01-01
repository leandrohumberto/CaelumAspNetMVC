using System.Web.Mvc;
using System.Web.Routing;

namespace BlogWeb.Filters
{
    public class AutorizacaoFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var usuario = filterContext.HttpContext.Session["usuario"];

            if (usuario == null)
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