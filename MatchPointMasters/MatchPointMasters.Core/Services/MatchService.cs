namespace MatchPointMasters.Core.Services
{
    using MatchPointMasters.Core.Contracts;
    using MatchPointMasters.Core.Models.Match;
    using MatchPointMasters.Infrastructure.Data.Common;
    using MatchPointMasters.Infrastructure.Data.Models.Match;
    using Microsoft.EntityFrameworkCore;

    public class MatchService : IMatchService
    {
        private readonly IRepository repository;

        public MatchService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<MatchServiceModel> FindMatchByIdAsync(int id)
        {
            var match = await repository.All<Match>()
                                    .FirstOrDefaultAsync(m => m.Id == id);

            return new MatchServiceModel(match);
        }
    }
}
