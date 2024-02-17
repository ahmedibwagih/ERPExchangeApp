using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dynamo.Context.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Dynamo.Context.Identity
{
    public class DynamoUserManager : UserManager<DynamoUser>
    {
        private UserStore<DynamoUser, DynamoRole, DynamoContext, string, IdentityUserClaim<string>
            , IdentityUserRole<string>, IdentityUserLogin<string>, IdentityUserToken<string>
            , IdentityRoleClaim<string>> store;

        public DynamoUserManager(IUserStore<DynamoUser> store
            , IOptions<IdentityOptions> optionsAccessor
            , IPasswordHasher<DynamoUser> passwordHasher
            , IEnumerable<IUserValidator<DynamoUser>> userValidators
            , IEnumerable<IPasswordValidator<DynamoUser>> passwordValidators
            , ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors
            , IServiceProvider services, ILogger<UserManager<DynamoUser>> logger) : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {

        }

        private DynamoContext GetContext()
        {
            store = (UserStore<DynamoUser, DynamoRole, DynamoContext, string, IdentityUserClaim<string>,
                    IdentityUserRole<string>, IdentityUserLogin<string>, IdentityUserToken<string>, IdentityRoleClaim<string>>)Store;

            var context = store.Context;
            return context;
        }

        public async Task<bool> UserHasAccess(string userId, string permisions)
        {
            var context = GetContext();

            var isAdminUser = await IsAdminAsync(userId);

            if (isAdminUser)
                return true;

            var permissionsArr = permisions.Split(",").ToArray();
            var count = await context.UserRoles
                .Join(context.RolePermissions,
                    userRole => userRole.RoleId,
                    rolePermission => rolePermission.RoleId,
                    (userRole, rolePermission) => new { userRole, rolePermission })
                .Join(context.Permissions,
                    rp => rp.rolePermission.PermissionId,
                    permission => permission.Id,
                    (rp, permission) => new { rp, permission })
                .Where(x => permissionsArr.Any(a => a == x.permission.Name) && x.rp.userRole.UserId == userId)
                .CountAsync();

            return count > 0;
        }

        public async Task<string[]> GetUserPermission(string userId)
        {
            var context = GetContext();
            string[] permissions;

            var isAdminUser = await IsAdminAsync(userId);

            if (isAdminUser)
            {
                permissions = context.Permissions
                    .Select(xx => xx.Name).ToArray();
            }
            else
            {
                permissions = await context.UserRoles
                .Join(context.RolePermissions,
                    userRole => userRole.RoleId,
                    rolePermission => rolePermission.RoleId,
                    (userRole, rolePermission) => new { userRole, rolePermission })
                .Join(context.Permissions,
                    rp => rp.rolePermission.PermissionId,
                    permission => permission.Id,
                    (rp, permission) => new { rp, permission })
                .Where(x => x.rp.userRole.UserId == userId)
                .Select(x => x.permission.Name)
                .AsNoTracking().ToArrayAsync();

            }
            return permissions;
        }

        private async Task<bool> IsAdminAsync(string userId)
        {
            var context = GetContext();
            return await context.Roles
                    .Join(context.UserRoles,
                        role => role.Id,
                        userRole => userRole.RoleId,
                        (role, userRole) => new { role, userRole })
                    .Where(x => x.userRole.UserId == userId && x.role.IsAdmin == true)
                    .CountAsync() > 0;
        }


        public async Task<(DynamoUser, string[])> GetUserSession(string userId)
        {
            var context = GetContext();

            var permissions = await GetUserPermission(userId);

            var user = await context.Users
                .Include(x => x.UserRoles)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == userId);

            return (user, permissions);
        }
        public async Task<DynamoUser[]> GetUsersPermission(string permission)
        {
            var context = GetContext();
            return await context.Users
                .Where(x => x.UserRoles
                .Any(r => r.RolePermissions
                .Any(p => p.Permission.Name.Equals(permission))))
                .ToArrayAsync();
        }
    }
}
