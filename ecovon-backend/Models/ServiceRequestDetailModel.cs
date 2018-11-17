using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ecovon_backend.Entities;

namespace ecovon_backend.Models
{
    public class ServiceRequestDetailModel
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
        public string Status { get; set; }
        public DateTime AssignedDate { get; set; }

        public ServiceRequest serviceRequest { get; set; }
        public User user { get; set; }
    }
    public class ServiceReqAllUsrInfo
    {
        public IEnumerable<ServiceRequest> serviceRequests { get; set; }
        public IEnumerable<User> users { get; set; }
        public IEnumerable<ServiceRequestDetail> serviceRequestDetails { get; set; }
    }
}
