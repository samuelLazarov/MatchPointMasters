namespace MatchPointMasters.Core.Extensions
{
	using MatchPointMasters.Core.Contracts;

	public static class ArticleExtensions
	{
		public static string GetInformation(this IArticleModel article)
		{
			return article.Title.Replace(" ", "-");
		}
	}
}
