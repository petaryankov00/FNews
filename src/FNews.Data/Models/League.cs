using FNews.Global;
using System.ComponentModel.DataAnnotations;

namespace FNews.Data.Models
{
    public class League
    {
        [Key]
        public int Id { get; init; }

        [Required]
        [StringLength(GlobalConstants.LeagueNameMaxLength)]
        public string Name { get; set; }

        public int CountryId { get; set; }

        public virtual Country Country { get; set; }

        public ICollection<Team> Teams { get; init; } = new HashSet<Team>();
    }
}