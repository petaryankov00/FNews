using FNews.ViewModels.RssNews;
using System.ServiceModel.Syndication;
using System.Xml;

namespace FNews.Services.News
{
    public class RssNewsService : IRssNewsService
    {
        public IEnumerable<MainNewsViewModel> GetMainNews()
        {
            var url = "https://gong.bg/rss";
            using var reader = XmlReader.Create(url);
            var feed = SyndicationFeed.Load(reader);

            var news = new List<MainNewsViewModel>();

            var posts = feed.Items;

            foreach (var post in posts)
            {
                var startIndex = post.Summary.Text.IndexOf("h");
                var endIndex = post.Summary.Text.IndexOf(".jpg");
                var imageUrl = post.Summary.Text.Substring(startIndex, endIndex - startIndex + 4);

                var desIndex = post.Summary.Text.IndexOf(">");

                var description = post.Summary.Text.Substring(desIndex+1);

                news.Add(new MainNewsViewModel
                {
                    Title = post.Title.Text,
                    Date = post.PublishDate.Date.ToShortDateString(),
                    Descrption = description,
                    ImageUrl = imageUrl,
                    Link = post.Id
                });
                
            }

            return news;

        }
    }
}
