using assignment_1.Data;
using assignment_1.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace assignment_1.Repositories
{
    public class UserRepo
    {
        ApplicationDbContext _context;

        public UserRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<UserVM> All()
        {
            return _context.Users.Select(u => new UserVM() { Email = u.Email, ID = u.Id });
        }

        public UserVM FineOne(string userName)
        {
            return _context.Users
                .Where(u => u.UserName == userName)
                .Select(u => new UserVM { Email = u.Email, ID = u.Id })
                .FirstOrDefault();
        }
    }
}
