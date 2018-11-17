using System.ComponentModel.DataAnnotations;

namespace ecovon_backend.Entities
{
    public class User
    {
       
        public int UserId { get; set; }
        public int CustomerId { get; set; }
        public int UserRoleId { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "First Name cannot be longer than 256 characters.")]
        public string FirstName { get; set; }
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Last Name cannot be longer than 256 characters.")]
        public string LastName { get; set; }
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Middle Name cannot be longer than 256 characters.")]
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public string WorkPhone { get; set; }
        public string MobilePhone { get; set; }
        public string HomePhone { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Zip { get; set; }

        public virtual UserRole UserRoleDetails { get; set; }
        public virtual Customer CustomerDetails { get; set; }
    }
}
