using alar.DAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace alar.DAL.Classes.BaseObjects
{
    public class BaseObject
    {
        [Key]
        public int ID { get; set; }
          
        [DisplayName("Silindi Bilgisi")]
        public ObjectStatus ObjectStatus { get; set; }

        [Browsable(false)]
        [ScaffoldColumn(false)]
        //[ReadOnly(true)]
        [DisplayName("Oluşturulma Tarihi")]       
        public DateTime CreatedDate { get; set; }

        [DisplayName("Oluşturan")]
        public int CreatedBy { get; set; }

        [DisplayName("Güncellenme Tarihi")]
        public DateTime LastUpdateDate { get; set; }

        [DisplayName("Son Güncelleyen")]
        public int LastUpdateBy { get; set; }

        [DisplayName("Durum")]
        public Status Status { get; set; }
    }
}
