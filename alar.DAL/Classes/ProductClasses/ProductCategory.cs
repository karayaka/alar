using alar.DAL.Classes.AlarClasses;
using alar.DAL.Classes.BaseObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace alar.DAL.Classes.ProductClasses
{
    /// <summary>
    /// Ürün ve kategoriyi birbirine bağlıyor bir ürünün birden fazla kategorisi olabilir
    /// </summary>
    public class ProductCategory:BaseObject
    {
        public int ProductID { get; set; }
        public Product Product { get; set; }

        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
