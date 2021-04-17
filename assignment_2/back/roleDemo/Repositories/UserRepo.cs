using roleDemo.Data;
using roleDemo.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace roleDemo.Repositories
{
    public class UserRepo
    {
        ApplicationDbContext _context;

        public UserRepo(ApplicationDbContext context)
        {
            this._context = context;
        }

        public IEnumerable<UserVM> All()
        {
            var users = _context.Users.Select(u => new UserVM()
            {
                UserName = u.UserName
            });
            return users;
        }
    }
}
