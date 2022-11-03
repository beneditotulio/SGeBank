using SGeBank.Models.ClientMgr.Bean;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SGeBank.Models.ClientMgr.Db
{
    public class ClientMgrDbContext : DbContext
    {
        public ClientMgrDbContext() : base("DefaultConnection")
        {
            Database.SetInitializer<ClientMgrDbContext>(null);
        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<vwClients> vwClients { get; set; }
    }
}