using alar.DAL.Classes.BaseObjects;
using alar.DAL.Classes.UserClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace alar.DAL.Classes.DiscountClasses
{
    /// <summary>
    /// Ürün wep sitesine ziyaret
    /// </summary>
    public class DiscountWepView:BaseObject
    {
        public int DiscountID { get; set; }
        public Discount Discount { get; set; }

        public int UserClassID { get; set; }
        public UserClass UserClass { get; set; }
    }
}
