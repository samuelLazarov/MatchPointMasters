namespace MatchPointMasters.Core.Models.Article.ViewModels
{
    using MatchPointMasters.Core.Contracts;
    using System.ComponentModel.DataAnnotations;
    using static MatchPointMasters.Infrastructure.Constants.DataConstants;
    using static MatchPointMasters.Infrastructure.Constants.DataConstants.ArticleCommentConstants;

    public class ArticleCommentEditViewModel : IArticleModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(ArticleCommentTitleMaxLength,
            MinimumLength = ArticleCommentTitleMinLength,
            ErrorMessage = LengthErrorMessage)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(ArticleCommentDescriptionMaxLength,
            MinimumLength = ArticleCommentDescriptionMinLength,
            ErrorMessage = LengthErrorMessage)]
        public string Description { get; set; } = null!;

        [Required]
        public int ArticleId { get; set; }

        [Required]
        public string UserId { get; set; } = null!;
    }
}
