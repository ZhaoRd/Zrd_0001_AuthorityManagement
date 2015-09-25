namespace AuthorityManagement.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Net.Mime;

    using AuthorityManagement.Core.Domains;

    internal sealed class Configuration : DbMigrationsConfiguration<AuthorityManagementContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AuthorityManagementContext context)
        {
            var userId=new Guid("5894340B-9973-40B3-8769-FE388D33F62B");

            var addUesr = new User()
                            {
                                ID = userId,
                                CreationTime = DateTime.Now,
                                IsActive = true,
                                IsDeleted = false,
                                UserName = "super",
                                Password = "super",
                            };
            context.Users.AddOrUpdate(u => u.ID, addUesr);

            var roleId = new Guid("B8D70895-1F6B-416F-A213-484A51E2CC18");
            var addRole = new Role() { CreationTime = DateTime.Now, ID = roleId, IsDefault = true, RoleName = "系统管理员" };

            context.Roles.AddOrUpdate(u => u.ID, addRole);

            var userinroleid=new Guid("4CE2B167-912E-4A31-B52E-A1E5953A1A23");
            context.UserInRoles.AddOrUpdate(u=>u.ID,
                new UserInRole()
                    {
                        ID = userinroleid,
                        Role = addRole,
                        User = addUesr
                    });

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
