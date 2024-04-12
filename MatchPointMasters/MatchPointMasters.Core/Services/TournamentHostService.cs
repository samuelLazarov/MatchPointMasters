namespace MatchPointMasters.Core.Services
{
    using MatchPointMasters.Core.Contracts;
    using MatchPointMasters.Core.Models.Article;
    using MatchPointMasters.Core.Models.Match;
    using MatchPointMasters.Core.Models.Set;
    using MatchPointMasters.Core.Models.Tiebreak;
    using MatchPointMasters.Core.Models.Tournament;
    using MatchPointMasters.Infrastructure.Data.Common;
    using MatchPointMasters.Infrastructure.Data.Models.Mappings;
    using MatchPointMasters.Infrastructure.Data.Models.Roles;
    using Microsoft.EntityFrameworkCore;

    public class TournamentHostService : ITournamentHostService
    {
        public readonly IRepository repository;

        public TournamentHostService(IRepository _repository)
        {
            repository = _repository;
        }

        public Task<int> AddArticleAsync(ArticleAddViewModel articleForm)
        {
            throw new NotImplementedException();
        }

        public Task<int> AddMatchAsync(MatchAddViewModel matchForm)
        {
            throw new NotImplementedException();
        }

        public Task<TournamentMatch> AddMatchToTournamentAsync(int matchId, int tournamentId)
        {
            throw new NotImplementedException();
        }

        public Task<int> AddSetAsync(SetAddViewModel setForm)
        {
            throw new NotImplementedException();
        }

        public Task<int> AddTiebreakAsync(TiebreakAddViewModel tiebreakForm)
        {
            throw new NotImplementedException();
        }

        public Task<int> AddTournamentAsync(TournamentAddViewModel tournamentForm)
        {
            throw new NotImplementedException();
        }

        public Task<ArticleDeleteViewModel> DeleteArticleAsync(int articleId)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteArticleConfirmedAsync(int articleId)
        {
            throw new NotImplementedException();
        }

        public Task<MatchDeleteViewModel> DeleteMatchAsync(int matchId)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteMatchConfirmedAsync(int matchId)
        {
            throw new NotImplementedException();
        }

        public Task<SetDeleteViewModel> DeleteSetAsync(int setId)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteSetConfirmedAsync(int setId)
        {
            throw new NotImplementedException();
        }

        public Task<TiebreakDeleteViewModel> DeleteTiebreakAsync(int tiebreakId)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteTiebreakConfirmedAsync(int tiebreakId)
        {
            throw new NotImplementedException();
        }

        public Task<TournamentDeleteViewModel> DeleteTournamentAsync(int tournamentId)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteTournamentConfirmedAsync(int tournamentId)
        {
            throw new NotImplementedException();
        }

        public Task<ArticleEditViewModel> EditArticleGetAsync(int articleId)
        {
            throw new NotImplementedException();
        }

        public Task<int> EditArticlePostAsync(ArticleEditViewModel articleForm)
        {
            throw new NotImplementedException();
        }

        public Task<MatchEditViewModel> EditMatchGetAsync(int matchId)
        {
            throw new NotImplementedException();
        }

        public Task<int> EditMatchPostAsync(MatchEditViewModel matchForm)
        {
            throw new NotImplementedException();
        }

        public Task<SetEditViewModel> EditSetASyncGetAsync(int setId)
        {
            throw new NotImplementedException();
        }

        public Task<int> EditSetPostAsync(SetEditViewModel setForm)
        {
            throw new NotImplementedException();
        }

        public Task<TiebreakEditViewModel> EditTiebreakGetAsync(int tiebreakId)
        {
            throw new NotImplementedException();
        }

        public Task<int> EditTiebreakPostAsync(TiebreakEditViewModel tiebreakForm)
        {
            throw new NotImplementedException();
        }

        public Task<TournamentEditViewModel> EditTournamentGetAsync(int tournamentId)
        {
            throw new NotImplementedException();
        }

        public Task<int> EditTournamentPostAsync(TournamentEditViewModel tournamentForm)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ExistsByIdAsync(string userId)
        {
            return await repository
                .AllAsReadOnly<TournamentHost>()
                .AnyAsync(th => th.UserId == userId);
        }

        public async Task<int?> GetTournamentHostIdAsync(string userId)
        {
            return (await repository
                .AllAsReadOnly<TournamentHost>()
                .FirstOrDefaultAsync(th => th.UserId == userId))?.Id;

        }

        public Task<bool> MatchExistsInTournamentAsync(int matchId, int tournamentId)
        {
            throw new NotImplementedException();
        }

        public Task<TournamentMatchDeleteViewModel> RemoveMatchFromTournamentAsync(int matchId, int tournamentId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveMatchFromTournamentConfirmedAsync(int matchId, int tournamentId)
        {
            throw new NotImplementedException();
        }
    }
}
