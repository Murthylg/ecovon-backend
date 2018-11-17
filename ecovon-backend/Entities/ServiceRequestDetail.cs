using ecovon_backend.Entities.Vendors;
using System;
using System.ComponentModel.DataAnnotations;

namespace ecovon_backend.Entities
{
    public class ServiceRequestDetail
    {
        [Required]
        public int ServiceRequestDetailId { get; set; }
        [Required]
        public int ServiceRequestId { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public DateTime CreatedBy { get; set; }
        [Required]
        public string PreviousStatus { get; set; }
        [Required]
        public string CurrentStatus { get; set; }
        [Required]
        public int VendorId { get; set; }
        [Required]
        public string Notes { get; set; }

        public virtual Vendor VendorDetails { get; set; }
    }
}
