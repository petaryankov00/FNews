namespace FNews.Data.Models
{
    public class TeamsNews
    {
        public string TeamId { get; init; }

        public virtual Team Team { get; init; }

        public string NewsId { get; init; }

        public virtual News News { get; init; }
    }
}