﻿
namespace MatchPointMasters.Infrastructure.Data.Models.Article
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    using static MatchPointMasters.Infrastructure.Constants.DataConstants.ArticleCommentConstants;
    using MatchPointMasters.Infrastructure.Data.Models.Roles;

    [Comment("Articles can be created by Tournament Hosts and commented by Players")]
    public class ArticleComment
    {
        [Key]
        [Comment("The current Article Comment's Identifier")]
        public int Id { get; set; }

        [MaxLength(ArticleCommentTitleMaxLength)]
        [Comment("The current Article Comment's Title")]
        public string Title { get; set; } = null!;

        [MaxLength(ArticleCommentDescriptionMaxLength)]
        [Comment("The current Article Comment's Description")]
        public string Description { get; set; } = null!;

        [Required]
        [Comment("The current Article's Identifier")]
        public int ArticleId { get; set; }

        [ForeignKey(nameof(ArticleId))]
        [Comment("The current Article")]
        public Article Article { get; set; } = null!;

        [Required]
        [Comment("The current User's Identifier")]
        public string UserId { get; set; } = null!;

        [ForeignKey(nameof(UserId))]
        [Comment("The current User")]
        public ApplicationUser User { get; set; } = null!;
    }
}
