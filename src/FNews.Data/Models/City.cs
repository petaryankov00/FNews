using System.ComponentModel.DataAnnotations;

namespace FNews.Data.Models
{
    public class City
    {
        [Key]
        public int Id { get; init; }

        [Required]
        [StringLength(30)]
        public string Name { get; init; }

        public int CountryId { get; set; }

        public virtual Country Country { get; set; }

        public virtual ICollection<Team> Teams { get; set; }
    }
}