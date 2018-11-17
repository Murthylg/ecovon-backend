using System.ComponentModel.DataAnnotations;

namespace ecovon_backend.Entities.Vendors
{
    public class VendorTypeOfWork
    {
        [Key]
        public int TypeofWorkId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsEnabled { get; set; }
    }
}
