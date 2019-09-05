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
    public class RANK_DETAILSController : Controller
    {
        private KungFuDBEntities2 db = new KungFuDBEntities2();

        // GET: RANK_DETAILS
        public ActionResult Index()
        {
            return View(db.RANK_DETAILS.ToList());
        }

        // GET: RANK_DETAILS/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RANK_DETAILS rANK_DETAILS = db.RANK_DETAILS.Find(id);
            if (rANK_DETAILS == null)
            {
                return HttpNotFound();
            }
            return View(rANK_DETAILS);
        }

        // GET: RANK_DETAILS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RANK_DETAILS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RANK_ID,BELT_NAME")] RANK_DETAILS rANK_DETAILS)
        {
            if (ModelState.IsValid)
            {
                db.RANK_DETAILS.Add(rANK_DETAILS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rANK_DETAILS);
        }

        // GET: RANK_DETAILS/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RANK_DETAILS rANK_DETAILS = db.RANK_DETAILS.Find(id);
            if (rANK_DETAILS == null)
            {
                return HttpNotFound();
            }
            return View(rANK_DETAILS);
        }

        // POST: RANK_DETAILS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RANK_ID,BELT_NAME")] RANK_DETAILS rANK_DETAILS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rANK_DETAILS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rANK_DETAILS);
        }

        // GET: RANK_DETAILS/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RANK_DETAILS rANK_DETAILS = db.RANK_DETAILS.Find(id);
            if (rANK_DETAILS == null)
            {
                return HttpNotFound();
            }
            return View(rANK_DETAILS);
        }

        // POST: RANK_DETAILS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            RANK_DETAILS rANK_DETAILS = db.RANK_DETAILS.Find(id);
            db.RANK_DETAILS.Remove(rANK_DETAILS);
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
