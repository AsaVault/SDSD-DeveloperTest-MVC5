using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SDSD_DeveloperTest_MVC5.Models;
using SDSD_DeveloperTest_MVC5.ViewModel;

namespace SDSD_DeveloperTest_MVC5.Controllers
{
    public class UserDetailController : Controller
    {
        private DeveloperTestDbContext db = new DeveloperTestDbContext();

        // GET: UserDetail
        public ActionResult Index()
        {
            return View(db.UserDetail.ToList());
        }

        // GET: UserDetail/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDetail userDetail = db.UserDetail.Find(id);
            if (userDetail == null)
            {
                return HttpNotFound();
            }
            return View(userDetail);
        }

        // GET: UserDetail/Create
        public ActionResult Create()
        {
            return View(new CreateViewModel());
        }

        // POST: UserDetail/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( CreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var data = new UserDetail()
                {
                    UserDetailId = model.Id,
                    Name = model.Name,
                    Email = model.Email,
                    TransactionId = "Upload-" + Guid.NewGuid()
                };
                db.UserDetail.Add(data);
                db.SaveChanges();
                // Use your file here
                foreach (var file in model.FormFiles)
                {
                    if (file.ContentLength > 0)
                    {
                        var upload = new UserUpload();
                        //Check and change this after migration
                        //upload.UserUploadId = Guid.NewGuid();
                        upload.TransactionId = data.TransactionId;
                        upload.UserDetailId = data.UserDetailId;

                        // Get FileName
                        //upload.FileName = Path.GetFileName(file.FileName);
                        string folderPath = "/Files/";
                        string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                        string extension = Path.GetExtension(file.FileName);
                        fileName = fileName + Guid.NewGuid() + extension;
                        upload.FileName = fileName;
                        string filePath = folderPath + fileName;
                        upload.FilePath = filePath;
                        fileName = Path.Combine(Server.MapPath(folderPath), fileName);
                        file.SaveAs(fileName);
                        db.UserUpload.Add(upload);
                        db.SaveChanges();
                        // create file path
                        // save file to local storage
                        // save filepath on upload class
                    }
                }
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: UserDetail/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDetail userDetail = db.UserDetail.Find(id);
            if (userDetail == null)
            {
                return HttpNotFound();
            }
            return View(userDetail);
        }

        // POST: UserDetail/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserDetailId,TransactionId,Name,Email")] UserDetail userDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userDetail);
        }

        // GET: UserDetail/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDetail userDetail = db.UserDetail.Find(id);
            if (userDetail == null)
            {
                return HttpNotFound();
            }
            return View(userDetail);
        }

        // POST: UserDetail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            UserDetail userDetail = db.UserDetail.Find(id);
            db.UserDetail.Remove(userDetail);
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
