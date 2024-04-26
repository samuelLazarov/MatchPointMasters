namespace MatchPointMasters.Infrastructure.Data.Models.Article
{
    using MatchPointMasters.Infrastructure.Data.Models.Roles;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static MatchPointMasters.Infrastructure.Constants.DataConstants.ArticleConstants;

    [Comment("Articles can be created by Tournament Hosts and commented by Players")]
    public class Article
    {
        [Key]
        [Comment("The current Article's Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(ArticleContentMaxLength)]
        [Comment("The current Article's Title")]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(ArticleContentMaxLength)]
        [Comment("The current Article's Content")]
        public string Content { get; set; } = null!;

        [Required]
        [Comment("The date on which the current Article was posted")]
        public DateTime DatePublished { get; set; }

        [Required]
        [MaxLength(ArticleImageUrlMaxLength)]
        [Comment("The current Article's Image Url")]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Comment("The current Article's Views Count")]
        public int ViewsCount { get; set; }

        public ICollection<ArticleComment> ArticleComments { get; set; } = new List<ArticleComment>();
    }
}
