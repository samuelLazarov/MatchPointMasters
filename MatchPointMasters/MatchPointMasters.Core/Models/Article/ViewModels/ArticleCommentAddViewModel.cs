namespace MatchPointMasters.Core.Models.Article.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    using static MatchPointMasters.Infrastructure.Constants.DataConstants;
    using static MatchPointMasters.Infrastructure.Constants.DataConstants.ArticleCommentConstants;

    public class ArticleCommentAddViewModel
    {
        [Required]
        [StringLength(ArticleCommentTitleMaxLength,
            MinimumLength = ArticleCommentTitleMinLength,
            ErrorMessage = LengthErrorMessage)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(ArticleCommentDescriptionMaxLength,
            MinimumLength = ArticleCommentDescriptionMinLength,
            ErrorMessage = LengthErrorMessage)]
        public string Description { get; set; } = string.Empty;

        [Required]
        public int ArticleId { get; set; }

        [Required]
        public string UserId { get; set; } = string.Empty;
    }
}
