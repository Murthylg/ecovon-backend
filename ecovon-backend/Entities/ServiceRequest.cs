using ecovon_backend.Entities.Vendors;
using System;

namespace ecovon_backend.Entities
{
    public class ServiceRequest
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

        public virtual Customer custumerDetails { get; set; }
        public virtual ServiceType ServiceTypeDetails { get; set; } 
        //public virtual ServiceCategory ServiceCategoryDetails { get; set; }
        //public virtual User UserDetails { get; set; }
    }
}
