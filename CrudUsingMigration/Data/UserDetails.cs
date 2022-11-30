using CrudUsingMigration.Context;
using CrudUsingMigration.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace CrudUsingMigration.Data
{
    public class UserDetails :IUserDetails
    {
        private readonly MainContext _mainContext;
        public UserDetails(MainContext context)
        {
            _mainContext = context;
        }
        public async Task<bool> UserdetailsPost(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
                await _mainContext.Users.AddAsync(user);
                await _mainContext.SaveChangesAsync();
                return true;
        }
        public async Task<List<User>> GetUserList()
        {
            var usersdetail = await _mainContext.Users.ToListAsync();
            return usersdetail;
        }

    }
}
