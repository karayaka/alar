using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace alar.DAL.Enums
{
    public enum ObjectStatus : byte
    {
        [Display(Name = "Silindi")]
        Deleted = 1,
        [Display(Name = "Silinmedi")]
        NonDeleted = 0
    }
}
