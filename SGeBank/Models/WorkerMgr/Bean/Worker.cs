using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SGeBank.Models.WorkerMgr.Bean
{
    [Table("WORKER")]
    public class Worker
    {
        [Column("WID"), Key]
        public string wid { get; set; }
        [Column("WNAME"), Display(Name = "Nome")]
        public string workerName { get; set; }
        [Column("WSURNAME"), Display(Name = "Apelido")]
        public string workerSurname { get; set; }
        [Column("WDOCTYPE"), Display(Name = "Tipo de Doc.")]
        public string wDoctype { get; set; }
        [Column("WTYPE"), Display(Name = "Tipo Func.")]
        public string wType { get; set; }
        [Column("WDOCNUM"), Display(Name = "N. do Doc.")]
        public string cDocnum { get; set; }
        [Column("WGENDER"), Display(Name = "Genero")]
        public string wGender { get; set; }
        [Column("WADDRESS"), Display(Name = "Endereco")]
        public string wAddress { get; set; }
        [Column("WPHONE1"), Display(Name = "Contacto1")]
        public string wPhone { get; set; }
        [Column("WPHONE2"), Display(Name = "Contacto2")]
        public string wPhone2 { get; set; }
        [Column("WEMAIL"), Display(Name = "Email")]
        public string wEmail { get; set; }
    }
}