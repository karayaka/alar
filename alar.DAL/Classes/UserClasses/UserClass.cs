using alar.DAL.Classes.BaseObjects;
using alar.DAL.Classes.BranchClasses;
using alar.DAL.Classes.CustomerClasses;
using alar.DAL.Classes.DiscountClasses;
using alar.DAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace alar.DAL.Classes.UserClasses
{
    public class UserClass:BaseObject
    {
        [DisplayName("İsim")]
        public string Name { get; set; }

        [DisplayName("Soy İsim")]
        public string SurName { get; set; }

        [DisplayName("Kullanıcı Adı")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} Doldurulması Zorunludur")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [DisplayName("Şifre")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} Doldurulması Zorunludur")]
        public string Password { get; set; }

        [DisplayName("Email")]
        [DataType(DataType.EmailAddress,ErrorMessage = " Lütfen Geçerli Bir {0} Girin")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} Doldurulması Zorunludur")]
        public string Email { get; set; }

        public string EmailToken { get; set; }

        public bool EmailConfirme { get; set; }

        [DisplayName("Telefon")]      
        public string PhoneNumber { get; set; }

        public string PhoneToken { get; set; }

        public bool PhoneConfirme { get; set; }

        [DisplayName("Kullanıcı Türü")]
        public UserTypes UserTypes { get; set; }

        public string UserImageMin { get; set; }

        public string UserImageLarge { get; set; }

        public string CustomerImageMedium { get; set; }

        public string UserImageOrjin { get; set; }

        [DisplayName("Firma")]
        public int? CustomerID { get; set; }
        public Customer Customer { get; set; }

        public ICollection<BranchAuthorized> BranchAuthorizeds { get; set; }

        public ICollection<DiscountLikeDislike> DiscountLikeDislikes { get; set; }

        public ICollection<DicountComment> DicountComments { get; set; }

        public ICollection<DiscountView> DiscountViews { get; set; }

        public ICollection<DiscountWepView> DiscountWepViews { get; set; }

        public ICollection<CustomerFallow> CustomerFallows { get; set; }

        public ICollection<UserBasket> UserBaskets { get; set; }
    }
}
