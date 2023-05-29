using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Farm_Central_Stock_Management_System_Web.Models;

namespace Farm_Central_Stock_Management_System_Web.Controllers
{
    public class FarmersController : Controller
    {
        private FarmCentralDBEntities db = new FarmCentralDBEntities();

       

        //-----------------------------------------------------------------------------------------------------------
        // GET: Farmers
        public ActionResult Index()
        {
            return View(db.Farmers.ToList());
        }

        //-----------------------------------------------------------------------------------------------------------
        // GET: Farmers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Farmer farmer = db.Farmers.Find(id);
            if (farmer == null)
            {
                return HttpNotFound();
            }
            return View(farmer);
        }

        //-----------------------------------------------------------------------------------------------------------
        // GET: Farmers/Create
        public ActionResult Create()
        {
            return View();
        }

        //-----------------------------------------------------------------------------------------------------------
        // POST: Farmers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "farmer_Id,farmer_name,farmer_surname,farmer_adress,farmer_contact,password,username")] Farmer farmer)
        {
            if (ModelState.IsValid)
            {
                db.Farmers.Add(farmer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(farmer);
        }


        //-----------------------------------------------------------------------------------------------------------
        // GET: Farmers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Farmer farmer = db.Farmers.Find(id);
            if (farmer == null)
            {
                return HttpNotFound();
            }
            return View(farmer);
        }

        //-----------------------------------------------------------------------------------------------------------
        // POST: Farmers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "farmer_Id,farmer_name,farmer_surname,farmer_adress,farmer_contact,password,username")] Farmer farmer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(farmer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(farmer);
        }

        //-----------------------------------------------------------------------------------------------------------
        // GET: Farmers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Farmer farmer = db.Farmers.Find(id);
            if (farmer == null)
            {
                return HttpNotFound();
            }
            return View(farmer);
        }

        //-----------------------------------------------------------------------------------------------------------
        // POST: Farmers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Farmer farmer = db.Farmers.Find(id);
            db.Farmers.Remove(farmer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //-----------------------------------------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
//--------------------------------------------------EnD Of FiLe--------------------------------------------------------------------------
