namespace MatchPointMasters.Core.Contracts
{
    using MatchPointMasters.Core.Models.Article;
    using MatchPointMasters.Core.Models.Match;
    using MatchPointMasters.Core.Models.Set;
    using MatchPointMasters.Core.Models.Tiebreak;
    using MatchPointMasters.Core.Models.Tournament;
    using MatchPointMasters.Infrastructure.Data.Models.Mappings;

    public interface ITournamentHostService
    {
        Task<bool> ExistsByIdAsync(string userId);
        Task<int?> GetTournamentHostIdAsync(string userId);

        //Tournament
        Task<int> AddTournamentAsync(TournamentAddViewModel tournamentForm);
        Task<TournamentEditViewModel> EditTournamentGetAsync(int tournamentId);
        Task<int> EditTournamentPostAsync(TournamentEditViewModel tournamentForm);
        Task<TournamentDeleteViewModel> DeleteTournamentAsync(int tournamentId);
        Task<int> DeleteTournamentConfirmedAsync(int tournamentId);
        Task<bool> MatchExistsInTournamentAsync(int matchId, int tournamentId);
        Task<TournamentMatch> AddMatchToTournamentAsync(int matchId, int tournamentId);
        Task<TournamentMatchDeleteViewModel> RemoveMatchFromTournamentAsync(int matchId, int tournamentId);
        Task RemoveMatchFromTournamentConfirmedAsync(int matchId, int tournamentId);


        //Match
        Task<int> AddMatchAsync(MatchAddViewModel matchForm);
        Task<MatchEditViewModel> EditMatchGetAsync(int matchId);
        Task<int> EditMatchPostAsync(MatchEditViewModel matchForm);
        Task<MatchDeleteViewModel> DeleteMatchAsync(int matchId);
        Task<int> DeleteMatchConfirmedAsync(int matchId);

        //Set
        Task<int> AddSetAsync(SetAddViewModel setForm);
        Task<SetEditViewModel> EditSetASyncGetAsync(int setId);
        Task<int> EditSetPostAsync(SetEditViewModel setForm);
        Task<SetDeleteViewModel> DeleteSetAsync(int setId);
        Task<int> DeleteSetConfirmedAsync(int setId);

        //Tiebreak
        Task<int> AddTiebreakAsync(TiebreakAddViewModel tiebreakForm);
        Task<TiebreakEditViewModel> EditTiebreakGetAsync(int tiebreakId);
        Task<int> EditTiebreakPostAsync(TiebreakEditViewModel tiebreakForm);
        Task<TiebreakDeleteViewModel> DeleteTiebreakAsync(int tiebreakId);
        Task<int> DeleteTiebreakConfirmedAsync(int tiebreakId);

        //Article
        Task<int> AddArticleAsync(ArticleAddViewModel articleForm);
        Task<ArticleEditViewModel> EditArticleGetAsync(int articleId);
        Task<int> EditArticlePostAsync(ArticleEditViewModel articleForm);
        Task<ArticleDeleteViewModel> DeleteArticleAsync(int articleId);
        Task<int> DeleteArticleConfirmedAsync(int articleId);


    }
}
