using System.Web.Mvc;

namespace ClimaTempoSimples.Filters
{
    public class ExceptionGlobalHandlingFilter : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            //perform error logging...

            filterContext.ExceptionHandled = true;

            if (filterContext.RequestContext.HttpContext.Request.IsAjaxRequest())
            {
                filterContext.RequestContext.HttpContext.Response.ClearContent();
                filterContext.RequestContext.HttpContext.Response.Write($"<div><p>Informações indisponíveis no momento.<br />Por favor, tente novamente mais tarde.</p></div>");
                return;
            }

            filterContext.Result = new RedirectResult("/Home/Error");
        }
    }
}