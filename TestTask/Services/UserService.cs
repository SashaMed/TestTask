using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services
{
    public class UserService : IUserService
    {

        private ApplicationDbContext applicationDbContext;

        public UserService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task<User> GetUser()
        {
            var user = applicationDbContext.Users.OrderByDescending(u => u.Orders.Count).FirstOrDefault();
            return user;
        }

        public async Task<List<User>> GetUsers()
        {
            var users = await applicationDbContext.Users.Where(c => c.Status == Enums.UserStatus.Inactive).ToListAsync();
            return users;
        }
    }
}
