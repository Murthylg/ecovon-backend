using System.ComponentModel.DataAnnotations;

namespace ecovon_backend.Entities
{
    public class Customer
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]        
        public string Email { get; set; }

        [Required,MaxLength(50)]
        public string PrimaryPhone { get; set; }

        [MaxLength(50)]
        public string AlternatePhone { get; set; }

        [Required, MaxLength(50)]
        public string Address1 { get; set; }

        [MaxLength(50)]
        public string Address2 { get; set; }

        [MaxLength(50)]
        public string Address3 { get; set; }

        [Required, MaxLength(50)]
        public string City { get; set; }

        [Required, MaxLength(50)]
        public string State { get; set; }

        [MaxLength(50)]
        public string Country { get; set; }

        [MaxLength(10)]
        public string Zip { get; set; }

        [Key]
        public int CustomerId { get; set; }
    }
}
