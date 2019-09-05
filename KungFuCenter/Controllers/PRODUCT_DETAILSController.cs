using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClinicManagement.Core.Models;

namespace ClinicManagement.Controllers
{
    public class PRODUCT_DETAILSController : Controller
    {
        private KungFuDBEntities2 db = new KungFuDBEntities2();

        // GET: PRODUCT_DETAILS
        public ActionResult Index()
        {
            return View(db.PRODUCT_DETAILS.OrderByDescending(x=>x.PRODUCT_ID).ToList());
        }

        // GET: PRODUCT_DETAILS/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCT_DETAILS pRODUCT_DETAILS = db.PRODUCT_DETAILS.Find(id);
            if (pRODUCT_DETAILS == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCT_DETAILS);
        }

        // GET: PRODUCT_DETAILS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PRODUCT_DETAILS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PRODUCT_ID,PRODUCT_NAME,PRODUCT_DESCRIPTION,PRODUCT_COST_PRICE,PRODUCT_SELLING_PRICE,PRODUCT_QUANTITY, INVENTORY_DATE")] PRODUCT_DETAILS pRODUCT_DETAILS)
        {
            if (ModelState.IsValid)
            {
                db.PRODUCT_DETAILS.Add(pRODUCT_DETAILS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pRODUCT_DETAILS);
        }

        // GET: PRODUCT_DETAILS/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCT_DETAILS pRODUCT_DETAILS = db.PRODUCT_DETAILS.Find(id);
            if (pRODUCT_DETAILS == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCT_DETAILS);
        }

        // POST: PRODUCT_DETAILS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PRODUCT_ID,PRODUCT_NAME,PRODUCT_DESCRIPTION,PRODUCT_COST_PRICE,PRODUCT_SELLING_PRICE")] PRODUCT_DETAILS pRODUCT_DETAILS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pRODUCT_DETAILS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pRODUCT_DETAILS);
        }

        // GET: PRODUCT_DETAILS/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCT_DETAILS pRODUCT_DETAILS = db.PRODUCT_DETAILS.Find(id);
            if (pRODUCT_DETAILS == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCT_DETAILS);
        }

        // POST: PRODUCT_DETAILS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            PRODUCT_DETAILS pRODUCT_DETAILS = db.PRODUCT_DETAILS.Find(id);
            db.PRODUCT_DETAILS.Remove(pRODUCT_DETAILS);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

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
