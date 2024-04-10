using MatchPointMasters.Core.Contracts;
using MatchPointMasters.Infrastructure.Data.Common;

namespace MatchPointMasters.Core.Services
{
    public class TiebreakService : ITiebreakService
    {
        private readonly IRepository repository;


        public TiebreakService(IRepository _repository)
        {
            repository = _repository;
        }
    }
}
