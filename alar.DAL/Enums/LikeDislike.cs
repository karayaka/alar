using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace alar.DAL.Enums
{
    public enum LikeDislike:byte
    {
        [Display(Name = "Beğen")]
        like = 0,
        [Display(Name = "Beğenme")]
        Dislike = 1
    }
}
