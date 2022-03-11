using FNews.ViewModels.Articles;

namespace FNews.Services.Articles
{
    public interface IArticleService
    {
        AllArticlesViewModel GetAll(int currentPage);

        AllArticlesViewModel GetById(string id,int currentPage);

        CreateArticleInputModel GetTeamNames();

        void Create(CreateArticleInputModel model);
    }
}
