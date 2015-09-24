namespace AuthorityManagement.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using AuthorityManagement.Core.Domains;

    internal sealed class Configuration : DbMigrationsConfiguration<AuthorityManagementContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AuthorityManagementContext context)
        {
            var userid = new Guid("9F936EC4-0C59-49E8-8552-1B677E22673E");
            var roleId = new Guid("A21FBA43-349C-4589-A44A-F51EA3172C23");
            var userInRoleId = new Guid("4AC2325D-4F14-4772-B841-FFF4329BEAAC");

            var addUser = new User
                              {
                                  ID = userid,
                                  CreationTime = DateTime.Now,
                                  IsActive = true,
                                  UserName = "super",
                                  Password = "123qwe",
                              };
            var addRole = new Role { ID = roleId, CreationTime = DateTime.Now, IsDefault = true, RoleName = "系统管理员" };

            var userInRole = new UserInRole { ID = userInRoleId, Role = addRole, User = addUser };

            context.Users.AddOrUpdate(u => u.ID, addUser);
            context.Roles.AddOrUpdate(u => u.ID, addRole);
            context.UserInRoles.AddOrUpdate(u => u.ID, userInRole);

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
