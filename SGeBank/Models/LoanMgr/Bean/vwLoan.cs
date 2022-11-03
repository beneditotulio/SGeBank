using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SGeBank.Models.LoanMgr.Bean
{
    [Table("vwLoans")]
    public class vwLoan
    {
        [Column("LID"), Key]
        public string lID { get; set; }
        [Column("CID"), Display(Name = "Cliente")]
        public string clientId { get; set; }
        [Column("WID"), Display(Name = "Gestor")]
        public string workerId { get; set; }
        [Column("LOAN_VALUE"), Display(Name = "V. do emprestimo")]
        public decimal loanValue { get; set; }
        [Column("LPARCEL_TYPE"), Display(Name = "Regime")]
        public string lparcelType { get; set; }
        [Column("LPARCEL_NUM"), Display(Name = "Nr. de Parcelas")]
        public int lparcelNum { get; set; }
        [Column("LTAX"), Display(Name = "Taxa de Juro")]
        public decimal lTax { get; set; }
        [Column("LPAYMENT_VALUE"), Display(Name = "Valor a Pagar")]
        public decimal lPaymentValue { get; set; }
        [Column("LPARCEL_VALUE"), Display(Name = "Valor parcela")]
        public decimal lParcelValue { get; set; }
        [Column("LINCOME"), Display(Name = "Lucro")]
        public decimal lIncome { get; set; }
        [Column("LDATE"), Display(Name = "Data de Registo")]
        public DateTime lDate { get; set; }
        [Column("LBALANCE"), Display(Name = "Saldo Actual")]
        public decimal lBalance { get; set; }
        [Column("LEXPIRED_DATE"), Display(Name = "Data Limite")]
        public DateTime lExpiredDate { get; set; }
        [Column("LPAYMENT_DATE"), Display(Name = "Data de Pagamento")]
        public DateTime lPaymentDate { get; set; }
    }
}