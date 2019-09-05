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
    public class CLASS_LEVELController : Controller
    {
        private KungFuDBEntities2 db = new KungFuDBEntities2();

        // GET: CLASS_LEVEL
        public ActionResult Index()
        {
            return View(db.CLASS_LEVEL.ToList());
        }

        // GET: CLASS_LEVEL/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLASS_LEVEL cLASS_LEVEL = db.CLASS_LEVEL.Find(id);
            if (cLASS_LEVEL == null)
            {
                return HttpNotFound();
            }
            return View(cLASS_LEVEL);
        }

        // GET: CLASS_LEVEL/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CLASS_LEVEL/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CLASS_LEVEL_ID,LEVEL_NAME")] CLASS_LEVEL cLASS_LEVEL)
        {
            if (ModelState.IsValid)
            {
                db.CLASS_LEVEL.Add(cLASS_LEVEL);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cLASS_LEVEL);
        }

        // GET: CLASS_LEVEL/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLASS_LEVEL cLASS_LEVEL = db.CLASS_LEVEL.Find(id);
            if (cLASS_LEVEL == null)
            {
                return HttpNotFound();
            }
            return View(cLASS_LEVEL);
        }

        // POST: CLASS_LEVEL/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CLASS_LEVEL_ID,LEVEL_NAME")] CLASS_LEVEL cLASS_LEVEL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cLASS_LEVEL).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cLASS_LEVEL);
        }

        // GET: CLASS_LEVEL/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLASS_LEVEL cLASS_LEVEL = db.CLASS_LEVEL.Find(id);
            if (cLASS_LEVEL == null)
            {
                return HttpNotFound();
            }
            return View(cLASS_LEVEL);
        }

        // POST: CLASS_LEVEL/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            CLASS_LEVEL cLASS_LEVEL = db.CLASS_LEVEL.Find(id);
            db.CLASS_LEVEL.Remove(cLASS_LEVEL);
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
