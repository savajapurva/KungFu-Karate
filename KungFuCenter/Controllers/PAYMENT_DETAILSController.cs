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
    public class PAYMENT_DETAILSController : Controller
    {
        private KungFuDBEntities2 db = new KungFuDBEntities2();

        // GET: PAYMENT_DETAILS
        public ActionResult Index(string searchString)
        {
            //var pAYMENT_DETAILS = db.PAYMENT_DETAILS.Include(p => p.STUDENT_DETAILS);
            var pAYMENT_DETAILS = from s in db.PAYMENT_DETAILS select s;
            //if (!string.IsNullOrEmpty(searchString))
            //{
            //    pAYMENT_DETAILS = pAYMENT_DETAILS.Where(s => s.PRODUCT_CATEGORY.Contains(searchString));
            //}
      
            return View(pAYMENT_DETAILS.OrderByDescending(x=>x.PAYMENT_ID));
        }

        // GET: PAYMENT_DETAILS/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PAYMENT_DETAILS pAYMENT_DETAILS = db.PAYMENT_DETAILS.Find(id);
            if (pAYMENT_DETAILS == null)
            {
                return HttpNotFound();
            }
            return View(pAYMENT_DETAILS);
        }

        // GET: PAYMENT_DETAILS/Create
        public ActionResult Create()
        {
            ViewBag.STUDENT_ID = new SelectList(db.STUDENT_DETAILS, "STUDENT_ID", "FIRST_NAME");
            ViewBag.PRODUCT_ID = new SelectList(db.PRODUCT_DETAILS, "PRODUCT_ID", "PRODUCT_CATEGORY");
            return View();
        }

        // POST: PAYMENT_DETAILS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PAYMENT_ID,STUDENT_ID,PRODUCT_ID,MONEY_RECEIVED,DATE_RECEIVED")] PAYMENT_DETAILS pAYMENT_DETAILS)
        {
            if (ModelState.IsValid)
            {
                db.PAYMENT_DETAILS.Add(pAYMENT_DETAILS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.STUDENT_ID = new SelectList(db.STUDENT_DETAILS, "STUDENT_ID", "FIRST_NAME", pAYMENT_DETAILS.STUDENT_ID);
            ViewBag.PRODUCT_ID = new SelectList(db.PRODUCT_DETAILS, "PRODUCT_ID", "PRODUCT_CATEGORY", pAYMENT_DETAILS.PRODUCT_ID);
            return View(pAYMENT_DETAILS);
        }

        // GET: PAYMENT_DETAILS/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PAYMENT_DETAILS pAYMENT_DETAILS = db.PAYMENT_DETAILS.Find(id);
            if (pAYMENT_DETAILS == null)
            {
                return HttpNotFound();
            }
            ViewBag.STUDENT_ID = new SelectList(db.STUDENT_DETAILS, "STUDENT_ID", "FIRST_NAME", pAYMENT_DETAILS.STUDENT_ID);
            ViewBag.PRODUCT_ID = new SelectList(db.PRODUCT_DETAILS, "PRODUCT_ID", "PRODUCT_CATEGORY", pAYMENT_DETAILS.PRODUCT_ID);
            return View(pAYMENT_DETAILS);
        }

        // POST: PAYMENT_DETAILS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PAYMENT_ID,STUDENT_ID,PRODUCT_ID,MONEY_RECEIVED,DATE_RECEIVED")] PAYMENT_DETAILS pAYMENT_DETAILS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pAYMENT_DETAILS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.STUDENT_ID = new SelectList(db.STUDENT_DETAILS, "STUDENT_ID", "FIRST_NAME", pAYMENT_DETAILS.STUDENT_ID);
            ViewBag.PRODUCT_ID = new SelectList(db.PRODUCT_DETAILS, "PRODUCT_ID", "PRODUCT_CATEGORY", pAYMENT_DETAILS.PRODUCT_ID);
            return View(pAYMENT_DETAILS);
        }

        // GET: PAYMENT_DETAILS/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PAYMENT_DETAILS pAYMENT_DETAILS = db.PAYMENT_DETAILS.Find(id);
            if (pAYMENT_DETAILS == null)
            {
                return HttpNotFound();
            }
            return View(pAYMENT_DETAILS);
        }

        // POST: PAYMENT_DETAILS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            PAYMENT_DETAILS pAYMENT_DETAILS = db.PAYMENT_DETAILS.Find(id);
            db.PAYMENT_DETAILS.Remove(pAYMENT_DETAILS);
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
