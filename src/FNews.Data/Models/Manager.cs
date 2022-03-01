using System.ComponentModel.DataAnnotations;

namespace FNews.Data.Models
{
    public class Manager
    {
        [Key]
        public int Id { get; init; }

        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20)]
        public string LastName { get; set; }

        public string TeamId { get; set; }

        public virtual Team Team { get; set; }
    }
}
