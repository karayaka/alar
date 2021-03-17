using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace alar.DAL.Enums
{
    public enum DiscountType:byte
    {
        [Display(Name = "İndirim")]
        Discount = 0,
        [Display(Name = "Fırsat")]
        Opportunity = 1
    }
}
