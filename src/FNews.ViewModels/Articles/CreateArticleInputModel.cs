using FNews.Global;
using System.ComponentModel.DataAnnotations;

namespace FNews.ViewModels.Articles
{
    public class CreateArticleInputModel
    {
        [Required]
        [StringLength(GlobalConstants.ArticleHeaderMaxLength,
            MinimumLength = GlobalConstants.ArticleHeaderMinLength, 
            ErrorMessage = "{0} must be between {2} and {1}")]
        public string Header { get; set; }

        [Required]
        [MinLength(GlobalConstants.ArticleDescriptionMinLength,
            ErrorMessage = "{0} must be at least {1} characters long")]
        public string Description { get; set; }

        [Required]
        public string AuthorId { get; init; }

        [Required]
        public string Team { get; set; }

        public List<string> Teams { get; set; }

        [Required]
        [Url]
        public string ImageUrl { get; set; }

    }
}
