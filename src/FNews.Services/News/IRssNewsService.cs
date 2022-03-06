using FNews.ViewModels.News;

namespace FNews.Services.News
{
    public interface IRssNewsService
    {
        IEnumerable<MainNewsViewModel> GetMainNews();
    }
}
