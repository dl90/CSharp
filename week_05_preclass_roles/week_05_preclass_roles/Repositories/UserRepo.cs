using System.Collections.Generic;
using System.Linq;
using week_05_preclass_roles.Data;
using week_05_preclass_roles.ViewModels;

namespace week_05_preclass_roles.Repositories
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
            var users = _context.Users.Select(u => new UserVM() { Email = u.Email });
            return users;
        }
    }
}