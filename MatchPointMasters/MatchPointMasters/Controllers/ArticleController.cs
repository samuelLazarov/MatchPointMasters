
namespace MatchPointMasters.Controllers
{
	using MatchPointMasters.Core.Contracts;
	using MatchPointMasters.Core.Models.Article;
	using MatchPointMasters.Extensions;
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
	using MatchPointMasters.Core.Extensions;
	using MatchPointMasters.Attributes;
    public class ArticleController : BaseController
    {

        private readonly IArticleService articleService;
        private readonly ITournamentHostService tournamentHostService;

        public ArticleController(IArticleService _articleService, ITournamentHostService _tournamentHostService)
        {
            articleService = _articleService;
            tournamentHostService = _tournamentHostService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All([FromQuery] AllArticlesQueryModel model)
        {
            var allArticles = await articleService.AllAsync(
                model.SearchTerm,
                model.Sorting,
                model.CurrentPage,
                model.ArticlesPerPage);

            model.TotalArticlesCount = allArticles.TotalArticlesCount;
            model.Articles = allArticles.Articles;
            
            return View(model);
        }

		[HttpGet]
		[AllowAnonymous]
		public async Task<IActionResult> Details(int id, string information)
		{
			if (!await articleService.ArticleExistsAsync(id))
			{
				return BadRequest();
			}

			var currentArticle = await articleService.DetailsAsync(id);

			if (information != currentArticle.GetArticleInformation())
			{
				return BadRequest();
			}

			return View(currentArticle);
		}

		[HttpGet]
		[MustBeATournamentHost]
		public async Task<IActionResult> Add()
		{
			if (await tournamentHostService.ExistsByIdAsync(User.Id()) == false)
			{
				return Unauthorized();
			}

			var articleForm = new ArticleAddViewModel();

			return View(articleForm);
		}

		[HttpPost]
		[MustBeATournamentHost]
		public async Task<IActionResult> Add(ArticleAddViewModel articleForm)
		{
			if (await tournamentHostService.ExistsByIdAsync(User.Id()) == false)
			{
				return Unauthorized();
			}
			if (!ModelState.IsValid)
			{
				return View(articleForm);
			}

			await articleService.AddAsync(articleForm);
			return RedirectToAction(nameof(All));
		}

		[HttpGet]
		[MustBeATournamentHost]
		public async Task<IActionResult> Edit(int id)
		{
			if (!await articleService.ArticleExistsAsync(id))
			{
				return BadRequest();
			}

			var articleForm = await articleService.EditGetAsync(id);
			return View(articleForm);
		}

		[HttpPost]
		[MustBeATournamentHost]
		public async Task<IActionResult> Edit(ArticleEditViewModel articleForm)
		{
			if (articleForm == null)
			{
				return BadRequest();
			}

			if (!ModelState.IsValid)
			{
				return View(articleForm);
			}

			int id = articleForm.Id;
			await articleService.EditPostAsync(articleForm);
			return RedirectToAction(nameof(Details), new { id, information = articleForm.GetArticleInformation() });
		}

		[HttpGet]
		[MustBeATournamentHost]
		public async Task<IActionResult> Delete(int id)
		{
			if (!await articleService.ArticleExistsAsync(id))
			{
				return BadRequest();
			}

			var searchedArticle = await articleService.DeleteAsync(id);

			return View(searchedArticle);
		}

		[HttpPost]
		[MustBeATournamentHost]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			if (!await articleService.ArticleExistsAsync(id))
			{
				return BadRequest();
			}

			await articleService.DeleteConfirmedAsync(id);

			return RedirectToAction(nameof(All));
		}

		[AllowAnonymous]
		[HttpGet]
		public async Task<IActionResult> AllComments(int id, [FromQuery] AllArticleCommentsQueryModel model)
		{
			var article = articleService.FindArticleByIdAsync(id).Result;
			var articleInfo = await articleService.DetailsAsync(id);

			var allArticleComments = await articleService.AllArticleCommentsAsync(
				id,
				article.Title,
				model.SearchTerm,
				model.Sorting,
				model.CurrentPage,
				model.CommentsPerPage);

			model.TotalArticleCommentsCount = allArticleComments.TotalArticleCommentsCount;
			model.ArticleComments = allArticleComments.ArticleComments;
			model.ArticleId = id;
			model.ArticleTitle = article.Title;
			model.ArticleInfo = articleInfo.GetArticleInformation();

			return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> AddComment(int id)
		{
			string userId = User.Id();

			var articleCommentForm = new ArticleCommentAddViewModel()
			{
				ArticleId = id,
				UserId = userId
			};

			return View(articleCommentForm);
		}

		[HttpPost]
		public async Task<IActionResult> AddComment(ArticleCommentAddViewModel articleCommentForm)
		{
			if (!ModelState.IsValid)
			{
				return View(articleCommentForm);
			}

			int newArticleComment = await articleService.AddArticleCommentAsync(articleCommentForm, articleCommentForm.UserId, articleCommentForm.ArticleId);

			return RedirectToAction(nameof(AllComments), new { id = articleCommentForm.ArticleId });
		}

		[HttpGet]
		public async Task<IActionResult> EditComment(int id)
		{
			var comment = await articleService.FindArticleCommentByIdAsync(id);

			if (comment == null)
			{
				return BadRequest();
			}
			if (User.Id() != comment.UserId)
			{
				return Unauthorized();
			}

			var commentForm = await articleService.EditArticleCommentGetAsync(id);
			return View(commentForm);
		}

		[HttpPost]
		public async Task<IActionResult> EditComment(ArticleCommentEditViewModel commentForm)
		{
			if (commentForm == null)
			{
				return BadRequest();
			}
			if (User.Id() != commentForm.UserId)
			{
				return Unauthorized();
			}
			if (!ModelState.IsValid)
			{
				return View(commentForm);
			}

			await articleService.EditArticleCommentPostAsync(commentForm);
			return RedirectToAction(nameof(AllComments), new { id = commentForm.ArticleId });
		}

		[HttpGet]
		public async Task<IActionResult> DeleteComment(int id)
		{
			var articleComment = await articleService.FindArticleCommentByIdAsync(id);

			if (articleComment == null)
			{
				return BadRequest();
			}
			if (articleComment.UserId != User.Id())
			{
				return Unauthorized();
			}

			var searchedArticleComment = await articleService.DeleteArticleCommentAsync(id);

			return View(searchedArticleComment);
		}

		[HttpPost]
		public async Task<IActionResult> DeleteCommentConfirmed(int commentId)
		{
			var bookReview = await articleService.FindArticleCommentByIdAsync(commentId);

			if (bookReview == null)
			{
				return BadRequest();
			}
			if (bookReview.UserId != User.Id())
			{
				return Unauthorized();
			}


			return RedirectToAction(nameof(AllComments), new { id = await articleService.DeleteArticleCommentConfirmedAsync(commentId) });
		}
	}

}

