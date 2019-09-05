using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClinicManagement.Core.Models;

namespace ClinicManagement.Controllers
{
    public class PROGRESS_DETAILSController : Controller
    {
        private KungFuDBEntities2 db = new KungFuDBEntities2();

        // GET: PROGRESS_DETAILS


        public ActionResult Index(string fname, string lname, string searchString, string searchString1)
        {
            string searchfname = fname;
            string searchlname = lname;
            string startDate = searchString;
            string endDate = searchString1;
            var pROGRESS_DETAILS = from s in db.PROGRESS_DETAILS select s;

            //both name
            if (!string.IsNullOrEmpty(fname) && !string.IsNullOrEmpty(lname) && (string.IsNullOrEmpty(startDate) || string.IsNullOrEmpty(endDate)))
            {
                pROGRESS_DETAILS = db.PROGRESS_DETAILS 
                            .Where(d => d.STUDENT_DETAILS.FIRST_NAME.Contains(searchfname) && d.STUDENT_DETAILS.LAST_NAME.Contains(searchlname));

            }

            //only one name from 2
            if (!string.IsNullOrEmpty(fname) || !string.IsNullOrEmpty(lname))
            {
                pROGRESS_DETAILS = db.PROGRESS_DETAILS
                            .Where(d => d.STUDENT_DETAILS.FIRST_NAME.Contains(searchfname) && d.STUDENT_DETAILS.LAST_NAME.Contains(searchlname));

            }

            if (!string.IsNullOrEmpty(startDate) && !string.IsNullOrEmpty(endDate))
            {
                DateTime startfilter = DateTime.ParseExact(startDate + " 00:00:00", "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                DateTime endfilter = DateTime.ParseExact(endDate + " 00:00:00", "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                pROGRESS_DETAILS = pROGRESS_DETAILS.Where(s => s.AWARDED_DATE >= startfilter && s.AWARDED_DATE <= endfilter);
            }
            if (!string.IsNullOrEmpty(fname) && !string.IsNullOrEmpty(lname) && !string.IsNullOrEmpty(startDate) && !string.IsNullOrEmpty(endDate))
            {
                DateTime startfilter = DateTime.ParseExact(startDate + " 00:00:00", "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                DateTime endfilter = DateTime.ParseExact(endDate + " 00:00:00", "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                pROGRESS_DETAILS = pROGRESS_DETAILS.Where(s => s.AWARDED_DATE >= startfilter && s.AWARDED_DATE <= endfilter && s.STUDENT_DETAILS.FIRST_NAME.Contains(searchfname) && s.STUDENT_DETAILS.LAST_NAME.Contains(searchlname));
            }



            return View(pROGRESS_DETAILS);
        }


        // GET: PROGRESS_DETAILS/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PROGRESS_DETAILS pROGRESS_DETAILS = db.PROGRESS_DETAILS.Find(id);
            if (pROGRESS_DETAILS == null)
            {
                return HttpNotFound();
            }
            return View(pROGRESS_DETAILS);
        }

        // GET: PROGRESS_DETAILS/Create
        public ActionResult Create()
        {
            ViewBag.RANK_ID = new SelectList(db.RANK_DETAILS, "RANK_ID", "BELT_NAME");
            ViewBag.STUDENT_ID = new SelectList(db.STUDENT_DETAILS, "STUDENT_ID", "FIRST_NAME");
            return View();
        }

        // POST: PROGRESS_DETAILS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PROGRESS_ID,STUDENT_ID,RANK_ID,AWARDED_DATE")] PROGRESS_DETAILS pROGRESS_DETAILS)
        {
            if (ModelState.IsValid)
            {
                db.PROGRESS_DETAILS.Add(pROGRESS_DETAILS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RANK_ID = new SelectList(db.RANK_DETAILS, "RANK_ID", "BELT_NAME", pROGRESS_DETAILS.RANK_ID);
            ViewBag.STUDENT_ID = new SelectList(db.STUDENT_DETAILS, "STUDENT_ID", "FIRST_NAME", pROGRESS_DETAILS.STUDENT_ID);
            
            return View(pROGRESS_DETAILS);
        }

        // GET: PROGRESS_DETAILS/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PROGRESS_DETAILS pROGRESS_DETAILS = db.PROGRESS_DETAILS.Find(id);
            if (pROGRESS_DETAILS == null)
            {
                return HttpNotFound();
            }
            ViewBag.RANK_ID = new SelectList(db.RANK_DETAILS, "RANK_ID", "BELT_NAME", pROGRESS_DETAILS.RANK_ID);
            ViewBag.STUDENT_ID = new SelectList(db.STUDENT_DETAILS, "STUDENT_ID", "FIRST_NAME", pROGRESS_DETAILS.STUDENT_ID);
            
            return View(pROGRESS_DETAILS);
        }

        // POST: PROGRESS_DETAILS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PROGRESS_ID,STUDENT_ID,RANK_ID,AWARDED_DATE")] PROGRESS_DETAILS pROGRESS_DETAILS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pROGRESS_DETAILS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RANK_ID = new SelectList(db.RANK_DETAILS, "RANK_ID", "BELT_NAME", pROGRESS_DETAILS.RANK_ID);
            ViewBag.STUDENT_ID = new SelectList(db.STUDENT_DETAILS, "STUDENT_ID", "FIRST_NAME", pROGRESS_DETAILS.STUDENT_ID);
            
            return View(pROGRESS_DETAILS);
        }

        // GET: PROGRESS_DETAILS/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PROGRESS_DETAILS pROGRESS_DETAILS = db.PROGRESS_DETAILS.Find(id);
            if (pROGRESS_DETAILS == null)
            {
                return HttpNotFound();
            }
            return View(pROGRESS_DETAILS);
        }

        // POST: PROGRESS_DETAILS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            PROGRESS_DETAILS pROGRESS_DETAILS = db.PROGRESS_DETAILS.Find(id);
            db.PROGRESS_DETAILS.Remove(pROGRESS_DETAILS);
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
