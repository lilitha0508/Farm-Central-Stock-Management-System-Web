using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Farm_Central_Stock_Management_System_Web.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous]

        //-----------------------------------------------------------------------------------------------
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}
//--------------------------------------------------------------EnD oF fIlE--------------------------------------------------------------------