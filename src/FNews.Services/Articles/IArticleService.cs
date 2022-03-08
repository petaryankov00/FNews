using FNews.ViewModels.Articles;

namespace FNews.Services.Articles
{
    public interface IArticleService
    {
        IEnumerable<AllArticlesViewModel> GetAll();

        void CreateArticle(CreateArticleInputModel model);
    }
}
