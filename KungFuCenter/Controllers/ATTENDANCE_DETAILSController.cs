using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Globalization;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClinicManagement.Core.Models;

namespace ClinicManagement.Controllers
{
    public class ATTENDANCE_DETAILSController : Controller
    {
        private KungFuDBEntities2 db = new KungFuDBEntities2();

        // GET: ATTENDANCE_DETAILS
        public ActionResult Index(string fname, string lname, string searchString, string searchString1)
        {
            string searchfname = fname;
            string searchlname = lname;
            string startDate = searchString;
            string endDate = searchString1;
            var aTTENDANCE_DETAILS = from s in db.ATTENDANCE_DETAILS select s;

            //only name
            if (!string.IsNullOrEmpty(fname) && !string.IsNullOrEmpty(lname) && (string.IsNullOrEmpty(startDate) || string.IsNullOrEmpty(endDate)))
            {
                aTTENDANCE_DETAILS = db.ATTENDANCE_DETAILS
                             .Where(d => d.STUDENT_DETAILS.FIRST_NAME.Contains(searchfname) && d.STUDENT_DETAILS.LAST_NAME.Contains(searchlname));

            }

            //only one name from 2
            if (!string.IsNullOrEmpty(fname) || !string.IsNullOrEmpty(lname))
            {
                aTTENDANCE_DETAILS = db.ATTENDANCE_DETAILS
                            .Where(d => d.STUDENT_DETAILS.FIRST_NAME.Contains(searchfname) && d.STUDENT_DETAILS.LAST_NAME.Contains(searchlname));

            }

            if (!string.IsNullOrEmpty(startDate) && !string.IsNullOrEmpty(endDate))
            {
                DateTime startfilter = DateTime.ParseExact(startDate + " 00:00:00", "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                DateTime endfilter = DateTime.ParseExact(endDate + " 00:00:00", "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                aTTENDANCE_DETAILS = aTTENDANCE_DETAILS.Where(s => s.ATTENDANCE_DATE >= startfilter && s.ATTENDANCE_DATE <= endfilter);
            }
            if (!string.IsNullOrEmpty(fname) && !string.IsNullOrEmpty(lname) && !string.IsNullOrEmpty(startDate) && !string.IsNullOrEmpty(endDate))
            {
                DateTime startfilter = DateTime.ParseExact(startDate + " 00:00:00", "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                DateTime endfilter = DateTime.ParseExact(endDate + " 00:00:00", "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                aTTENDANCE_DETAILS = aTTENDANCE_DETAILS.Where(s => s.ATTENDANCE_DATE >= startfilter && s.ATTENDANCE_DATE <= endfilter && s.STUDENT_DETAILS.FIRST_NAME.Contains(searchfname) && s.STUDENT_DETAILS.LAST_NAME.Contains(searchlname));
            }



            return View(aTTENDANCE_DETAILS);
        }

        // GET: ATTENDANCE_DETAILS/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ATTENDANCE_DETAILS aTTENDANCE_DETAILS = db.ATTENDANCE_DETAILS.Find(id);
            if (aTTENDANCE_DETAILS == null)
            {
                return HttpNotFound();
            }
            return View(aTTENDANCE_DETAILS);
        }

        // GET: ATTENDANCE_DETAILS/Create
        public ActionResult Create()
        {
            ViewBag.CLASS_ID = new SelectList(db.CLASS_DETAILS, "CLASS_ID", "CLASS_NAME");
            ViewBag.STUDENT_ID = new SelectList(db.STUDENT_DETAILS, "STUDENT_ID", "FIRST_NAME");
            return View();
        }

        // POST: ATTENDANCE_DETAILS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ATTENDANCE_ID,CLASS_ID,STUDENT_ID,ATTENDANCE_DATE")] ATTENDANCE_DETAILS aTTENDANCE_DETAILS)
        {
            if (ModelState.IsValid)
            {
                db.ATTENDANCE_DETAILS.Add(aTTENDANCE_DETAILS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CLASS_ID = new SelectList(db.CLASS_DETAILS, "CLASS_ID", "CLASS_NAME", aTTENDANCE_DETAILS.CLASS_ID);
            ViewBag.STUDENT_ID = new SelectList(db.STUDENT_DETAILS, "STUDENT_ID", "FIRST_NAME", aTTENDANCE_DETAILS.STUDENT_ID);
            return View(aTTENDANCE_DETAILS);
        }

        // GET: ATTENDANCE_DETAILS/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ATTENDANCE_DETAILS aTTENDANCE_DETAILS = db.ATTENDANCE_DETAILS.Find(id);
            if (aTTENDANCE_DETAILS == null)
            {
                return HttpNotFound();
            }
            ViewBag.CLASS_ID = new SelectList(db.CLASS_DETAILS, "CLASS_ID", "CLASS_NAME", aTTENDANCE_DETAILS.CLASS_ID);
            ViewBag.STUDENT_ID = new SelectList(db.STUDENT_DETAILS, "STUDENT_ID", "FIRST_NAME", aTTENDANCE_DETAILS.STUDENT_ID);
            return View(aTTENDANCE_DETAILS);
        }

        // POST: ATTENDANCE_DETAILS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ATTENDANCE_ID,CLASS_ID,STUDENT_ID,ATTENDANCE_DATE")] ATTENDANCE_DETAILS aTTENDANCE_DETAILS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aTTENDANCE_DETAILS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CLASS_ID = new SelectList(db.CLASS_DETAILS, "CLASS_ID", "CLASS_NAME", aTTENDANCE_DETAILS.CLASS_ID);
            ViewBag.STUDENT_ID = new SelectList(db.STUDENT_DETAILS, "STUDENT_ID", "FIRST_NAME", aTTENDANCE_DETAILS.STUDENT_ID);
            return View(aTTENDANCE_DETAILS);
        }

        // GET: ATTENDANCE_DETAILS/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ATTENDANCE_DETAILS aTTENDANCE_DETAILS = db.ATTENDANCE_DETAILS.Find(id);
            if (aTTENDANCE_DETAILS == null)
            {
                return HttpNotFound();
            }
            return View(aTTENDANCE_DETAILS);
        }

        // POST: ATTENDANCE_DETAILS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            ATTENDANCE_DETAILS aTTENDANCE_DETAILS = db.ATTENDANCE_DETAILS.Find(id);
            db.ATTENDANCE_DETAILS.Remove(aTTENDANCE_DETAILS);
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
