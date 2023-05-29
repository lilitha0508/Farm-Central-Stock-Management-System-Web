using Farm_Central_Stock_Management_System_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;

namespace Farm_Central_Stock_Management_System_Web.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        ///  Get Login Information
        /// </summary>
        /// <param name="farmer"></param>
        /// <param name="employee"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        //-----------------------------------------------------------------------------------------------------------------------------------------
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Farmer farmer, Employee employee, User user)
        {
            if (ModelState.IsValid)
            {
                using (FarmCentralDBEntities entities = new FarmCentralDBEntities())
                {
                    var fmer = entities.Farmers.Where(a => a.username.Equals(farmer.username) && a.password.Equals(farmer.password)).FirstOrDefault();
                    var emp = entities.Employees.Where(a => a.username.Equals(employee.username) && a.password.Equals(employee.password)).FirstOrDefault();

                    if (fmer != null)
                    {
                        Session["farmer_Id"] = fmer.farmer_Id.ToString();
                        Session["username"] = fmer.username.ToString();
                        return RedirectToAction("Index", "Home");
                        return View(farmer);
                    }
                    else if (emp != null)
                    {
                        Session["Emp_Id"] = emp.Emp_Id.ToString();
                        Session["username"] = emp.username.ToString();
                        return RedirectToAction("Index", "Home");
                        return View(employee);
                    }
                    else
                    {
                        ModelState.AddModelError("", "The username or password is incorrect");
                    }

                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Login");
        }

    }
}
//--------------------------------------------------EnD Of FiLe--------------------------------------------------------------------------