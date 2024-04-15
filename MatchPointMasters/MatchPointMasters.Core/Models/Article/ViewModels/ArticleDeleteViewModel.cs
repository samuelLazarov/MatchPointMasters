using MatchPointMasters.Core.Contracts;

namespace MatchPointMasters.Core.Models.Article.ViewModels
{
    public class ArticleDeleteViewModel : IArticleModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public int ViewsCount { get; set; }
    }
}
