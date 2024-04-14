namespace MatchPointMasters.Core.Models.Admin
{
    public class UserQueryServiceModel
    {
        public int TotalUsersCount { get; set; }
        public IEnumerable<UserServiceModel> Users { get; set; } = new HashSet<UserServiceModel>();
    }
}
