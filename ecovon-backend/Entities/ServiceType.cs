namespace ecovon_backend.Entities
{
    public class ServiceType
    {
        public int ServiceTypeId { get; set; }
        public int ServiceCategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public  bool IsEnabled { get; set; }
    }
}
