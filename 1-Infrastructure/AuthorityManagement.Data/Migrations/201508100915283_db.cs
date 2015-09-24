namespace AuthorityManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FunctionInRoles",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Function_ID = c.Guid(),
                        Role_ID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Functions", t => t.Function_ID)
                .ForeignKey("dbo.Roles", t => t.Role_ID)
                .Index(t => t.Function_ID)
                .Index(t => t.Role_ID);
            
            CreateTable(
                "dbo.Functions",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        FunctionName = c.String(),
                        Description = c.String(),
                        AreasName = c.String(),
                        ControllerName = c.String(),
                        ActionName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        RoleName = c.String(),
                        Description = c.String(),
                        CreatorUserId = c.Guid(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Guid(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Guid(),
                        DeletionTime = c.DateTime(),
                        CreationTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.GroupInRoles",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Group_ID = c.Guid(),
                        Role_ID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Groups", t => t.Group_ID)
                .ForeignKey("dbo.Roles", t => t.Role_ID)
                .Index(t => t.Group_ID)
                .Index(t => t.Role_ID);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        GroupName = c.String(),
                        Description = c.String(),
                        CreatorUserId = c.Guid(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Guid(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Guid(),
                        DeletionTime = c.DateTime(),
                        CreationTime = c.DateTime(nullable: false),
                        Parent_ID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Groups", t => t.Parent_ID)
                .Index(t => t.Parent_ID);
            
            CreateTable(
                "dbo.UserInGroups",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Group_ID = c.Guid(),
                        User_ID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Groups", t => t.Group_ID)
                .ForeignKey("dbo.Users", t => t.User_ID)
                .Index(t => t.Group_ID)
                .Index(t => t.User_ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        UserName = c.String(),
                        Password = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreatorUserId = c.Guid(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Guid(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Guid(),
                        DeletionTime = c.DateTime(),
                        CreationTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.UserInRoles",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Role_ID = c.Guid(),
                        User_ID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Roles", t => t.Role_ID)
                .ForeignKey("dbo.Users", t => t.User_ID)
                .Index(t => t.Role_ID)
                .Index(t => t.User_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserInRoles", "User_ID", "dbo.Users");
            DropForeignKey("dbo.UserInRoles", "Role_ID", "dbo.Roles");
            DropForeignKey("dbo.UserInGroups", "User_ID", "dbo.Users");
            DropForeignKey("dbo.UserInGroups", "Group_ID", "dbo.Groups");
            DropForeignKey("dbo.GroupInRoles", "Role_ID", "dbo.Roles");
            DropForeignKey("dbo.GroupInRoles", "Group_ID", "dbo.Groups");
            DropForeignKey("dbo.Groups", "Parent_ID", "dbo.Groups");
            DropForeignKey("dbo.FunctionInRoles", "Role_ID", "dbo.Roles");
            DropForeignKey("dbo.FunctionInRoles", "Function_ID", "dbo.Functions");
            DropIndex("dbo.UserInRoles", new[] { "User_ID" });
            DropIndex("dbo.UserInRoles", new[] { "Role_ID" });
            DropIndex("dbo.UserInGroups", new[] { "User_ID" });
            DropIndex("dbo.UserInGroups", new[] { "Group_ID" });
            DropIndex("dbo.GroupInRoles", new[] { "Role_ID" });
            DropIndex("dbo.GroupInRoles", new[] { "Group_ID" });
            DropIndex("dbo.Groups", new[] { "Parent_ID" });
            DropIndex("dbo.FunctionInRoles", new[] { "Role_ID" });
            DropIndex("dbo.FunctionInRoles", new[] { "Function_ID" });
            DropTable("dbo.UserInRoles");
            DropTable("dbo.Users");
            DropTable("dbo.UserInGroups");
            DropTable("dbo.Groups");
            DropTable("dbo.GroupInRoles");
            DropTable("dbo.Roles");
            DropTable("dbo.Functions");
            DropTable("dbo.FunctionInRoles");
        }
    }
}
