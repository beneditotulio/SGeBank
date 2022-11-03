using SGeBank.Models.ClientMgr.Db;
using SGeBank.Models.WorkerMgr.Bean;
using SGeBank.Models.WorkerMgr.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SGeBank.Models.WorkerMgr
{
    public class WorkerManager
    {
        private static string GetNewId(string serie)
        {
            string newId = "";
            WorkerMgrDbContext ctx = new WorkerMgrDbContext();
            string entityId = ctx.workers.Where(x => x.wid.Contains(serie)).Max(x => x.wid);

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
        public static Worker Create(Worker workers)
        {
            using (WorkerMgrDbContext ctx = new WorkerMgrDbContext())
            {
                workers.wid = GetNewId("WRK");
                ctx.workers.Add(workers);
                ctx.SaveChanges();
                return workers;
            }
        }
        public static List<vwWorkers> GetAllWorkersByType(string type)
        {
            using (WorkerMgrDbContext ctx = new WorkerMgrDbContext())
            {
                return ctx.vwWorkers.Where(x => x.wType == type).ToList();
            }
        }
    }
}