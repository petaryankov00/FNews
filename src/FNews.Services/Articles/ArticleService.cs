using FNews.Data.Common;
using FNews.Data.Models;
using FNews.ViewModels.Articles;
using Microsoft.AspNetCore.Identity;

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
            var team = repo.All<Team>()
                .Where(x => x.Name == model.Team)
                .FirstOrDefault();

            var author = repo.All<IdentityUser>()
                .FirstOrDefault(x => x.UserName == model.Author);

            var article = new Article
            {
                Author = author,
                Header = model.Header,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                PublishedOn = DateTime.UtcNow,
            };

            if (team != null)
            {
                article.TeamsArticles.Add(new TeamsArticles { Team = team, Article = article });
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

        public CreateArticleInputModel GetTeamNames()
        {
            var teams = repo.All<Team>()
                .Select(x => x.Name)
                .OrderBy(x=>x)
                .ToList();

            var result = new CreateArticleInputModel { Teams = teams };

            return result;
        }
    }
}
