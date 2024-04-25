namespace MatchPointMasters.Core.Services
{
    using MatchPointMasters.Core.Contracts;
    using MatchPointMasters.Core.Enumerations;
    using MatchPointMasters.Core.Extensions;
    using MatchPointMasters.Core.Models.Match.QueryModels;
    using MatchPointMasters.Core.Models.Match.ViewModels;
    using MatchPointMasters.Core.Models.Set.QueryModels;
    using MatchPointMasters.Infrastructure.Data.Common;
    using MatchPointMasters.Infrastructure.Data.Models.Match;
    using MatchPointMasters.Infrastructure.Data.Models.Roles;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Match = Infrastructure.Data.Models.Match.Match;

    public class MatchService : IMatchService
    {
        private readonly IRepository repository;
        private readonly IUserService userService;
        private readonly IPlayerService playerService;
        private readonly ISetService setService;

        public MatchService(
            IRepository _repository, 
            IUserService _userService, 
            IPlayerService _playerService,
            ISetService _setService)
        {
            repository = _repository;
            userService = _userService;
            playerService = _playerService;
            setService = _setService;
        }

        public async Task<int> AddMatchAsync(MatchAddViewModel matchForm)
        {
            var playerOne = userService.GetUserByFullNameAsync(matchForm.PlayerOneName);
            var playerTwo = userService.GetUserByFullNameAsync(matchForm.PlayerTwoName);
            Match match = new Match()
            {
                TournamentId = matchForm.TournamentId,
                MatchRound = matchForm.MatchRound,
                PlayerOneId = playerOne.Id,
                PlayerTwoId = playerTwo.Id,
                PlayerOneSetsWon = matchForm.PlayerOneSetsWon,
                PlayerTwoSetsWon = matchForm.PlayerTwoSetsWon,
                Winner = matchForm.Winner,
            };

            await repository.AddAsync(match);
            await repository.SaveChangesAsync();

            return match.Id;
        }

        public async Task<MatchEditViewModel> EditMatchGetAsync(int matchId)
        {
            var currentMatch = await repository.All<Match>()
                .FirstOrDefaultAsync(m => m.Id == matchId);

            var playerOne = await playerService.FindPlayerByIdAsync(currentMatch.PlayerOneId);
            var playerOneName = await userService.UserFullNameAsync(playerOne.UserId);

            var playerTwo = await playerService.FindPlayerByIdAsync(currentMatch.PlayerTwoId);
            var playerTwoName = await userService.UserFullNameAsync(playerTwo.UserId);

            var matchForm = new MatchEditViewModel()
            {
                Id = currentMatch.Id,
                TournamentId= currentMatch.TournamentId,
                MatchRound = currentMatch.MatchRound,
                PlayerOneName = playerOneName,
                PlayerTwoName= playerTwoName,
                PlayerOneSetsWon= currentMatch.PlayerOneSetsWon,
                PlayerTwoSetsWon= currentMatch.PlayerTwoSetsWon,
                Winner = currentMatch.Winner
            };

            return matchForm;

        }

        public async Task<int> EditMatchPostAsync(MatchEditViewModel matchForm)
        {
            var match = await repository.All<Match>()
                .Where(m => m.Id == matchForm.Id)
                .FirstOrDefaultAsync();

            var userOne = await userService.GetUserByIdAsync(matchForm.PlayerOneName);
            var playerOne = await playerService.FindPlayerByUserIdAsync(userOne.Id);
            var userTwo = await userService.GetUserByIdAsync(matchForm.PlayerTwoName);
            var playerTwo = await playerService.FindPlayerByUserIdAsync(userTwo.Id);

            match.TournamentId = matchForm.TournamentId;
            match.MatchRound = matchForm.MatchRound;
            match.PlayerOneId = playerOne.Id;
            match.PlayerTwoId = playerTwo.Id;
            match.PlayerOneSetsWon = matchForm.PlayerOneSetsWon;
            match.PlayerTwoSetsWon = matchForm.PlayerTwoSetsWon;
            match.Winner = matchForm.Winner;

            await repository.SaveChangesAsync();

            return match.Id;

        }

        public async Task<MatchDeleteViewModel> DeleteMatchAsync(int matchId)
        {
            var currentMatch = await repository
                .AllAsReadOnly<Match>().Where(m => m.Id == matchId)
                .FirstOrDefaultAsync();

            var playerOne = await playerService.FindPlayerByIdAsync(currentMatch.PlayerOneId);
            var playerOneName = await userService.UserFullNameAsync(playerOne.UserId);

            var playerTwo = await playerService.FindPlayerByIdAsync(currentMatch.PlayerTwoId);
            var playerTwoName = await userService.UserFullNameAsync(playerTwo.UserId);

            var deleteForm = new MatchDeleteViewModel()
            {
                PlayerOneName = playerOneName,
                PlayerTwoName = playerTwoName,
                MatchRound = currentMatch.MatchRound,
                TournamentName = currentMatch.Tournament.Name
            };

            return deleteForm;
        }

        public async Task<int> DeleteMatchConfirmedAsync(int matchId)
        {
            var match = await repository
                .AllAsReadOnly<Match>()
                .Where(m => m.Id == matchId)
                .FirstOrDefaultAsync();

            await repository.RemoveAsync(match);
            await repository.SaveChangesAsync();

            return match.Id;
        }


        

        public async Task<SetQueryServiceModel> GetAllSetsInMatchAsync(int matchId)
        {
            var setsInMatch = await repository.AllAsReadOnly<Set>()
                .Where(s => s.MatchId == matchId).ToListAsync();

            int totalSets = setsInMatch.Count();

            return new SetQueryServiceModel()
            {
                TotalSetsCount = totalSets,
                Sets = (IEnumerable<SetServiceModel>)setsInMatch
            };
        }

        public async Task<MatchDetailsViewModel> MatchDetailsAsync(int matchId)
        {
            Match? currentMatch = await repository.AllAsReadOnly<Match>()
                .FirstOrDefaultAsync(m => m.Id == matchId);

            var playerOne = await playerService.FindPlayerByIdAsync(currentMatch.PlayerOneId);
            var playerOneName = await userService.UserFullNameAsync(playerOne.UserId);
            var playerTwo = await playerService.FindPlayerByIdAsync(currentMatch.PlayerTwoId);
            var playerTwoName = await userService.UserFullNameAsync(playerTwo.UserId);

            var currentMatchDetails = new MatchDetailsViewModel()
            {
                Id = currentMatch.Id,
                MatchRound = currentMatch.MatchRound,
                PlayerOneName = playerOneName,
                PlayerTwoName = playerTwoName,
                PlayerOneSetsWon = currentMatch.PlayerOneSetsWon,
                PlayerTwoSetsWon = currentMatch.PlayerTwoSetsWon,
                Winner = currentMatch.Winner,
            };

            return currentMatchDetails;
        }

        public async Task<bool> MatchExistsAsync(int matchId)
        {
            return await repository.AllAsReadOnly<Match>()
                .AnyAsync(m => m.Id == matchId);
        }

        public async Task<Match> FindMatchByIdAsync(int matchId)
        {
            return await repository.GetByIdAsync<Match>(matchId);
        }

        public async Task<MatchQueryServiceModel> AllMatchesByUserIdAsync(
            string userId, 
            string? searchTerm = null, 
            MatchStatus matchStatus = MatchStatus.All, 
            int currentPage = 1, int matchesPerPage = 8)
        {
            var player = playerService.FindPlayerByUserIdAsync(userId);
            var matchesToShow = repository.AllAsReadOnly<Match>()
                .Where(m => m.PlayerMatches.Any(pm => pm.PlayerId == player.Id));

            if(searchTerm != null)
            {
                string normalizedSearchTerm = searchTerm.ToLower();
                matchesToShow = matchesToShow
                    .Where(m => normalizedSearchTerm.Contains(m.PlayerOne.UserId.ToLower())
                    || normalizedSearchTerm.Contains(m.PlayerTwo.UserId.ToLower())
                    || m.PlayerOne.UserId.ToLower().Contains(normalizedSearchTerm)
                    || m.PlayerTwo.UserId.ToLower().Contains(normalizedSearchTerm));
            }

            if (matchStatus == MatchStatus.HasEnded)
            {
                matchesToShow = matchesToShow
                    .Where(m => m.Winner != null);
            }
            else if (matchStatus == MatchStatus.InProgress)
            {
                matchesToShow = matchesToShow
                    .Where(m => m.Winner == Infrastructure.Data.Enums.Match.Winner.StillPlaying
                    && m.Sets.Any(s => s.PlayerOneGamesWon > 0 || s.PlayerTwoGamesWon > 0));
            }
            if (matchStatus == MatchStatus.Upcoming)
            {
                matchesToShow = matchesToShow
                    .Where(m => m.Sets.Count == 0 && m.Winner != Infrastructure.Data.Enums.Match.Winner.StillPlaying);
            }

            var matches = await matchesToShow
                .Skip((currentPage - 1) * matchesPerPage)
                .Take(matchesPerPage)
                .ProjectToMatchServiceModel()
                .ToListAsync();

            int totalMatches = await matchesToShow.CountAsync();

            return new MatchQueryServiceModel()
            {
                Matches = matches,
                TotalMatchesCount = totalMatches
            };
        }

        //TODO - fill current match with data?
        public async Task<Match> AddSetToMatchAsync(int matchId, int setId)
        {
            var currentMatch = await repository.All<Match>()
            .Where(m => m.Id == matchId && m.Sets.Any(s => s.Id == setId))
            .FirstOrDefaultAsync();

            if (currentMatch == null)
            {
                currentMatch = new Match()
                {
                    Id = matchId,
                    //More props
                };

                await repository.AddAsync(currentMatch);
                await repository.SaveChangesAsync();
            }

            return currentMatch;

        }

    }
}
