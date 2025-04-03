namespace JMSmedical.Models
{
    public class Service
    {
        public int Id { get; set; }  // Primary Key
        public string Title { get; set; } = string.Empty;  // Prevent null issues
        public string Description { get; set; } = string.Empty;
        public string IconClass { get; set; } = string.Empty;
    }
}
