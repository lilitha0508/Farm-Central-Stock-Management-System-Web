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
    public class ProductsController : Controller
    {
        private FarmCentralDBEntities db = new FarmCentralDBEntities();

       

        //-----------------------------------------------------------------------------------------------------------
        // GET: Products
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Farmer).Include(p => p.ProductType);
            return View(products.ToList());
        }

        //-----------------------------------------------------------------------------------------------------------
        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        //-----------------------------------------------------------------------------------------------------------
        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.farmer_id = new SelectList(db.Farmers, "farmer_Id", "farmer_name");
            ViewBag.catagory_id = new SelectList(db.ProductTypes, "prodCat_Id", "Catagory");
            return View();
        }

        //-----------------------------------------------------------------------------------------------------------
        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "prod_Id,catagory_id,farmer_id,prod_name")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.farmer_id = new SelectList(db.Farmers, "farmer_Id", "farmer_name", product.farmer_id);
            ViewBag.catagory_id = new SelectList(db.ProductTypes, "prodCat_Id", "Catagory", product.catagory_id);
            return View(product);
        }

        //-----------------------------------------------------------------------------------------------------------
        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.farmer_id = new SelectList(db.Farmers, "farmer_Id", "farmer_name", product.farmer_id);
            ViewBag.catagory_id = new SelectList(db.ProductTypes, "prodCat_Id", "Catagory", product.catagory_id);
            return View(product);
        }

        //-----------------------------------------------------------------------------------------------------------
        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "prod_Id,catagory_id,farmer_id,prod_name")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.farmer_id = new SelectList(db.Farmers, "farmer_Id", "farmer_name", product.farmer_id);
            ViewBag.catagory_id = new SelectList(db.ProductTypes, "prodCat_Id", "Catagory", product.catagory_id);
            return View(product);
        }

        //-----------------------------------------------------------------------------------------------------------
        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        //-----------------------------------------------------------------------------------------------------------
        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
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