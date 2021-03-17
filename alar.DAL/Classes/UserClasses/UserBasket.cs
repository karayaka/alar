using alar.DAL.Classes.BaseObjects;
using alar.DAL.Classes.DiscountClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace alar.DAL.Classes.UserClasses
{
    public class UserBasket:BaseObject
    {
        public int UserClassID { get; set; }
        public UserClass UserClass { get; set; }

        public int DiscountID { get; set; }
        public Discount Discount { get; set; }
    }
}
