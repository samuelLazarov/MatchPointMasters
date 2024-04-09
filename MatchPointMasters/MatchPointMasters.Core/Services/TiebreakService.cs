using MatchPointMasters.Infrastructure.Data.Common;

namespace MatchPointMasters.Core.Services
{
    public class TiebreakService
    {
        private readonly IRepository repository;


        public TiebreakService(IRepository _repository)
        {
            repository = _repository;
        }
    }
}
