using alar.DAL.Classes.BaseObjects;
using alar.DAL.Classes.BranchClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace alar.DAL.Classes.DiscountClasses
{
    /// <summary>
    /// Şube ile indirimleri çoka çok bağlıyor
    /// </summary>
    public class DiscountBranch:BaseObject
    {
        public int DicountID { get; set; }
        public Discount Discount { get; set; }

        public int BranchID { get; set; }
        public Branch Branch { get; set; }
    }
}
