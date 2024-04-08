using MatchPointMasters.Core.Contracts;

namespace MatchPointMasters.Core.Extensions
{
	public static class ArticleExtensions
	{
		public static string GetArticleInformation(this IArticleModel tournament)
		{
			return tournament.Title;
		}
	}
}
