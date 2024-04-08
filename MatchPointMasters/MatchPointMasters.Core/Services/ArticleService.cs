namespace MatchPointMasters.Core.Services
{
    using MatchPointMasters.Core.Contracts;
    using MatchPointMasters.Core.Enumerations;
    using MatchPointMasters.Core.Models.Article;
    using MatchPointMasters.Infrastructure.Data.Common;
    using MatchPointMasters.Infrastructure.Data.Models.Article;

    public class ArticleService : IArticleService
    {

        private readonly IRepository repository;


        public ArticleService(IRepository _repository)
        {
            repository = _repository;
        }

        public Task<int> AddArticleCommentAsync(ArticleCommentAddViewModel commentForm, string userId, int articleId)
        {
            throw new NotImplementedException();
        }

        public Task<int> AddAsync(ArticleAddViewModel articleForm)
        {
            throw new NotImplementedException();
        }

        public Task<ArticleCommentQueryServiceModel> AllArticleCommentsAsync(int articleId, string articleTitle, string? searchTerm = null, ArticleCommentSorting sorting = ArticleCommentSorting.Newest, int currentPage = 1, int articlesPerPage = 4)
        {
            throw new NotImplementedException();
        }

        public Task<ArticleQueryServiceModel> AllAsync(
            string? searchTerm = null,
            ArticleSorting sorting = ArticleSorting.Newest, 
            int currentPage = 1, int articlesPerPage = 4)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ArticleExistsAsync(int articleId)
        {
            throw new NotImplementedException();
        }

        public Task<ArticleCommentDeleteViewModel> DeleteArticleCommentAsync(int commentId)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteArticleCommentConfirmedAsync(int commentId)
        {
            throw new NotImplementedException();
        }

        public Task<ArticleDeleteViewModel> DeleteAsync(int articleId)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteConfirmedAsync(int articleId)
        {
            throw new NotImplementedException();
        }

        public Task<ArticleViewModel> DetailsAsync(int articleId)
        {
            throw new NotImplementedException();
        }

        public Task<ArticleCommentEditViewModel> EditArticleCommentGetAsync(int commentId)
        {
            throw new NotImplementedException();
        }

        public Task<int> EditArticleCommentPostAsync(ArticleCommentEditViewModel commentForm)
        {
            throw new NotImplementedException();
        }

        public Task<ArticleEditViewModel> EditGetAsync(int articleId)
        {
            throw new NotImplementedException();
        }

        public Task<int> EditPostAsync(ArticleEditViewModel articleForm)
        {
            throw new NotImplementedException();
        }

        public Task<Article> FindArticleByIdAsync(int articleId)
        {
            throw new NotImplementedException();
        }

        public Task<ArticleComment> FindArticleCommentByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
