using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SGeBank.Models.BasicMgr;
using SGeBank.Models.BasicMgr.Bean;
using SGeBank.Models.WorkerMgr;
using SGeBank.Models.WorkerMgr.Bean;
using SGeBank.Models.WorkerMgr.Db;

namespace SGeBank.Controllers
{
    public class WorkersController : Controller
    {
        private WorkerMgrDbContext db = new WorkerMgrDbContext();

        // GET: Workers
        public ActionResult Index()
        {
            //return View(db.workers.ToList());
            return View(db.vwWorkers.ToList());
        }

        // GET: Workers/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Worker worker = db.workers.Find(id);
            if (worker == null)
            {
                return HttpNotFound();
            }
            return View(worker);
        }

        // GET: Workers/Create
        public ActionResult Create()
        {
            List<GeneralClassifier> DocType = BasicManager.GetAllGNClassifierByType("DOCTYPE_CLASSIFIER").ToList();
            List<GeneralClassifier> Gender = BasicManager.GetAllGNClassifierByType("GENDER_CLASSIFIER").ToList();
            List<GeneralClassifier> WType = BasicManager.GetAllGNClassifierByType("WORKER_TYPE").ToList();
            ViewData["DOCTYPE"] = DocType;
            ViewData["GENDER"] = Gender;
            ViewData["WTYPE"] = WType;
            return View();
        }

        // POST: Workers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "wid,workerName,workerSurname,wDoctype,wType,cDocnum,wGender,wAddress,wPhone,wPhone2,wEmail")] Worker worker)
        {
            if (ModelState.IsValid)
            {
                var c = WorkerManager.Create(worker);
                //db.workers.Add(worker);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(worker);
        }

        // GET: Workers/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Worker worker = db.workers.Find(id);
            if (worker == null)
            {
                return HttpNotFound();
            }
            List<GeneralClassifier> DocType = BasicManager.GetAllGNClassifierByType("DOCTYPE_CLASSIFIER").ToList();
            List<GeneralClassifier> Gender = BasicManager.GetAllGNClassifierByType("GENDER_CLASSIFIER").ToList();
            List<GeneralClassifier> WType = BasicManager.GetAllGNClassifierByType("WORKER_TYPE").ToList();
            ViewData["DOCTYPE"] = DocType;
            ViewData["GENDER"] = Gender;
            ViewData["WTYPE"] = WType;
            return View(worker);
        }

        // POST: Workers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "wid,workerName,workerSurname,wDoctype,wType,cDocnum,wGender,wAddress,wPhone,wPhone2,wEmail")] Worker worker)
        {
            if (ModelState.IsValid)
            {
                db.Entry(worker).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(worker);
        }

        // GET: Workers/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Worker worker = db.workers.Find(id);
            if (worker == null)
            {
                return HttpNotFound();
            }
            return View(worker);
        }

        // POST: Workers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Worker worker = db.workers.Find(id);
            db.workers.Remove(worker);
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
