using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace alar.Presentation.Models.SecurityModels
{
    public class CustomerUserRegisterModel
    {
        public int ID { get; set; }

        [DisplayName("İsim")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} Doldurulması Zorunludur")]
        public string Name { get; set; }

        [DisplayName("Soy İsim")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} Doldurulması Zorunludur")]
        public string SurName { get; set; }

        [Remote(action: "VerifyUserName", controller: "Security", AdditionalFields = nameof(UserName))]
        [DisplayName("Kullanıcı Adı")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} Doldurulması Zorunludur")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [DisplayName("Şifre")]
        [StringLength(8, ErrorMessage = "{0} Uzunluğu {1} karakterde fazla olamalı" )]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} Doldurulması Zorunludur")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [DisplayName("Tekrar Şifre")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} Doldurulması Zorunludur")]       
        [Compare("Password",ErrorMessage ="Şifreler Uyuşmuyor")]        
        public string RePassword { get; set; }

        [DisplayName("Email")]
        [Remote(action: "VerifyEmail", controller: "Security", AdditionalFields = nameof(Email))]
        [DataType(DataType.EmailAddress, ErrorMessage = " Lütfen Geçerli Bir {0} Girin")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} Doldurulması Zorunludur")]
        public string Email { get; set; }


        [DisplayName("Telefon")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

    }
}
