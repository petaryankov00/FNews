using System.ComponentModel.DataAnnotations;

namespace FNews.Data.Models
{
    public class Country
    {
        [Key]
        public int Id { get; init; }

        [Required]
        [StringLength(30)]
        public string Name { get; init; }

        public virtual ICollection<League> Leagues { get; init; } = new HashSet<League>();

        public virtual ICollection<Player> Players { get; init; } = new HashSet<Player>();

        public virtual ICollection<City> Cities { get; init; } = new HashSet<City>();
    }
}