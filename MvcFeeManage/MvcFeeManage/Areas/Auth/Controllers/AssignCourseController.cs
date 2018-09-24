﻿using System;
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
    public class AssignCourseController : Controller
    {
        private dbcontext db = new dbcontext();
        public static int rollno;
        // GET: Auth/AssignCourse
        public ActionResult Index(int roll)
        {
            rollno = roll;
            var course = db.Courses.ToList();
            var room = db.tblrooms.ToList();
            return View(db.Student_Course.Where(x => x.RollNo == roll).ToList());
        }

        // GET: Auth/AssignCourse/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student_Course student_Course = db.Student_Course.Find(id);
            if (student_Course == null)
            {
                return HttpNotFound();
            }
            return View(student_Course);
        }

        // GET: Auth/AssignCourse/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName");
            ViewBag.RoomId = new SelectList(db.tblrooms, "RoomId", "room");
            ViewBag.rollno = rollno;
            return View();
        }

        // POST: Auth/AssignCourse/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RollNo,CourseId,Admitdate,enddate,Fees,Uid,RoomId,Status")] Student_Course student_Course)
        {
            if (ModelState.IsValid)
            {
                student_Course.Uid = Session["User"].ToString();
                student_Course.RollNo = rollno;
                db.Student_Course.Add(student_Course);
                db.SaveChanges();

                Fees_Master feemaster = new Fees_Master();
                feemaster.RollNo = student_Course.RollNo;
                feemaster.Date = System.DateTime.Now;
                feemaster.CourseId = student_Course.CourseId;
                feemaster.AlertDate = System.DateTime.Now.AddDays(2);
                feemaster.Status = true;
                feemaster.TotalFees = Convert.ToInt32(student_Course.Fees);
                db.Fees_Master.Add(feemaster);
                db.SaveChanges();
                return RedirectToAction("Index",new { roll = rollno });
            }

            return View(student_Course);
        }

        // GET: Auth/AssignCourse/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student_Course student_Course = db.Student_Course.Find(id);
            rollno = student_Course.RollNo;
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName");
            ViewBag.RoomId = new SelectList(db.tblrooms, "RoomId", "room");
            if (student_Course == null)
            {
                return HttpNotFound();
            }
            return View(student_Course);
        }

        // POST: Auth/AssignCourse/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RollNo,CourseId,Admitdate,enddate,Fees,Uid,RoomId,Status")] Student_Course student_Course)
        {
            if (ModelState.IsValid)
            {
                student_Course.RollNo = rollno;
                student_Course.Uid = Session["User"].ToString();
                db.Entry(student_Course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { roll = rollno });
            }
            return View(student_Course);
        }

        // GET: Auth/AssignCourse/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student_Course student_Course = db.Student_Course.Find(id);
            rollno = student_Course.RollNo;
            if (student_Course == null)
            {
                return HttpNotFound();
            }
            return View(student_Course);
        }

        // POST: Auth/AssignCourse/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student_Course student_Course = db.Student_Course.Find(id);
            rollno = student_Course.RollNo;
            db.Student_Course.Remove(student_Course);
            db.SaveChanges();
            Fees_Master feemaster = db.Fees_Master.SingleOrDefault(x => x.RollNo == rollno);
            db.Fees_Master.Remove(feemaster);
            db.SaveChanges();
            return RedirectToAction("Index", new { roll = rollno });
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
