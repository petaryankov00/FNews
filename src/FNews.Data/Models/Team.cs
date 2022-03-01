using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace FNews.Data.Models
{
    public class Team
    {
        [Key]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        public string LogoUrl { get; set; }

        [Required]
        [StringLength(30)]
        public string Stadium { get; set; }

        public DateTime Year { get; init; }

        public int CityId { get; set; }

        public virtual City City  { get; set; }

        public int LeagueId { get; set; }

        public virtual League League { get; set; }

        public virtual ICollection<Player> Players { get; init; } = new HashSet<Player>();

        public virtual ICollection<IdentityUser> Users { get; init; } = new HashSet<IdentityUser>();

        public virtual ICollection<TeamsNews> TeamsNews { get; init; } = new HashSet<TeamsNews>();
    }
}
