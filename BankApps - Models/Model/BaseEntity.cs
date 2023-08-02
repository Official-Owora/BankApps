using System.ComponentModel.DataAnnotations;

namespace BankApps___Models.Model
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime ModifiedAt { get; set; }
    }
}
