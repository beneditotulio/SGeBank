using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using eMais.ApplicationMgr;
using SGeBank.Models.BasicMgr;
using SGeBank.Models.BasicMgr.Bean;
using SGeBank.Models.ClientMgr;
using SGeBank.Models.ClientMgr.Bean;
using SGeBank.Models.ClientMgr.Db;

namespace SGeBank.Controllers
{
    [Authorize]
    public class ClientsController : Controller
    {
        private ClientMgrDbContext db = new ClientMgrDbContext();

        // GET: Clients
        public ActionResult Index()
        {
            //return View(db.Clients.ToList());
            return View(db.vwClients.ToList());
        }

        // GET: Clients/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // GET: Clients/Create
        public ActionResult Create()
        {
            List<GeneralClassifier> DocType = BasicManager.GetAllGNClassifierByType("DOCTYPE_CLASSIFIER").ToList();
            List<GeneralClassifier> Gender = BasicManager.GetAllGNClassifierByType("GENDER_CLASSIFIER").ToList();
            ViewData["DOCTYPE"] = DocType;
            ViewData["GENDER"] = Gender;
            return PartialView();
        }

        // POST: Clients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cid,clientName,clientSurname,cDoctype,cDocnum,cGender,cAddress,cPhone,cPhone2,cEmail")] Client client)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var c = ClientManager.Create(client);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    string innerExp = "";
                    if (ex.InnerException != null)
                    {
                        innerExp = "controller [eBank.Controllers.CientsController] " +
                        " action [ConfigureUser] error: " + ex.InnerException;
                    }

                    LogsManager.writeErrorLogs(ex.Message, innerExp);
                }
            }
            
            return View(client);
        }

        // GET: Clients/Edit/5
        public ActionResult Edit(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            List<GeneralClassifier> DocType = BasicManager.GetAllGNClassifierByType("DOCTYPE_CLASSIFIER").ToList();
            List<GeneralClassifier> Gender = BasicManager.GetAllGNClassifierByType("GENDER_CLASSIFIER").ToList();
            ViewData["DOCTYPE"] = DocType;
            ViewData["GENDER"] = Gender;
            return View(client);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cid,clientName,clientSurname,cDoctype,cDocnum,cGender,cAddress,cPhone,cPhone2,cEmail")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(client);
        }

        // GET: Clients/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Client client = db.Clients.Find(id);
            db.Clients.Remove(client);
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
