using assignment_1.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace assignment_1.Repositories
{
    public class UserRoleRepo
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly UserManager<IdentityUser> _userManager;


        public UserRoleRepo(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _userManager = _serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
        }

        public async Task<UserRoleVM> FindOne(string email)
        {
            var user = await _userManager.FindByNameAsync(email);
            return new UserRoleVM
            {
                Id = user.Id,
                Email = user.Email,
                Role = ""
            };
        }

        public async Task<bool> AddUserRole(string email, string roleName)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null) await _userManager.AddToRoleAsync(user, roleName);
            return true;
        }

        public async Task<bool> RemoveUserRole(string email, string roleName)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null) await _userManager.RemoveFromRoleAsync(user, roleName);
            return true;
        }

        public async Task<IEnumerable<RoleVM>> GetUserRoles(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var roles = await _userManager.GetRolesAsync(user);
            List<RoleVM> roleVMObjects = new List<RoleVM>();
            foreach (var item in roles)
            {
                roleVMObjects.Add(new RoleVM() { Id = item, RoleName = item });
            }
            return roleVMObjects;
        }
    }
}
