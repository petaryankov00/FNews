using FNews.Data.Common;
using FNews.Data.Models;
using FNews.ViewModels.Articles;
using System.Globalization;

namespace FNews.Services.Articles
{
    public class ArticleService : IArticleService
    {
        private readonly IRepository repo;

        public ArticleService(IRepository repo)
        {
            this.repo = repo;
        }

        public void Create(CreateArticleInputModel model)
        {
            var team = repo.All<Team>()
                .Where(x => x.Name == model.Team)
                .FirstOrDefault();

            var article = new Article
            {
                AuthorId = model.AuthorId,
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

        public AllArticlesViewModel GetAll(int currentPage)
        {
            var articleQuery = repo.All<Article>();
    
            return GetArticles(articleQuery,currentPage);
        }

        public AllArticlesViewModel GetById(string id, int currentPage)
        {
            var articleQuery = repo.All<Article>()
                .Where(x => x.AuthorId == id);

            return GetArticles(articleQuery, currentPage);
        }

        public CreateArticleInputModel GetTeamNames()
        {
            var teams = repo.All<Team>()
                .Select(x => x.Name)
                .OrderBy(x => x)
                .ToList();

            var result = new CreateArticleInputModel { Teams = teams };

            return result;
        }

        private static AllArticlesViewModel GetArticles(IQueryable<Article> articleQuery,int currentPage)
        {
            var totalArticles = articleQuery.Count();

            var result = new AllArticlesViewModel { CurrentPage = currentPage, TotalArticles = totalArticles };

            var articles = articleQuery
                 .Select(x => new ArticleDataViewModel
                 {
                     Header = x.Header,
                     Id = x.Id,
                     ImageUrl = x.ImageUrl,
                     TeamName = x.TeamsArticles.FirstOrDefault().Team.Name,
                 })
                 .Skip((currentPage - 1) * AllArticlesViewModel.ArticlesPerPage)
                 .Take(AllArticlesViewModel.ArticlesPerPage)
                 .ToList();

            result.Articles.AddRange(articles);


            return result;
        }

        public ArticleDetailsViewModel GetDetails(string id)
        {
            var article = repo.All<Article>()
                .Where(x => x.Id == id)
                .Select(x => new ArticleDetailsViewModel
                {
                    Header = x.Header,
                    Description = x.Description,
                    PublishedOn = x.PublishedOn.ToString("G", CultureInfo.InvariantCulture),
                    Id = x.Id,
                    ImageUrl = x.ImageUrl,
                    AuthorName = x.Author.UserName,
                    AuthorId = x.AuthorId
                })
                .FirstOrDefault();

            return article;
        }
    }
}
