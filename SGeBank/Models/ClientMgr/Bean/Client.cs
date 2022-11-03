using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SGeBank.Models.ClientMgr.Bean
{
    [Table("CLIENT")]
    public class Client
    {
        [Column("CID"), Key]
        public string cid  { get; set; }
        [Column("CNAME"), Display(Name ="Nome")]
        public string clientName { get; set; }
        [Column("CSURNAME"), Display(Name = "Apelido")]
        public string clientSurname { get; set; }
        [Column("CDOCTYPE"), Display(Name = "Tipo de Doc.")]
        public string cDoctype { get; set; }
        [Column("CDOCNUM"), Display(Name = "N. do Doc.")]
        public string cDocnum { get; set; }
        [Column("CGENDER"), Display(Name = "Genero")]
        public string cGender { get; set; }
        [Column("CADDRESS"), Display(Name = "Endereco")]
        public string cAddress { get; set; }
        [Column("CPHONE1"), Display(Name = "Contacto1")]
        public string cPhone { get; set; }
        [Column("CPHONE2"), Display(Name = "Contacto2")]
        public string cPhone2 { get; set; }
        [Column("CEMAIL"), Display(Name = "Email")]
        public string cEmail { get; set; }

    }
}