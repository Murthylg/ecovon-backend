using System;
using System.ComponentModel.DataAnnotations;

namespace ecovon_backend.Models
{
    public class LoginModel
    {
        [Key]
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

        [Key]
        public int LoginId { get; set; }
        
        public string LoginName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
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
