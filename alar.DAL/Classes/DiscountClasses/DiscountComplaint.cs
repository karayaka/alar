using alar.DAL.Classes.AlarClasses;
using alar.DAL.Classes.BaseObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace alar.DAL.Classes.DiscountClasses
{
    /// <summary>
    /// indirime yapılan şikayetler
    /// </summary>
    public class DiscountComplaint:BaseObject
    {
        public int DiscountID { get; set; }
        public Discount Discount { get; set; }

        [DisplayName("Şikayet")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} Doldurulması Zorunludur")]
        public string Complaint { get; set; }

        public int ComplaintTypesID { get; set; }
        public ComplaintTypes ComplaintTypes { get; set; }

    }
}
