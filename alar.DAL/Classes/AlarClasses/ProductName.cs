using alar.DAL.Classes.BaseObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace alar.DAL.Classes.AlarClasses
{
    /// <summary>
    /// Ürün İsimlerini Tekilleştirme çabası
    /// Aynı İsimdeki ürünleri kolay tesbitetme
    /// </summary>
    public class ProductName:BaseObject
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} Doldurulması Zorunludur")]
        [DisplayName("Ürün Adı")]
        public string Name { get; set; }
    }
}
