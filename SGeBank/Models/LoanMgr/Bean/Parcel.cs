using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SGeBank.Models.LoanMgr.Bean
{
    [Table("PARCEL")]
    public class Parcel
    {
        [Column("LID", Order = 0),Key]
        public string lId { get; set; }
        [Column("PDATE"), Display(Name = "Data de Pagamento")]
        public DateTime pDate { get; set; }
        [Column("PORDER", Order = 1), Display(Name = "Ordem"), Key]
        public int pOrder { get; set; }
        [Column("PVALUE"), Display(Name = "Valor a Pagar")]
        public decimal pValue { get; set; }
        [Column("PSTATUS"), Display(Name ="Estado")]
        public int pStatus{ get; set; }
        [Column("PPENALTY"), Display(Name = "Multa")]
        public decimal pPenalty { get; set; }
    }
}