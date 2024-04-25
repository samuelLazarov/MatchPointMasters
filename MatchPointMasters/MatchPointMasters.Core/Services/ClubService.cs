using MatchPointMasters.Core.Contracts;
using MatchPointMasters.Core.Models.Club;
using MatchPointMasters.Infrastructure.Data;
using MatchPointMasters.Infrastructure.Data.Common;
using MatchPointMasters.Infrastructure.Data.Models.Tournament;
using MatchPointMasters.Infrastructure.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace MatchPointMasters.Core.Services
{
    public class ClubService : IClubService
    {
        private readonly IRepository repository;

        public ClubService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task AddAsync(AddClubFormModel model)
        {
            Club club = new Club() 
            {
                Name = model.Name,
                Address = model.Address,
                CourtSurface = model.CourtSurface,
                ImageUrl = model.ImageUrl,
                PhoneNumber = model.PhoneNumber,
            };

            dbContext.Add(club);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<AllClubViewModel>> AllAsync()
        {
            var allClubs = await dbContext.Clubs
                .Select(c => new AllClubViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Address = c.Address,
                    CourtSurface = c.CourtSurface.ToString(),
                    ImageUrl = c.ImageUrl,
                    PhoneNumber = c.PhoneNumber,
                })
                .ToArrayAsync();

            return allClubs;
        }

        public async Task<IEnumerable<ClubForTournamentViewModel>> GetAllForTournament()
        {
            var allClubsForTournament = await dbContext.Clubs
                .Select(c => new ClubForTournamentViewModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToArrayAsync();

            return allClubsForTournament;
        }
    }
}
