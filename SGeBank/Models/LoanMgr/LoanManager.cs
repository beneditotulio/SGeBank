using SGeBank.Models.LoanMgr.Bean;
using SGeBank.Models.LoanMgr.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SGeBank.Models.LoanMgr
{
    public class LoanManager
    {
        #region GENERATE NEW ID
        private static string GetNewId(string serie)
        {
            string newId = "";
            LoanMgrDbContext ctx = new LoanMgrDbContext();
            string entityId = ctx.loans.Where(x => x.lID.Contains(serie)).Max(x => x.lID);

            if (entityId == null || entityId == "")
            {
                newId = serie + "000001";
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
        #endregion

        public static Loan Create(Loan loan)
        {

            using (LoanMgrDbContext ctx = new LoanMgrDbContext())
            {
                using (var transaction = ctx.Database.BeginTransaction())
                {
                    try
                    {
                        loan.lID = GetNewId("LON");
                        loan.lDate = DateTime.Today;
                        loan.lExpiredDate = Convert.ToDateTime(DateTime.Today.AddDays(Convert.ToInt32(loan.lparcelType) * loan.lparcelNum));
                        loan.lPaymentDate = DateTime.Today;
                        ctx.loans.Add(loan);
                        int SaveResult = ctx.SaveChanges();
                        if (SaveResult == 1)
                        {
                            for (int i = 1; i < loan.lparcelNum + 1; i++)
                            {                            
                                Parcel parcels = new Parcel();
                                parcels.lId = loan.lID;
                                parcels.pDate = Convert.ToDateTime(loan.lDate.AddDays((Convert.ToInt32(loan.lparcelType) * i)));
                                parcels.pOrder = i;
                                parcels.pValue = loan.lParcelValue;
                                parcels.pStatus = 0;
                                ctx.parcels.Add(parcels);
                                ctx.SaveChanges();
                            }
                        }
                        transaction.Commit();
                        return loan;
                    }
                    catch (Exception ex)
                    {
                        
                        transaction.Rollback();
                    }

                }

            }

            return loan;
        }
    
          #region PARCELS
              public static List<vwParcel> getParcelsByLoanId(string loanId)
              {
                  using(LoanMgrDbContext ctx = new LoanMgrDbContext())
                  {
                      return ctx.vwParcels.Where(x => x.lId == loanId).ToList();
                  }
              }
          #endregion
    }


}