using FNews.Global;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FNews.Data.Models
{
    public class Article
    {
        [Key]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        [StringLength(GlobalConstants.ArticleHeaderMaxLength)]
        public string Header { get; set; }

        [Required]
        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public DateTime PublishedOn { get; set; }

        public string AuthorId { get; set; }

        [ForeignKey(nameof(AuthorId))]
        public IdentityUser Author { get; set; }

        public virtual ICollection<TeamsArticles> TeamsArticles { get; set; } = new HashSet<TeamsArticles>();


    }
}
