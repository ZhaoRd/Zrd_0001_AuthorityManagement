namespace AuthorityManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class guidnoiden : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FunctionInRoles", "ID", c => c.Guid(nullable: false));
            AlterColumn("dbo.Functions", "ID", c => c.Guid(nullable: false));
            AlterColumn("dbo.Roles", "ID", c => c.Guid(nullable: false));
            AlterColumn("dbo.GroupInRoles", "ID", c => c.Guid(nullable: false));
            AlterColumn("dbo.Groups", "ID", c => c.Guid(nullable: false));
            AlterColumn("dbo.UserInGroups", "ID", c => c.Guid(nullable: false));
            AlterColumn("dbo.Users", "ID", c => c.Guid(nullable: false));
            AlterColumn("dbo.UserInRoles", "ID", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserInRoles", "ID", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.Users", "ID", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.UserInGroups", "ID", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.Groups", "ID", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.GroupInRoles", "ID", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.Roles", "ID", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.Functions", "ID", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.FunctionInRoles", "ID", c => c.Guid(nullable: false, identity: true));
        }
    }
}
