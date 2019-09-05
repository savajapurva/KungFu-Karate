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
    public class CLASS_DETAILSController : Controller
    {
        private KungFuDBEntities2 db = new KungFuDBEntities2();

        // GET: CLASS_DETAILS
        public ActionResult Index()
        {
            var cLASS_DETAILS = db.CLASS_DETAILS.Include(c => c.CLASS_LEVEL);
            return View(cLASS_DETAILS.OrderByDescending(z=>z.CLASS_ID).ToList());
        }

        // GET: CLASS_DETAILS/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLASS_DETAILS cLASS_DETAILS = db.CLASS_DETAILS.Find(id);
            if (cLASS_DETAILS == null)
            {
                return HttpNotFound();
            }
            return View(cLASS_DETAILS);
        }

        // GET: CLASS_DETAILS/Create
        public ActionResult Create()
        {
            ViewBag.CLASS_LEVEL_ID = new SelectList(db.CLASS_LEVEL, "CLASS_LEVEL_ID", "LEVEL_NAME");
            return View();
        }

        // POST: CLASS_DETAILS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CLASS_ID,CLASS_LEVEL_ID,CLASS_NAME,START_TIME,END_TIME,MONDAY,TUESDAY,WEDNESDAY,THURSDAY,FRIDAY")] CLASS_DETAILS cLASS_DETAILS)
        {
            if (ModelState.IsValid)
            {
                db.CLASS_DETAILS.Add(cLASS_DETAILS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CLASS_LEVEL_ID = new SelectList(db.CLASS_LEVEL, "CLASS_LEVEL_ID", "LEVEL_NAME", cLASS_DETAILS.CLASS_LEVEL_ID);
            return View(cLASS_DETAILS);
        }

        // GET: CLASS_DETAILS/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLASS_DETAILS cLASS_DETAILS = db.CLASS_DETAILS.Find(id);
            if (cLASS_DETAILS == null)
            {
                return HttpNotFound();
            }
            ViewBag.CLASS_LEVEL_ID = new SelectList(db.CLASS_LEVEL, "CLASS_LEVEL_ID", "LEVEL_NAME", cLASS_DETAILS.CLASS_LEVEL_ID);
            return View(cLASS_DETAILS);
        }

        // POST: CLASS_DETAILS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CLASS_ID,CLASS_LEVEL_ID,CLASS_NAME,START_TIME,END_TIME,MONDAY,TUESDAY,WEDNESDAY,THURSDAY,FRIDAY")] CLASS_DETAILS cLASS_DETAILS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cLASS_DETAILS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CLASS_LEVEL_ID = new SelectList(db.CLASS_LEVEL, "CLASS_LEVEL_ID", "LEVEL_NAME", cLASS_DETAILS.CLASS_LEVEL_ID);
            return View(cLASS_DETAILS);
        }

        // GET: CLASS_DETAILS/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLASS_DETAILS cLASS_DETAILS = db.CLASS_DETAILS.Find(id);
            if (cLASS_DETAILS == null)
            {
                return HttpNotFound();
            }
            return View(cLASS_DETAILS);
        }

        // POST: CLASS_DETAILS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            CLASS_DETAILS cLASS_DETAILS = db.CLASS_DETAILS.Find(id);
            db.CLASS_DETAILS.Remove(cLASS_DETAILS);
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
