namespace MatchPointMasters.Core.Models.Article.QueryModels
{
    using MatchPointMasters.Core.Contracts;
    using System.ComponentModel.DataAnnotations;
    using static MatchPointMasters.Infrastructure.Constants.DataConstants;
    using static MatchPointMasters.Infrastructure.Constants.DataConstants.ArticleConstants;
    public class ArticleServiceModel : IArticleModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(ArticleTitleMaxLength, MinimumLength = ArticleTitleMinLength, ErrorMessage = LengthErrorMessage)]
        public string Title { get; set; } = null!;

        [Required]
        [Range(ArticleViewsCountMinRange, uint.MaxValue, ErrorMessage = RangeErrorMessage)]
        public int ViewsCount { get; set; }

        [Required]
        public DateTime DatePublished { get; set; }

        [Required]
        [StringLength(ArticleImageUrlMaxLength, MinimumLength = ArticleImageUrlMinLength, ErrorMessage = LengthErrorMessage)]
        public string ImageUrl { get; set; } = null!;

    }
}