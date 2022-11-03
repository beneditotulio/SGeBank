using SGeBank.Models.BasicMgr.Bean;
using SGeBank.Models.BasicMgr.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SGeBank.Models.BasicMgr
{
    public class BasicManager
    {
        #region Get GeneralClassifier data
        public static List<GeneralClassifier> GetAllGNClassifierByType(string type)
        {
            using (BasicMgrDBContext context = new BasicMgrDBContext())
            {
                return context.GeneralClassifiers.Where(m => m.ClassifierType == type && m.Description != "AVALISTA").ToList();
            }
        }
        public static GeneralClassifier GetGNClassifierById(string id)
        {
            using (BasicMgrDBContext context = new BasicMgrDBContext())
            {
                return context.GeneralClassifiers.Where(m => m.Id == id).FirstOrDefault();
            }
        }
        #endregion
    }
}