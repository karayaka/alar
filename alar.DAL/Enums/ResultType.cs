using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace alar.DAL.Enums
{
    public enum ResultType:byte
    {
        [Display(Name = "Başarılı")]
        succes = 2,
        [Display(Name = "Uyarı")]
        warning = 1,
        [Display(Name = "Hata")]
        danger = 0
    }
}
