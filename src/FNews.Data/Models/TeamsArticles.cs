namespace FNews.Data.Models
{
    public class TeamsArticles
    {
        public string TeamId { get; init; }

        public virtual Team Team { get; init; }

        public string ArticleId { get; init; }

        public virtual Article Article { get; init; }
    }
}