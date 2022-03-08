using FNews.Data.Common;
using FNews.Data.Models;
using FNews.ViewModels.Articles;

namespace FNews.Services.Articles
{
    public class ArticleService : IArticleService
    {
        private readonly IRepository repo;

        public ArticleService(IRepository repo)
        {
            this.repo = repo;
        }

        public void CreateArticle(CreateArticleInputModel model)
        {
            var teams = repo.All<Team>()
                .Where(x => x.Name.Contains(model.Team))
                .ToList();

            var article = new Article
            {
                AuthorId = model.AuthorId,
                Header = model.Header,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                PublishedOn = DateTime.UtcNow,
            };

            if(teams != null)
            {
                foreach (var team in teams)
                {
                    article.TeamsArticles.Add(new TeamsArticles { Team = team, Article = article });
                }
            }

            repo.Add(article);
            repo.SaveChanges();
        }

        public IEnumerable<AllArticlesViewModel> GetAll()
        {
            var articles = repo.All<Article>()
                .Select(x => new AllArticlesViewModel
                {
                    Header = x.Header,
                    Id = x.Id,
                    ImageUrl = x.ImageUrl,
                    TeamName = x.TeamsArticles.FirstOrDefault().Team.Name
                })
                .ToList();

            return articles;
        }
    }
}
