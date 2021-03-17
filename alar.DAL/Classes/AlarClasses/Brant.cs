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
    /// sisteme ait tüm markalar 
    /// Marka havuzu
    /// </summary>
    public class Brant:BaseObject
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} Doldurulması Zorunludur")]
        [DisplayName("Marka")]
        public string Name { get; set; }

        public int CategoryID { get; set; }
        public Category Category { get; set; }

        public ICollection<Product> Products { get; set; }
        public ICollection<ProductModel> Models { get; set; }
    }
}
