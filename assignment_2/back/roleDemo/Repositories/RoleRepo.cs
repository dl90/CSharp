﻿using Microsoft.AspNetCore.Identity;
using roleDemo.Data;
using roleDemo.Models;
using roleDemo.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace roleDemo.Repositories
{
    public class RoleRepo
    {
        private readonly ApplicationDbContext _context;

        public RoleRepo(ApplicationDbContext context)
        {
            _context = context;
            var rolesCreated = CreateInitialRoles();
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
            if (role != null)
            {
                return new RoleVM() { RoleName = role.Name, Id = role.Id };
            }
            return null;
        }

        public bool CreateRole(string roleName)
        {
            var role = GetRole(roleName);
            if (role != null)
            {
                return false;
            }
            _context.Roles.Add(new IdentityRole
            {
                Name = roleName,
                Id = roleName,
                NormalizedName = roleName.ToUpper()
            });
            _context.SaveChanges();
            return true;
        }

        public bool CreateInitialRoles()
        {
            string[] roleNames = { "Admin", "Customer" };
            foreach (var roleName in roleNames)
            {
                var created = CreateRole(roleName);
                if (!created)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
