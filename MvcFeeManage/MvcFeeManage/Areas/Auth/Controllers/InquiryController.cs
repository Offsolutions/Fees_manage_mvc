using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcFeeManage.Areas.Auth.Models;

namespace MvcFeeManage.Areas.Auth.Controllers
{
    public class InquiryController : Controller
    {
        private dbcontext db = new dbcontext();

        // GET: Auth/Inquiry
        public ActionResult Index()
        {
            var course = db.Courses.ToList();
            return View(db.tblinquiries.ToList());
        }

        // GET: Auth/Inquiry/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblinquiry tblinquiry = db.tblinquiries.Find(id);
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName");
            if (tblinquiry == null)
            {
                return HttpNotFound();
            }
            return View(tblinquiry);
        }

        // GET: Auth/Inquiry/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName");
            return View();
        }

        // POST: Auth/Inquiry/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,date,inquiryid,name,fname,contact,address,referedby,CourseId,status")] tblinquiry tblinquiry)
        {
            if (ModelState.IsValid)
            {
                tblinquiry inquiry = db.tblinquiries.FirstOrDefault();
                if (inquiry == null)
                {
                    tblinquiry.inquiryid= "I_102";
                }
                else
                {
                    var ab = db.tblinquiries.Max(x => x.inquiryid);
                    string []vall = ab.Split('_');
                    string neww = (Convert.ToInt32(vall[1].ToString()) + 1).ToString();
                    tblinquiry.inquiryid = "I_"+neww;
                }
                tblinquiry.status = true;
                db.tblinquiries.Add(tblinquiry);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblinquiry);
        }

        // GET: Auth/Inquiry/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblinquiry tblinquiry = db.tblinquiries.Find(id);
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName");
            if (tblinquiry == null)
            {
                return HttpNotFound();
            }
            return View(tblinquiry);
        }

        // POST: Auth/Inquiry/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,date,inquiryid,name,fname,contact,address,referedby,CourseId,status")] tblinquiry tblinquiry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblinquiry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblinquiry);
        }

        // GET: Auth/Inquiry/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblinquiry tblinquiry = db.tblinquiries.Find(id);
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName");
            if (tblinquiry == null)
            {
                return HttpNotFound();
            }
            return View(tblinquiry);
        }

        // POST: Auth/Inquiry/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblinquiry tblinquiry = db.tblinquiries.Find(id);
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName");
            db.tblinquiries.Remove(tblinquiry);
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
