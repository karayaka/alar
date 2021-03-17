using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace alar.DAL.Enums
{
    public enum UserTypes:byte
    {
        [Display(Name = "Süper admin")]
        SuperAdmin = 0,

        [Display(Name = "Admin")]
        Admin = 1,

        [Display(Name = "Firma Kullanıcısı")]
        CompanyUser = 2,

        [Display(Name = "Standart Kullanıcısı")]
        StandartUser = 3,
    }
}
