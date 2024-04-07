namespace MatchPointMasters.Core.Models.Article
{
    public class ArticleCommentDeleteViewModel
    {
        public int ArticleId { get; set; }
        public string ArticleTitle { get; set; } = string.Empty;
        public int CommentId { get; set; }
    }
}
