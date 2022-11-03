using SGeBank.Models.LoanMgr.Bean;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SGeBank.Models.LoanMgr.Db
{
    public class LoanMgrDbContext: DbContext
    {
        public LoanMgrDbContext() : base("DefaultConnection")
        {
            Database.SetInitializer<LoanMgrDbContext>(null);
        }
        public DbSet<Loan> loans { get; set; }
        public DbSet<Parcel> parcels { get; set; }
        public DbSet<vwLoan> vwLoans { get; set; }
        public DbSet<vwParcel> vwParcels { get; set; }
    }
}