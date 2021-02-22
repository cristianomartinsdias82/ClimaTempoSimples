using ClimaTempoSimples.Filters;
using System.Web.Mvc;

namespace ClimaTempoSimples
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new ExceptionGlobalHandlingFilter());
        }
    }
}
