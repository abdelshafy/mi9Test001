using System.Web;
using System.Web.Mvc;

using MI9.Models.errorhandler;

namespace MI9
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new ErrorHandlerAttribute());
        }
    }
}