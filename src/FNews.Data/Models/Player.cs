using FNews.Global;
using System.ComponentModel.DataAnnotations;

namespace FNews.Data.Models
{
    public class Player
    {
        [Key]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        [StringLength(GlobalConstants.PlayerFirstNameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(GlobalConstants.PlayerLastNameMaxLength)]
        public string LastName { get; set; }

        [Required]
        [StringLength(GlobalConstants.PlayerLPositionMaxLength)]
        public string Position { get; set; }

        public DateTime? BirthDate { get; init; }

        public string PhotoUrl { get; set; }

        public string TeamId { get; set; }

        public virtual Team Team { get; set; }

        public int CountryId { get; set; }

        public virtual Country Country { get; set; }
    }
}