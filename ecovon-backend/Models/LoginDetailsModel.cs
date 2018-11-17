using ecovon_backend.Entities;
using System.Collections.Generic;

namespace ecovon_backend.Models
{
    public class RegUsrDetails 
    {
        public IEnumerable<Login> logins { get; set; }
        public IEnumerable<User> users { get; set; }        
    }

    public class UpdateSingleUsrDetails
    {
        public Login login { get; set; }
        public User user { get; set; }        
    }
}
