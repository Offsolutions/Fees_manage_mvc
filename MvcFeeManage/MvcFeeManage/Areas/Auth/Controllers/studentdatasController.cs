using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcFeeManage.Areas.Auth.Models;
using onlineportal.Areas.AdminPanel.Models;
using System.Web.Script.Serialization;

namespace MvcFeeManage.Areas.Auth.Controllers
{
    public class studentdatasController : Controller
    {
        private dbcontext db = new dbcontext();
        public static string img;
        // GET: Auth/studentdatas
        public ActionResult Index()
        {
            var course = db.Courses.ToList();
            var room = db.tblrooms.ToList();
            return View(db.tblstudentdata.ToList());
        }

        // GET: Auth/studentdatas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblstudentdata tblstudentdata = db.tblstudentdata.Find(id);
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName");
            if (tblstudentdata == null)
            {
                return HttpNotFound();
            }
            return View(tblstudentdata);
        }

        // GET: Auth/studentdatas/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName");
            ViewBag.RoomId = new SelectList(db.tblrooms, "RoomId", "room");
            return View();
        }

        // POST: Auth/studentdatas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,rollno,name,dob,fathername,address,phone,fatherphn,language,board,qualification,coaching,institutename,type,refferedby,image,uid,Status,username,password,gender,remarks,email,discount,date")] tblstudentdata tblstudentdata, HttpPostedFileBase file, Helper Help,DateTime joining,DateTime enddate,string addmission,int CourseId,int RoomId)
        {
            if (ModelState.IsValid)
            {
                tblstudentdata studentdata = db.tblstudentdata.FirstOrDefault();
                if (studentdata == null)
                {
                    tblstudentdata.rollno = 1;
                }
                else
                {
                    var ab = db.tblstudentdata.Max(x => x.rollno);
                    tblstudentdata.rollno = Convert.ToInt32(ab) + 1;
                }
                tblstudentdata.uid = Session["User"].ToString();
                tblstudentdata.image = Help.uploadfile(file);
                db.tblstudentdata.Add(tblstudentdata);
                db.SaveChanges();

                //Recipt_Details receiptdetail = new Recipt_Details();
                //receiptdetail.RollNo = tblstudentdata.rollno;
                Fees_Master feemaster = new Fees_Master();
                feemaster.RollNo = tblstudentdata.rollno;
                feemaster.Date = tblstudentdata.date;
                //feemaster.CourseId = CourseId;
                feemaster.AlertDate = System.DateTime.Now.AddDays(2);
                feemaster.discount = tblstudentdata.discount;
                feemaster.Status = true;
                feemaster.TotalFees = Convert.ToInt32(addmission);
                db.Fees_Master.Add(feemaster);
                db.SaveChanges();

                StudentCourse studentcourse = new StudentCourse();
                studentcourse.RollNo = tblstudentdata.rollno;
                studentcourse.RoomId = RoomId;
                studentcourse.CourseId = CourseId;
                studentcourse.Admitdate = joining;
                studentcourse.enddate = enddate;
                studentcourse.Fees = addmission;
                studentcourse.Uid = Session["User"].ToString();
                studentcourse.Status = true;
                db.StudentCourse.Add(studentcourse);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(tblstudentdata);
        }

        // GET: Auth/studentdatas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblstudentdata tblstudentdata = db.tblstudentdata.Find(id);
            img = tblstudentdata.image;
            if (tblstudentdata == null)
            {
                return HttpNotFound();
            }
            return View(tblstudentdata);
        }

        // POST: Auth/studentdatas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,name,dob,fathername,address,phone,fatherphn,language,board,qualification,coaching,institutename,type,refferedby,image,uid,Status,username,password,gender,remarks,email,discount,date")] tblstudentdata tblstudentdata, HttpPostedFileBase file, Helper Help)
        {
            if (ModelState.IsValid)
            {
                tblstudentdata.image = file != null ? Help.uploadfile(file) : img;
                #region delete file
                string fullPath = Request.MapPath("~/UploadedFiles/" + img);
                if (img == tblstudentdata.image)
                {
                }
                else
                {
                    if (System.IO.File.Exists(fullPath))
                    {
                        System.IO.File.Delete(fullPath);
                    }
                }
                #endregion
                db.Entry(tblstudentdata).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblstudentdata);
        }

        // GET: Auth/studentdatas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblstudentdata tblstudentdata = db.tblstudentdata.Find(id);
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName");
            if (tblstudentdata == null)
            {
                return HttpNotFound();
            }
            return View(tblstudentdata);
        }

        // POST: Auth/studentdatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblstudentdata tblstudentdata = db.tblstudentdata.Find(id);
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName");
            img = tblstudentdata.image;
            #region delete file
            string fullPath = Request.MapPath("~/UploadedFiles/" + img);
            if (img == tblstudentdata.image)
            {
            }
            else
            {
                if (System.IO.File.Exists(fullPath))
                {
                    System.IO.File.Delete(fullPath);
                }
            }
            #endregion
            db.tblstudentdata.Remove(tblstudentdata);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
 
        public ActionResult View(int roll)
        {
            return RedirectToAction("Index", "AssignCourse", new { roll = roll });
        }
        public ActionResult Deposit(int roll)
        {
            return RedirectToAction("Create", "Deposit", new { roll = roll });
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult Fee(int stateID)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<Course> Course = new List<Course>();

            Course = (db.Courses.Where(x => x.CourseId == stateID)).ToList();
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            string result = javaScriptSerializer.Serialize(Course);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
