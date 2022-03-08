using FNews.ViewModels.Articles;

namespace FNews.Services.Articles
{
    public interface IArticleService
    {
        IEnumerable<AllArticlesViewModel> GetAll();

        CreateArticleInputModel GetTeamNames();

        void CreateArticle(CreateArticleInputModel model);
    }
}
