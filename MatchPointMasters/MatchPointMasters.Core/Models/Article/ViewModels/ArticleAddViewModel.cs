namespace MatchPointMasters.Core.Models.Article.ViewModels
{
    using MatchPointMasters.Core.Contracts;
    using System.ComponentModel.DataAnnotations;
    using static MatchPointMasters.Infrastructure.Constants.DataConstants;
    using static MatchPointMasters.Infrastructure.Constants.DataConstants.ArticleConstants;

    public class ArticleAddViewModel : IArticleModel
    {
        [Required]
        [StringLength(ArticleTitleMaxLength,
            MinimumLength = ArticleTitleMinLength,
            ErrorMessage = LengthErrorMessage)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(ArticleContentMaxLength,
            MinimumLength = ArticleContentMinLength,
            ErrorMessage = LengthErrorMessage)]
        public string Content { get; set; } = string.Empty;

        [Required]
        [StringLength(ArticleImageUrlMaxLength,
            MinimumLength = ArticleImageUrlMinLength,
            ErrorMessage = LengthErrorMessage)]
        public string ImageUrl = string.Empty;


    }
}
