namespace MatchPointMasters.Core.Models.Article.ViewModels
{
    public class ArticleCommentDeleteViewModel
    {
        public int ArticleId { get; set; }
        public string ArticleTitle { get; set; } = string.Empty;
        public int CommentId { get; set; }
    }
}
