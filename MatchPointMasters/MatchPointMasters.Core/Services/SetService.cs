using MatchPointMasters.Core.Contracts;
using MatchPointMasters.Infrastructure.Data.Common;

namespace MatchPointMasters.Core.Services
{
    public class SetService : ISetService
    {
        private readonly IRepository repository;

        public SetService(IRepository _repository)
        {
            repository = _repository;
        }


    }
}
