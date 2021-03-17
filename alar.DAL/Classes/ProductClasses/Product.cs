using alar.DAL.Classes.AlarClasses;
using alar.DAL.Classes.BaseObjects;
using alar.DAL.Classes.CustomerClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace alar.DAL.Classes.ProductClasses
{
    /// <summary>
    /// ürün
    /// </summary>
    public class Product:BaseObject
    {
        [DisplayName("Resimler")]
        public ICollection<ProductImage> ProductImages { get; set; }

        [DisplayName("Kategoriler")]
        public ICollection<ProductCategory> ProductCategories { get; set; }

        [DisplayName("Marka")]
        public int BrantID { get; set; }
        public Brant Brant { get; set; }

        [DisplayName("Model")]
        public int ProductModelID { get; set; }
        public ProductModel ProductModel { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} Doldurulması Zorunludur")]
        [DisplayName("Açıklama")]
        public string Desc { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} Doldurulması Zorunludur")]
        [DisplayName("Birim Tanımı")]
        public int UnitDefinationID { get; set; }
        public UnitDefination UnitDefination { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} Doldurulması Zorunludur")]
        [DisplayName("Birim Miktarı")]
        public decimal UnitQuantity { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} Doldurulması Zorunludur")]
        [DisplayName("Ürün Adı")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} Doldurulması Zorunludur")]
        [DisplayName("Ürün Adı")]
        public int ProductNameID { get; set; }
        public ProductName ProductName { get; set; }

        [DisplayName("Ürün Wep Sitesi")]
        public string WepUrl { get; set; }

        [DisplayName("Firma")]
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }
    }
}
