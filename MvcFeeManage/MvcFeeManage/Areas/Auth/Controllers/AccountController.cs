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
using System.Web.Security;

namespace MvcFeeManage.Areas.Auth.Controllers
{
    public class AccountController : Controller
    {
        private dbcontext db = new dbcontext();
        public static string img;
        // GET: Auth/Account
        public ActionResult Index()
        {
            return View(db.tblreceptionists.ToList());
        }

        // GET: Auth/Account/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblreceptionist tblreceptionist = db.tblreceptionists.Find(id);
            if (tblreceptionist == null)
            {
                return HttpNotFound();
            }
            return View(tblreceptionist);
        }

        // GET: Auth/Account/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Auth/Account/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,date,name,email,contact,login,password,rid,image,Type,status")] tblreceptionist tblreceptionist, HttpPostedFileBase file, Helper Help)
        {
            if (ModelState.IsValid)
            {
                //tblreceptionist recp = db.tblreceptionists.FirstOrDefault();
                //if (recp == null)
                //{
                //    tblreceptionist.rid = "r_1001";
                //}
                //else
                //{
                //    var valc = db.tblreceptionists.Max(x => x.rid);

                //    string[] rec = valc.Split('_');
                //    var ab = rec[1].ToString();
                //    tblreceptionist.rid = (Convert.ToInt32(ab) + 1).ToString();
                //}
                tblreceptionist.image = Help.uploadfile(file);
                db.tblreceptionists.Add(tblreceptionist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblreceptionist);
        }

        // GET: Auth/Account/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblreceptionist tblreceptionist = db.tblreceptionists.Find(id);
            img = tblreceptionist.image;
            if (tblreceptionist == null)
            {
                return HttpNotFound();
            }
            return View(tblreceptionist);
        }

        // POST: Auth/Account/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,date,name,email,contact,login,password,rid,image,Type,status")] tblreceptionist tblreceptionist, HttpPostedFileBase file, Helper Help)
        {
            if (ModelState.IsValid)
            {
                tblreceptionist.image = file != null ? Help.uploadfile(file) : img;
                #region delete file
                string fullPath = Request.MapPath("~/UploadedFiles/" + img);
                if (img == tblreceptionist.image)
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
                db.Entry(tblreceptionist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblreceptionist);
        }

        // GET: Auth/Account/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblreceptionist tblreceptionist = db.tblreceptionists.Find(id);
            img = tblreceptionist.image;
            if (tblreceptionist == null)
            {
                return HttpNotFound();
            }
            return View(tblreceptionist);
        }

        // POST: Auth/Account/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblreceptionist tblreceptionist = db.tblreceptionists.Find(id);
            img = tblreceptionist.image;
            #region delete file
            string fullPath = Request.MapPath("~/UploadedFiles/" + img);
            if (img == tblreceptionist.image)
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
            db.tblreceptionists.Remove(tblreceptionist);
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
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(tblreceptionist model, string returnUrl)
        {
            dbcontext db = new dbcontext();
            var dataItem = db.tblreceptionists.Where(x => x.login == model.login && x.password == model.password).First();
            if (dataItem != null)
            {
                FormsAuthentication.SetAuthCookie(dataItem.login, false);
                if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                         && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    TempData["Success"] = "Login Successfully";
                    Session["User"] = dataItem.rid;

                    return RedirectToAction("Index", "Default");

                }
            }
            else
            {
                ModelState.AddModelError("", "Invalid user/pass");
                return View();
            }
        }

        //[Authorize]
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }
    }
}
