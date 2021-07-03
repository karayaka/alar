using alar.DAL.Classes.BaseObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace alar.DAL.Classes.ProductClasses
{
    /// <summary>
    /// Ürün Resimleri
    /// ürünün Farklı Boyutta resimleri
    /// </summary>
    public class ProductImage:BaseObject
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} Doldurulması Zorunludur")]
        [DisplayName("Ürün")]
        public int ProductID { get; set; }
        public Product Product { get; set; }

        [DisplayName("Resim Min")]
        public string ProductImageMin { get; set; }

        [DisplayName("Resim Large")]
        public string ProductImageLarge { get; set; }

        [DisplayName("Resim Orjinal")]
        public string ProductImageOrjin { get; set; }

        [DisplayName("Firma Logo Orta")]
        public string ProductImageMedium { get; set; }

        [DisplayName("Kapak Resmi")]
        public bool CoverImage { get; set; }
    }
}
