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
    /// sisteme ait categoriler 
    /// kategori havuzu
    /// </summary>
    public class Category:BaseObject
    {
        [DisplayName("Ad")]
        [DataType(DataType.PhoneNumber, ErrorMessage = " Lütfen Geçerli Bir {0} Girin")]
        public string Name { get; set; }

        public ICollection<Brant> Brants { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
