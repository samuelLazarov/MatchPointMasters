namespace MatchPointMasters.Core.Models.Article.ViewModels
{
    using MatchPointMasters.Core.Contracts;
    using System.ComponentModel.DataAnnotations;
    using static MatchPointMasters.Infrastructure.Constants.DataConstants;
    using static MatchPointMasters.Infrastructure.Constants.DataConstants.ArticleConstants;

    public class ArticleEditViewModel : IArticleModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(ArticleTitleMaxLength,
            MinimumLength = ArticleTitleMinLength,
            ErrorMessage = LengthErrorMessage)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(ArticleContentMaxLength,
            MinimumLength = ArticleContentMinLength,
            ErrorMessage = LengthErrorMessage)]
        public string Content { get; set; } = null!;

        [Required]
        [StringLength(ArticleImageUrlMaxLength,
            MinimumLength = ArticleImageUrlMinLength,
            ErrorMessage = LengthErrorMessage)]
        public string ImageUrl { get; set; } = null!;
    }
}
