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
    public class ExamRegController : Controller
    {
        private dbcontext db = new dbcontext();

        // GET: Auth/ExamReg
        public ActionResult Index()
        {
            return View(db.tblfills.ToList());
        }

        // GET: Auth/ExamReg/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblfill tblfill = db.tblfills.Find(id);
            if (tblfill == null)
            {
                return HttpNotFound();
            }
            return View(tblfill);
        }

        // GET: Auth/ExamReg/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Auth/ExamReg/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,date,name,passport,dob,doe,choice1,choice2,choice3,module,v1,v2,v3,mode,instname,status,fid,uname,pass")] tblfill tblfill)
        {
            if (ModelState.IsValid)
            {
                db.tblfills.Add(tblfill);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblfill);
        }

        // GET: Auth/ExamReg/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblfill tblfill = db.tblfills.Find(id);
            if (tblfill == null)
            {
                return HttpNotFound();
            }
            return View(tblfill);
        }

        // POST: Auth/ExamReg/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,date,name,passport,dob,doe,choice1,choice2,choice3,module,v1,v2,v3,mode,instname,status,fid,uname,pass")] tblfill tblfill)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblfill).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblfill);
        }

        // GET: Auth/ExamReg/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblfill tblfill = db.tblfills.Find(id);
            if (tblfill == null)
            {
                return HttpNotFound();
            }
            return View(tblfill);
        }

        // POST: Auth/ExamReg/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblfill tblfill = db.tblfills.Find(id);
            db.tblfills.Remove(tblfill);
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
