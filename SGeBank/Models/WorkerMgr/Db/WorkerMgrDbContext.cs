using SGeBank.Models.WorkerMgr.Bean;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SGeBank.Models.WorkerMgr.Db
{
    public class WorkerMgrDbContext : DbContext
    {
        public WorkerMgrDbContext() : base("DefaultConnection")
        {
            Database.SetInitializer<WorkerMgrDbContext>(null);
        }
        public DbSet<Worker> workers { get; set; }
        public DbSet<vwWorkers> vwWorkers { get; set; }
    }
}