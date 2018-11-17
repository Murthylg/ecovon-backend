using System.Collections.Generic;
using ecovon_backend.Entities;

namespace ecovon_backend.Models
{
    public class ServReqDetails
    {
        public IEnumerable<ServiceRequest> ServiceRequests { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
        public IEnumerable<ServiceType> ServiceTypes { get; set; }
    }
    public class UpdateReqDetails
    {
        public ServiceRequestDetailModel serviceRequestDetailModel { get; set; }
        public IEnumerable<User> User { get; set; }
        public IEnumerable<ServiceRequest> serviceRequest { get; set; }
    }
}
