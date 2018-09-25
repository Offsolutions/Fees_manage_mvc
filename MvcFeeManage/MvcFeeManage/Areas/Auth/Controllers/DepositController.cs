using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcFeeManage.Areas.Auth.Models;
using onlineportal.Areas.AdminPanel.Models;

namespace MvcFeeManage.Areas.Auth.Controllers
{
    public class DepositController : Controller
    {
        public dbcontext db = new dbcontext();
        public static int rollno;
        // GET: Auth/Deposit
        public ActionResult Index()
        {
            return View();
        }

        // GET: Auth/Deposit/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Auth/Deposit/Create
        public ActionResult Create(int roll)
        {
            rollno = roll;
            var asigncours = db.Student_Course.Where(x => x.RollNo == roll && x.Status == true).FirstOrDefault().CourseId;
            var courses = db.Courses.Where(x => x.CourseId == asigncours);
     
            ViewBag.CourseId = new SelectList(courses, "CourseId", "CourseName");
            ViewBag.RollNo = roll;
            Recipt_Details receiptd = db.Recipt_Details.FirstOrDefault();
            if (receiptd == null)
            {
                var receip = db.tblReceipt.FirstOrDefault();
                if (receip == null)
                {
                        ViewBag.Receipt = 1;
                }
                else
                {
                    var recp = receip.Start_no;
                    ViewBag.Receipt = recp;
                }
            }
            else
            {
                var ab = db.Recipt_Details.Max(x => x.ReciptNo);
                ViewBag.Receipt = Convert.ToInt32(ab) + 1;
            }

            return View();
        }

        // POST: Auth/Deposit/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Auth/Deposit/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Auth/Deposit/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Auth/Deposit/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Auth/Deposit/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
