using SGeBank.Models.ClientMgr.Bean;
using SGeBank.Models.ClientMgr.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SGeBank.Models.ClientMgr
{
    public class ClientManager
    {
        private static string GetNewId(string serie)
        {
            string newId = "";
            ClientMgrDbContext ctx = new ClientMgrDbContext();
            string entityId = ctx.Clients.Where(x => x.cid.Contains(serie)).Max(x => x.cid);

            if (entityId == null || entityId == "")
            {
                newId = serie + "0001";
            }
            else
            {
                int lengthSerie = serie.Length;
                string tempStr = "1" + entityId.Remove(0, lengthSerie).ToString();
                decimal tempDec = (Convert.ToDecimal(tempStr) + 1);
                string tempStr1 = tempDec.ToString();
                newId = serie + tempStr1.Remove(0, 1);
            }
            return newId;
        }
        public static Client Create (Client clients)
        {
            using(ClientMgrDbContext ctx = new ClientMgrDbContext())
            {
                clients.cid = GetNewId("CLI");
                ctx.Clients.Add(clients);
                ctx.SaveChanges();
                return clients;
            }
        }
        public static List<vwClients> GetAllClients()
        {
            using (ClientMgrDbContext ctx = new ClientMgrDbContext())
            {
                return ctx.vwClients.ToList();
            }
        }
    }
}