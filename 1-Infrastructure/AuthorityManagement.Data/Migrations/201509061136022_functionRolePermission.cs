namespace AuthorityManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class functionRolePermission : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FunctionInRoles", "PermissionValue", c => c.Int(nullable: false));
            AddColumn("dbo.Functions", "PermissionValue", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Functions", "PermissionValue");
            DropColumn("dbo.FunctionInRoles", "PermissionValue");
        }
    }
}
