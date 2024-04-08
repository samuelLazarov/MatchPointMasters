
namespace MatchPointMasters.Attributes
{
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.AspNetCore.Mvc.Filters;
	using MatchPointMasters.Core.Contracts;
	using System.Security.Claims;
	using MatchPointMasters.Extensions;

	public class MustBeATournamentHost : ActionFilterAttribute
	{

		public override void OnActionExecuting(ActionExecutingContext context)
		{
			base.OnActionExecuting(context);
			ITournamentHostService? tournamentHostService = context.HttpContext.RequestServices.GetService<ITournamentHostService>();

			if (tournamentHostService == null)
			{
				context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
			}

			if (tournamentHostService != null && tournamentHostService.ExistsByIdAsync(context.HttpContext.User.Id()).Result == false)
			{
				context.Result = new StatusCodeResult(StatusCodes.Status401Unauthorized);
			}
		}
	}
}
