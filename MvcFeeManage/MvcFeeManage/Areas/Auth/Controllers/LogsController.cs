using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcFeeManage.Areas.Auth.Models;

namespace MvcFeeManage.Areas.Auth.Controllers
{
    public class LogsController : Controller
    {
        dbcontext db = new dbcontext();
        // GET: Auth/Logs
        public ActionResult Index()
        {
            return View(db.Fees_Master.ToList());
        }

        // GET: Auth/Logs/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Auth/Logs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Auth/Logs/Create
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

        // GET: Auth/Logs/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Auth/Logs/Edit/5
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

        // GET: Auth/Logs/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Auth/Logs/Delete/5
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
