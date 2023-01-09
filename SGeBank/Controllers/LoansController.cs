using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SGeBank.Models.ClientMgr;
using SGeBank.Models.ClientMgr.Bean;
using SGeBank.Models.LoanMgr;
using SGeBank.Models.LoanMgr.Bean;
using SGeBank.Models.LoanMgr.Db;
using SGeBank.Models.WorkerMgr;
using SGeBank.Models.WorkerMgr.Bean;

namespace SGeBank.Controllers
{
    public class LoansController : Controller
    {
        private LoanMgrDbContext db = new LoanMgrDbContext();

        // GET: Loans
        public ActionResult Index()
        {
            //return View(db.loans.ToList());
            return View(db.vwLoans.ToList());
        }

        // GET: Loans/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loan loan = db.loans.Find(id);
            if (loan == null)
            {
                return HttpNotFound();
            }
            return View(loan);
        }

        // GET: Loans/Create
        public ActionResult Create()
        {
            List<SelectListItem> paymentType = new List<SelectListItem>
            {
                new SelectListItem() { Text = "Semanal", Selected = true, Value = "7"},
                new SelectListItem() { Text = "Quinzenal", Selected = false, Value = "15"},
                new SelectListItem() { Text = "Mensal", Selected = false, Value = "30"},
            };

            List<SelectListItem> paymentTax = new List<SelectListItem>
            {
                new SelectListItem() { Text = "25%", Selected = true, Value = "25"},
                new SelectListItem() { Text = "30%", Selected = false, Value = "30"},
                new SelectListItem() { Text = "40%", Selected = false, Value = "40"},
                new SelectListItem() { Text = "45%", Selected = false, Value = "45"},
            };
            List<vwWorkers> Workers = WorkerManager.GetAllWorkersByType("GESTOR").ToList();
            List<vwClients> Clients = ClientManager.GetAllClients();
            ViewData["WORKERS"] = Workers;
            ViewData["CLIENTS"] = Clients;
            ViewData["PAYMENT_TYPE"] = paymentType;
            ViewData["PAYMENT_TAX"] = paymentTax;
            return View();
        }

        // POST: Loans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "lID,clientId,workerId,loanValue,lparcelType,lparcelNum,lTax,lPaymentValue,lParcelValue,lIncome,lDate,lBalance,lExpiredDate,lPaymentDate")] Loan loan)
        {
            if (ModelState.IsValid)
            {
                loan.lPaymentValue = Convert.ToDecimal(Request.Form["payment"]);
                loan.lParcelValue = Convert.ToDecimal(Request.Form["parcel"]);
                loan.lIncome = Convert.ToDecimal(Request.Form["income"]);
                LoanManager.Create(loan);
                //db.loans.Add(loan);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loan);
        }

        // GET: Loans/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loan loan = db.loans.Find(id);
            if (loan == null)
            {
                return HttpNotFound();
            }
            return View(loan);
        }

        // POST: Loans/Edit/5
        // To protect from overposting attacks, enable       the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "lID,clientId,workerId,loanValue,lparcelType,lparcelNum,lTax,lPaymentValue,lParcelValue,lIncome,lDate,lBalance,lExpiredDate,lPaymentDate")] Loan loan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loan);
        }

        // GET: Loans/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loan loan = db.loans.Find(id);
            if (loan == null)
            {
                return HttpNotFound();
            }
            return View(loan);
        }

        // POST: Loans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Loan loan = db.loans.Find(id);
            db.loans.Remove(loan);
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

        #region PARCELS
        public ActionResult GetParcelByLoanId(string loanId)
        {
            List<vwParcel> model = new List<vwParcel>();
            model = LoanManager.getParcelsByLoanId(loanId);
            return View("~/Views/Loans/Parcels/Parcels.cshtml", model);
        }
        public ActionResult ParcelPayment(string[] order)
        {
            return View("");
        }
        #endregion
    }
}
