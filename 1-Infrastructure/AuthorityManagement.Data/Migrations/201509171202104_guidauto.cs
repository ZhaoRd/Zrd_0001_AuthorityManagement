namespace AuthorityManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class guidauto : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FunctionInRoles", "ID", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.Functions", "ID", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.Roles", "ID", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.GroupInRoles", "ID", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.Groups", "ID", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.UserInGroups", "ID", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.Users", "ID", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.UserInRoles", "ID", c => c.Guid(nullable: false, identity: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserInRoles", "ID", c => c.Guid(nullable: false));
            AlterColumn("dbo.Users", "ID", c => c.Guid(nullable: false));
            AlterColumn("dbo.UserInGroups", "ID", c => c.Guid(nullable: false));
            AlterColumn("dbo.Groups", "ID", c => c.Guid(nullable: false));
            AlterColumn("dbo.GroupInRoles", "ID", c => c.Guid(nullable: false));
            AlterColumn("dbo.Roles", "ID", c => c.Guid(nullable: false));
            AlterColumn("dbo.Functions", "ID", c => c.Guid(nullable: false));
            AlterColumn("dbo.FunctionInRoles", "ID", c => c.Guid(nullable: false));
        }
    }
}
