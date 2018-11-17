using System;

namespace ecovon_backend.Entities
{
    public class UserRole
    {
        public int UserRoleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Boolean IsEnabled { get; set; }
    }
}
