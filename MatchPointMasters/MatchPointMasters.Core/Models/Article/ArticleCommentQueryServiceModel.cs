namespace MatchPointMasters.Core.Models.Article
{
    public class ArticleCommentQueryServiceModel
    {
        public int TotalArticleCommentsCount { get; set; }
        public IEnumerable<ArticleCommentServiceModel> ArticleComments { get; set; } = new HashSet<ArticleCommentServiceModel>();
    }
}
