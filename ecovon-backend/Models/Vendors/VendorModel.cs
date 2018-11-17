using ecovon_backend.Entities.Vendors;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ecovon_backend.Models.Vendors
{
    public class VendorModel
    {
        [Key]
        public int VendorId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public int TypeofWorkId { get; set; }
        public string CompanyName { get; set; }
        [Required]
        public string MobileNumber { get; set; }
        public string WorkNumber { get; set; }
        public bool IsEnabled { get; set; }
        public string Experience { get; set; }
        public string TeamSize { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string IdentityType { get; set; }
        public string IdentityNumber { get; set; }
    }
    public class VendorDetails
    {        
        public IEnumerable<Vendor> Vendors { get; set; }
    }
}
