using SGeBank.Models.BasicMgr.Bean;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SGeBank.Models.BasicMgr.Db
{
    public class BasicMgrDBContext: DbContext
    {
        public BasicMgrDBContext() : base("DefaultConnection")
        {
            Database.SetInitializer<BasicMgrDBContext>(null);
        }

        public DbSet<GeneralClassifier> GeneralClassifiers { get; set; }
    }
}