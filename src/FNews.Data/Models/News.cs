using System.ComponentModel.DataAnnotations;

namespace FNews.Data.Models
{
    public class News
    {
        [Key]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        [StringLength(100)]
        public string Header { get; set; }

        [Required]
        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public DateTime PublishedOn { get; set; }

        [Required]
        public string Author { get; set; }

        public virtual ICollection<TeamsNews> TeamsNews { get; init; } = new HashSet<TeamsNews>();


    }
}
