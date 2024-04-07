using MatchPointMasters.Core.Enumerations;
using System.ComponentModel.DataAnnotations;

namespace MatchPointMasters.Core.Models.Article
{
    public class AllArticlesQueryModel
    {
        public int ArticlesPerPage { get; } = 8;

        [Display(Name = "Търсене")]
        public string SearchTerm { get; set; } = null!;

        [Display(Name = "Сортиране")]
        public ArticleSorting Sorting { get; set; }

        public int TotalArticlesCount { get; set; }
        public int CurrentPage { get; set; } = 1;
        public IEnumerable<ArticleServiceModel> Articles { get; set; } = new HashSet<ArticleServiceModel>();
    }
}
