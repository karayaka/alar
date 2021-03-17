using alar.DAL.Classes.BaseObjects;
using alar.DAL.Classes.UserClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace alar.DAL.Classes.DiscountClasses
{
    /// <summary>
    /// İndirim altına gelen yorumlar
    /// </summary>
    public class DicountComment:BaseObject
    {
        public int DicountID { get; set; }
        public Discount Discount { get; set; }

        public int UserClassID { get; set; }
        public UserClass UserClass { get; set; }

        [DisplayName("Yorum")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} Doldurulması Zorunludur")]
        public string Comment { get; set; }

    }
}
