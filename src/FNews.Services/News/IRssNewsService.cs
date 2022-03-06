using FNews.ViewModels.RssNews;

namespace FNews.Services.News
{
    public interface IRssNewsService
    {
        IEnumerable<MainNewsViewModel> GetMainNews();
    }
}
