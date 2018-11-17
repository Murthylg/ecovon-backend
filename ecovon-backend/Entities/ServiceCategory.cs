namespace ecovon_backend.Entities
{
    public class ServiceCategory
    {
        public int ServiceCategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string IsEnabled { get; set; }
        public string Notes { get; set; }
        public string Inclusions { get; set; }
        public string Exclusions { get; set; }      
    }
}
