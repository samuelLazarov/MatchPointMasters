namespace MatchPointMasters.Attributes
{
	using MatchPointMasters.Core.Contracts;
	using MatchPointMasters.Extensions;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.AspNetCore.Mvc.Filters;

	public class NotTournamentHostAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext context)
		{
			base.OnActionExecuting(context);
			ITournamentHostService? tournamentHostService = context.HttpContext.RequestServices.GetService<ITournamentHostService>();

			if (tournamentHostService == null)
			{
				context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
			}

			if (tournamentHostService != null && tournamentHostService.ExistsByIdAsync(context.HttpContext.User.Id()).Result)
			{
				context.Result = new StatusCodeResult(StatusCodes.Status400BadRequest);
			}
		}
	}
}
