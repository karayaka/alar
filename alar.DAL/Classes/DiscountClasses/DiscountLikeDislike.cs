using alar.DAL.Classes.BaseObjects;
using alar.DAL.Classes.UserClasses;
using alar.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace alar.DAL.Classes.DiscountClasses
{
    /// <summary>
    /// begen begenme 
    /// </summary>
    public class DiscountLikeDislike:BaseObject
    {
        public int DiscountID { get; set; }
        public Discount Discount { get; set; }

        public int UserClassID { get; set; }
        public UserClass UserClass { get; set; }

        public LikeDislike LikeDislike { get; set; }
    }
}
