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
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName");
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
