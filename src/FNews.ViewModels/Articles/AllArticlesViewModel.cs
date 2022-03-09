namespace FNews.ViewModels.Articles
{
    public class AllArticlesViewModel
    {
        public const int ArticlesPerPage = 4;

        public int? CurrentPage { get; set; }

        public int TotalArticles { get; set; }

        public List<ArticleDataViewModel> Articles { get; set; } = new List<ArticleDataViewModel>();
    }
}
