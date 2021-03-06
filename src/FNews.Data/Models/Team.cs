using FNews.Global;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace FNews.Data.Models
{
    public class Team
    {
        [Key]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        [StringLength(GlobalConstants.TeamNameMaxLength)]
        public string Name { get; set; }

        public string LogoUrl { get; set; }

        [StringLength(GlobalConstants.TeamStadiumMaxLength)]
        public string Stadium { get; set; }

        public DateTime? Year { get; init; }

        public int? CityId { get; set; }

        public virtual City City  { get; set; }

        public int LeagueId { get; set; }

        public virtual League League { get; set; }

        public int? ManagaerId { get; set; }

        public virtual Manager Manager { get; set; }

        public virtual ICollection<Player> Players { get; init; } = new HashSet<Player>();

        public virtual ICollection<IdentityUser> Users { get; init; } = new HashSet<IdentityUser>();

        public virtual ICollection<TeamsArticles> TeamsArticles { get; init; } = new HashSet<TeamsArticles>();
    }
}
