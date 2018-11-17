using ecovon_backend.Entities;
using System.Collections.Generic;

namespace ecovon_backend.Models
{
    public class CustomerDetailsModel
    {
        public IEnumerable<Customer> Customers { get; set; }
    }
}
