using alar.DAL.Classes.BaseObjects;
using alar.DAL.Classes.ProductClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace alar.DAL.Classes.AlarClasses
{
    /// <summary>
    /// Model Havuzu 
    /// Sisteme ait bütün modeller
    /// </summary>
    public class ProductModel:BaseObject
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} Doldurulması Zorunludur")]
        [DisplayName("Model Adı")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} Doldurulması Zorunludur")]
        [DisplayName("Marka")]
        public int BrantID { get; set; }
        public Brant Brant { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
