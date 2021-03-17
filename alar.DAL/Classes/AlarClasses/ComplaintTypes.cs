using alar.DAL.Classes.BaseObjects;
using alar.DAL.Classes.DiscountClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace alar.DAL.Classes.AlarClasses
{
    /// <summary>
    /// Şikayet türleri
    /// Maerkaya veya indirime
    /// </summary>
    public class ComplaintTypes:BaseObject
    {
        [DisplayName("Tür Adı")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} Doldurulması Zorunludur")]
        public int Name { get; set; }

        public ICollection<DiscountComplaint> DiscountComplaints { get; set; }
    }
}
