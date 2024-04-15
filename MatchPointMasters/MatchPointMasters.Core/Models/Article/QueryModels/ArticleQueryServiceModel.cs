namespace MatchPointMasters.Core.Models.Article.QueryModels
{
    public class ArticleQueryServiceModel
    {
        public int TotalArticlesCount { get; set; }
        public IEnumerable<ArticleServiceModel> Articles { get; set; } = new HashSet<ArticleServiceModel>();
    }
}
