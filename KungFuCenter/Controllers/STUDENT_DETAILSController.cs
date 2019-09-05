using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClinicManagement.Core.Models;
using PagedList;

namespace ClinicManagement.Controllers
{
    public class STUDENT_DETAILSController : Controller
    {
        private KungFuDBEntities2 db = new KungFuDBEntities2();


        // GET: STUDENT_DETAILS
    
        //Search & Paging
        public ActionResult Index(string currentFilter, string searchString, int? page, string sortOrder)
        {

            string id = searchString;
 

            ViewBag.FIRST_NAMESortParm = String.IsNullOrEmpty(sortOrder) ? "FIRST_NAME_desc" : "";
            ViewBag.LAST_NAMESortParm = String.IsNullOrEmpty(sortOrder) ? "LAST_NAME_desc" : "";
            ViewBag.DATE_OF_JOININGSortParm = sortOrder == "DATE_OF_JOINING" ? "DATE_OF_JOINING_desc" : "DATE_OF_JOINING";
            ViewBag.DOBSortParm = sortOrder == "DOB" ? "DOB_desc" : "DOB";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var students = from s in db.STUDENT_DETAILS  select s;

            if (!string.IsNullOrEmpty(searchString))
            {
                students = students.Where(s => s.FIRST_NAME.Contains(searchString) || s.LAST_NAME.Contains(searchString) || s.FATHER_NAME == searchString || s.MOTHER_NAME == searchString);
            }


            
            students = students.OrderBy(s => s.STUDENT_ID); //default sorting

            int pageSize = 5;
            int pageNumber = (page ?? 1);

            switch (sortOrder)
            {
                case "FIRST_NAME_desc":
                    students = students.OrderByDescending(s => s.FIRST_NAME);
                    break;
                case "LAST_NAME_desc":
                    students = students.OrderByDescending(s => s.LAST_NAME);
                    break;
                case "DATE_OF_JOINING_desc":
                    students = students.OrderByDescending(s => s.DATE_OF_JOINING);
                    break;
                case "DOB_desc":
                    students = students.OrderByDescending(s => s.DOB);
                    break;

            }

            return View(students.OrderByDescending(x => x.STUDENT_ID).ToPagedList(pageNumber, pageSize));
        }

        /*
        public ActionResult About(int a)
        {
            //ViewBag.TotalStudents = Session["TotalStudents"];
            return View();
        }
        */

        // GET: STUDENT_DETAILS/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STUDENT_DETAILS sTUDENT_DETAILS = db.STUDENT_DETAILS.Find(id);
            if (sTUDENT_DETAILS == null)
            {
                return HttpNotFound();
            }
            return View(sTUDENT_DETAILS);
        }

        // GET: STUDENT_DETAILS/Create
        public ActionResult Create()
        {
            ViewBag.RANK_ID = new SelectList(db.RANK_DETAILS, "RANK_ID", "BELT_NAME");
            ViewBag.CHILD_ID = new SelectList(db.STUDENT_DETAILS, "STUDENT_ID", "FIRST_NAME");
            ViewBag.CLASS_ID = new SelectList(db.CLASS_DETAILS, "CLASS_ID", "CLASS_NAME");
            return View();
        }

        // POST: STUDENT_DETAILS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "STUDENT_ID,RANK_ID,CLASS_ID,FIRST_NAME,LAST_NAME,DOB,DATE_OF_JOINING,CONTACT_NUM,EMAIL_ID,STREET_ADDRESS, STREET_ADDRESS_2, POSTAL_CODE, CITY, COUNTRY,BELT_NAME,ACTIVE,MOTHER_NAME,MOTHER_MOBILE_NO,MOTHER_EMAIL_ID,FATHER_NAME,FATHER_MOBILE_NO,FATHER_EMAIL_ID,IS_PARENT,CHILD_ID")] STUDENT_DETAILS sTUDENT_DETAILS)
        {
            if (ModelState.IsValid)
            {
                db.STUDENT_DETAILS.Add(sTUDENT_DETAILS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RANK_ID = new SelectList(db.RANK_DETAILS, "RANK_ID", "BELT_NAME", sTUDENT_DETAILS.RANK_ID);
            ViewBag.CHILD_ID = new SelectList(db.STUDENT_DETAILS, "STUDENT_ID", "FIRST_NAME", sTUDENT_DETAILS.CHILD_ID);
            ViewBag.CLASS_ID = new SelectList(db.CLASS_DETAILS, "CLASS_ID", "CLASS_NAME", sTUDENT_DETAILS.CLASS_ID);
            return View(sTUDENT_DETAILS);
        }

        // GET: STUDENT_DETAILS/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STUDENT_DETAILS sTUDENT_DETAILS = db.STUDENT_DETAILS.Find(id);
            if (sTUDENT_DETAILS == null)
            {
                return HttpNotFound();
            }

            ViewBag.CHILD_ID = new SelectList(db.STUDENT_DETAILS, "STUDENT_ID", "FIRST_NAME", sTUDENT_DETAILS.CHILD_ID);
            ViewBag.RANK_ID = new SelectList(db.RANK_DETAILS, "RANK_ID", "BELT_NAME", sTUDENT_DETAILS.RANK_ID);
            ViewBag.CLASS_ID = new SelectList(db.CLASS_DETAILS, "CLASS_ID", "CLASS_NAME", sTUDENT_DETAILS.CLASS_ID);
            return View(sTUDENT_DETAILS);
        }

        // POST: STUDENT_DETAILS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "STUDENT_ID,CLASS_ID, RANK_ID,FIRST_NAME,LAST_NAME,DOB,DATE_OF_JOINING,CONTACT_NUM,EMAIL_ID,STREET_ADDRESS, STREET_ADDRESS_2, POSTAL_CODE, CITY, COUNTRY,BELT_NAME,ACTIVE,MOTHER_NAME,MOTHER_MOBILE_NO,MOTHER_EMAIL_ID,FATHER_NAME,FATHER_MOBILE_NO,FATHER_EMAIL_ID,IS_PARENT,CHILD_ID")] STUDENT_DETAILS sTUDENT_DETAILS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sTUDENT_DETAILS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CHILD_ID = new SelectList(db.STUDENT_DETAILS, "STUDENT_ID", "FIRST_NAME", sTUDENT_DETAILS.CHILD_ID);
            ViewBag.RANK_ID = new SelectList(db.RANK_DETAILS, "RANK_ID", "BELT_NAME", sTUDENT_DETAILS.RANK_ID);
            ViewBag.CLASS_ID = new SelectList(db.CLASS_DETAILS, "CLASS_ID", "CLASS_NAME", sTUDENT_DETAILS.CLASS_ID);
            return View(sTUDENT_DETAILS);
        }

        // GET: STUDENT_DETAILS/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STUDENT_DETAILS sTUDENT_DETAILS = db.STUDENT_DETAILS.Find(id);
            if (sTUDENT_DETAILS == null)
            {
                return HttpNotFound();
            }
            return View(sTUDENT_DETAILS);
        }

        // POST: STUDENT_DETAILS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            STUDENT_DETAILS sTUDENT_DETAILS = db.STUDENT_DETAILS.Find(id);
            db.STUDENT_DETAILS.Remove(sTUDENT_DETAILS);
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
