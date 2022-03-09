using FNews.ViewModels.Articles;

namespace FNews.Services.Articles
{
    public interface IArticleService
    {
        AllArticlesViewModel GetAll(int currentPage);

        CreateArticleInputModel GetTeamNames();

        void CreateArticle(CreateArticleInputModel model);
    }
}
