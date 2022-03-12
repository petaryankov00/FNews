namespace FNews.Data.Models
{
    public class TeamsArticles
    {
        public string TeamId { get; set; }

        public virtual Team Team { get; set; }

        public string ArticleId { get; set; }

        public virtual Article Article { get; set; }
    }
}