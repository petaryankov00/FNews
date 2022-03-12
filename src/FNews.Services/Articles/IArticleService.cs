using FNews.ViewModels.Articles;

namespace FNews.Services.Articles
{
    public interface IArticleService
    {
        AllArticlesViewModel GetAll(int currentPage);

        AllArticlesViewModel GetById(string id,int currentPage);

        ArticleDetailsViewModel GetDetails(string id);

        CreateArticleInputModel GetTeamNames();

        void Create(CreateArticleInputModel model);

        bool Edit(string id, CreateArticleInputModel model);

        CreateArticleInputModel GetForEdit(ArticleDetailsViewModel model);
    }
}
