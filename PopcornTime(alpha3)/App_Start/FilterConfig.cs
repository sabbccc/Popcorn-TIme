using System.Web;
using System.Web.Mvc;

namespace PopcornTime_alpha3_
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
