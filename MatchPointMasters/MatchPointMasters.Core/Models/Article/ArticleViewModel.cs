using MatchPointMasters.Core.Contracts;

namespace MatchPointMasters.Core.Models.Article
{
    public class ArticleViewModel : IArticleModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Content { get; set; } = string.Empty;

        public DateTime DatePublished { get; set; }

        public string ImageUrl { get; set; } = string.Empty;

        public int ViewsCount { get; set; }
    }
}
