using System.Web.Http.Filters;

namespace DotNet.MyProject.Api
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(HttpFilterCollection filters)
        {
            filters.Add(new ResultFilterAttribute());
            filters.Add(new ExceptionHandleFilterAttributte());
        }
    }
}