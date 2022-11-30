using CrudUsingMigration.Models;

namespace CrudUsingMigration.Data
{
    public interface IUserDetails
    {
        Task<bool> UserdetailsPost (User user);
        Task<List<User>> GetUserList();

    }
}
