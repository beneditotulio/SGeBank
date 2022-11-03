using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SGeBank.Models.BasicMgr.Bean
{
    [Table("BASICMGR_GENERAL_CLASSIFIER")]
    public class GeneralClassifier
    {
        [Column("ID"), Key]
        public string Id { get; set; }

        [Column("PARENT_ID")]
        public string ParentId { get; set; }

        [Column("CLASSIFIER_TYPE")]
        public string ClassifierType { get; set; }

        [Column("DESCRIPTION"), Required(ErrorMessage = "* é obrigatoria.")]
        [Display(Name = "Descrição")]
        public string Description { get; set; }

        [Column("BRANCH_CODE")]
        public decimal BranchCode { get; set; }

        [Column("SHORT_NAME")]
        public string ShortName { get; set; }

        [Column("ISDEAULT")]
        public int IsDefault { get; set; }

        [Column("ENTITY_ID")]
        public string EntityId { get; set; }

        [Column("EXT_CODE")]
        public string ExtCode { get; set; }

        [Column("DESCRIPTION2")]
        public string Description2 { get; set; }

        /// <summary>
        /// Non Persistent Properties
        /// </summary>
        [NotMapped]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [NotMapped]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }
        //public bool Status { get; set; }

        public GeneralClassifier()
        {
            ShortName = " "; IsDefault = 0; EntityId = " "; ExtCode = " "; Description2 = " ";
            StartDate = DateTime.Today.Date;
            //EndDate = Convert.ToDateTime("31-12-9999").Date;
        }

        //[NotMapped]
        //public EntityLifeCycle Lifecycle { get; set; }

    }
}