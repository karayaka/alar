using alar.DAL.Classes.BaseObjects;
using alar.DAL.Classes.BranchClasses;
using alar.DAL.Classes.DiscountClasses;
using alar.DAL.Classes.ProductClasses;
using alar.DAL.Classes.UserClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace alar.DAL.Classes.CustomerClasses
{
    /// <summary>
    /// Firma Bilgileri
    /// </summary>
    public class Customer:BaseObject
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} Doldurulması Zorunludur")]
        [DisplayName("Resmi Adı")]
        public string CustomerOfficalName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} Doldurulması Zorunludur")]
        [DisplayName("Tabela Adı")]
        public string CustomerSingName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} Doldurulması Zorunludur")]
        [DisplayName("Vergi No")]
        public string TaxNo { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} Doldurulması Zorunludur")]
        [DisplayName("Vergi No")]
        public string TaxOffice { get; set; }

        [DisplayName("Firma Email")]
        [DataType(DataType.EmailAddress, ErrorMessage = " Lütfen Geçerli Bir {0} Girin")]
        public string Email { get; set; }

        [DisplayName("Firma Telefon")]
        [DataType(DataType.PhoneNumber, ErrorMessage = " Lütfen Geçerli Bir {0} Girin")]
        public string PhoneNumber { get; set; }

        [DisplayName("Firma Logo Min")]
        public string CustomerImageMin { get; set; }

        [DisplayName("Firma Logo Orta")]
        public string CustomerImageMedium { get; set; }

        [DisplayName("Firma Logo Large")]
        public string CustomerImageLarge { get; set; }

        [DisplayName("Firma Logo")]
        public string CustomerImageOrgin { get; set; }

        public ICollection<UserClass> Users { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<Branch> Branches { get; set; }
        public ICollection<CustomerFallow> CustomerFallows { get; set; }
        public ICollection<Discount> Discounts { get; set; }


    }
}
