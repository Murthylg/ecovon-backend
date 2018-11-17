using System;
using System.ComponentModel.DataAnnotations;

namespace ecovon_backend.Models
{
    public class ServiceReqModel
    {        
        public int ServiceRequestId { get; set; }
        public int CustomerId { get; set; }
        public int ServiceTypeId { get; set; }        
        public DateTime CreatedDate { get; set; }        
        public int CreatedBy { get; set; }
        public int? AssignedTo { get; set; }
        public int? AssignedBy { get; set; }        
        public DateTime AssignedDate { get; set; }        
        public string Status { get; set; }
        public string Notes { get; set; }
    }
}
