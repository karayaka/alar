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
        public BaseObject()
        {
            CreatedDate = DateTime.Now;
            LastUpdateDate = DateTime.Now;
            Status = Status.Active;
            ObjectStatus = ObjectStatus.NonDeleted;
        }
        [Key]
        public int ID { get; set; }
          
        [DisplayName("Silindi Bilgisi")]
        public ObjectStatus ObjectStatus { get; set; }

        [Browsable(false)]
        [ScaffoldColumn(false)]
        //[ReadOnly(true)]
        [DisplayName("Oluşturulma Tarihi")]
        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; }

        [DisplayName("Oluşturan")]
        public int CreatedBy { get; set; }

        [DisplayName("Güncellenme Tarihi")]
        [DataType(DataType.DateTime)]
        public DateTime LastUpdateDate { get; set; }

        [DisplayName("Son Güncelleyen")]
        public int LastUpdateBy { get; set; }

        [DisplayName("Durum")]
        public Status Status { get; set; }
    }
}
