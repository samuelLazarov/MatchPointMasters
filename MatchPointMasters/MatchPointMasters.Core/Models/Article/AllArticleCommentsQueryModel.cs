﻿using MatchPointMasters.Core.Enumerations;
using System.ComponentModel.DataAnnotations;

namespace MatchPointMasters.Core.Models.Article
{
    public class AllArticleCommentsQueryModel
    {
        public int ArticleId { get; set; }
        public string ArticleInfo { get; set; } = null!;
        public string ArticleTitle { get; set; } = null!;
        public int CommentsPerPage { get; } = 8;

        [Display(Name = "Търсене")]
        public string SearchTerm { get; set; } = null!;

        [Display(Name = "Сортиране")]
        public ArticleCommentSorting Sorting { get; set; }

        public int TotalArticleCommentsCount { get; set; }
        public int CurrentPage { get; set; } = 1;
        public IEnumerable<ArticleCommentServiceModel> ArticleComments { get; set; } = new HashSet<ArticleCommentServiceModel>();
    }
}
