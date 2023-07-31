using System.ComponentModel.DataAnnotations;

namespace BankApps___Models.Model
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
