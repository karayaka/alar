using alar.DAL.Classes.BaseObjects;
using alar.DAL.Classes.CustomerClasses;
using alar.DAL.Classes.DiscountClasses;
using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace alar.DAL.Classes.BranchClasses
{
    /// <summary>
    /// Şube Tanımları
    /// </summary>
    public class Branch:BaseObject
    {
        [DisplayName("Tabela Adı")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} Doldurulması Zorunludur")]
        public string SingName { get; set; }

        [DisplayName("Resmi Ad")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} Doldurulması Zorunludur")]
        public string OfficalName { get; set; }

        [DisplayName("İl")]
        public string Province { get; set; }

        [DisplayName("İlçe")]
        public string District { get; set; }

        [DisplayName("Adres")]
        public string Adress { get; set; }

       
        [DisplayName("Vergi No")]
        public string TaxNo { get; set; }
      
        [DisplayName("Vergi No")]
        public string TaxOffice { get; set; }

        [DisplayName("Telefon")]
        [DataType(DataType.PhoneNumber, ErrorMessage = " Lütfen Geçerli Bir {0} Girin")]
        public string PhoneNumber { get; set; }

        [DisplayName("Enlem")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} Doldurulması Zorunludur")]
        public double Lat { get; set; }

        [DisplayName("Boylam")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} Doldurulması Zorunludur")]
        public double Long { get; set; }

        public Point Location { get; set; }

        public ICollection<BranchAuthorized> BranchAuthorizeds { get; set; }

        public int CustomerID { get; set; }
        public Customer Customer { get; set; }

        public ICollection<DiscountBranch> DiscountBranches { get; set; }
    }
}
