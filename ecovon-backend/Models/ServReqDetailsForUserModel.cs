using System;
using System.ComponentModel.DataAnnotations;

namespace ecovon_backend.Models
{
    public class ServReqDetailsForUserModel
    {
        //Service Request table.
        public int ServiceRequestId { get; set; }
        public int CustomerId { get; set; }
        public int ServiceTypeId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public int AssignedTo { get; set; }
        public int? AssignedBy { get; set; }
        public DateTime AssignedDate { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }

        //Service Request Details table.
        [Required]
        public int ServiceRequestDetailId { get; set; }               
        [Required]
        public string PreviousStatus { get; set; }
        [Required]
        public string CurrentStatus { get; set; }

        //User table details.             
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
    }
}
