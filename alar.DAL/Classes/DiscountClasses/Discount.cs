using alar.DAL.Classes.BaseObjects;
using alar.DAL.Classes.CustomerClasses;
using alar.DAL.Classes.ProductClasses;
using alar.DAL.Classes.UserClasses;
using alar.DAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace alar.DAL.Classes.DiscountClasses
{
    /// <summary>
    /// İndirim Kayıtları
    /// 
    /// </summary>
    public class Discount:BaseObject
    {
        [DisplayName("Resmi Ad")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} Doldurulması Zorunludur")]
        public int ProductID { get; set; }
        public Product Product { get; set; }

        [DisplayName("Resmi Ad")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} Doldurulması Zorunludur")]
        public DiscountType DiscountType { get; set; }

        [DisplayName("Resmi Ad")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} Doldurulması Zorunludur")]
        public decimal OldPrice { get; set; }

        [DisplayName("Resmi Ad")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} Doldurulması Zorunludur")]
        public decimal NewPrice { get; set; }

        [DisplayName("Stoklarla Sınırlı")]
        public bool LimitedByStocks { get; set; }

        [DisplayName("Resmi Ad")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} Doldurulması Zorunludur")]
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }

        public ICollection<DicountComment> DicountComments { get; set; }

        public ICollection<DiscountComplaint> DiscountComplaints { get; set; }

        public ICollection<DiscountLikeDislike> DiscountLikeDislikes { get; set; }

        public ICollection<DiscountWepView> DiscountWepViews { get; set; }

        public ICollection<UserBasket> UserBaskets { get; set; }

    }
}
