using System.Web;
using System.Web.Mvc;

namespace Canfordit_Rides_and_Hires
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
