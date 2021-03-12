using assignment_1.Data;
using assignment_1.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;

namespace assignment_1.Repositories
{
    public class RoleRepo
    {
        private readonly ApplicationDbContext _context;
        static readonly string[] roles = { "Admin", "Client" };

        public RoleRepo(ApplicationDbContext context)
        {
            _context = context;
            CreateInitialRoles();
        }

        public void CreateInitialRoles()
        {
            foreach (var role in roles)
            {
                CreateRole(role);
            }
        }

        public List<RoleVM> GetAllRoles()
        {
            var roles = _context.Roles;
            List<RoleVM> roleList = new List<RoleVM>();

            foreach (var item in roles)
            {
                roleList.Add(new RoleVM() { RoleName = item.Name, Id = item.Id });
            }
            return roleList;
        }

        public RoleVM GetRole(string roleName)
        {
            var role = _context.Roles.Where(r => r.Name == roleName).FirstOrDefault();
            if (role != null) return new RoleVM() { RoleName = role.Name, Id = role.Id };
            return null;
        }

        public IdentityRole GetOne(string id)
        {
            return _context.Roles.Where(r => r.Id == id).FirstOrDefault();
        }

        public bool CreateRole(string roleID)
        {
            var role = GetOne(roleID);
            if (role != null) return false;
            _context.Roles.Add(new IdentityRole
            {
                Name = roleID,
                Id = roleID,
                NormalizedName = roleID.ToUpper()
            });
            _context.SaveChanges();
            return true;
        }

        public RoleVM UpdateRole(RoleVM updatedRole)
        {
            var role = GetOne(updatedRole.Id);
            if (role == null) return null;

            role.Name = updatedRole.RoleName;
            role.NormalizedName = updatedRole.RoleName.ToUpper();
            _context.SaveChanges();

            return new RoleVM { Id = role.Id, RoleName = role.Name };
        }

        public bool DeleteRole(string roleID)
        {
            var role = GetOne(roleID);
            _context.Roles.Remove(role);
            var count = _context.SaveChanges();
            return count > 0;
        }
    }
}
