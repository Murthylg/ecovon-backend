using System;
using System.ComponentModel.DataAnnotations;

namespace ecovon_backend.Entities
{
    public class Login
    {
        
        public int LoginId { get; set; }
        public int UserId { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
        [DataType(DataType.Date)]
        public DateTime? CreatedDate { get; set; }
        public int CreatedBy { get; set; }

        //Its not in datetime property.
        public string ModifiedDate { get; set; }
        
        public int ModifiedBy { get; set; }
        //Date
        public DateTime LastSuccessfulLoginDate { get; set; }
    }
}
