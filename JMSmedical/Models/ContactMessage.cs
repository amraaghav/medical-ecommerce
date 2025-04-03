namespace JMSmedical.Models
{
    public class ContactMessage
    {
        public int Id { get; set; } // Primary Key
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime SubmittedDate { get; set; } = DateTime.UtcNow;
    }
}
