using alar.DAL.Classes.BaseObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace alar.DAL.Classes.AlarClasses
{
    /// <summary>
    /// Ürün Ölçü birimleri
    /// </summary>
    public class UnitDefination:BaseObject
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} Doldurulması Zorunludur")]
        [DisplayName("Birim Adı")]
        public string Name { get; set; }
    }
}
