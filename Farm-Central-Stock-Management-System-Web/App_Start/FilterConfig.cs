using System.Web;
using System.Web.Mvc;

namespace Farm_Central_Stock_Management_System_Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
