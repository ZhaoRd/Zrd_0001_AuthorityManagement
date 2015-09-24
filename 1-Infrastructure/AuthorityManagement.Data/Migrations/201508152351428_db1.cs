namespace AuthorityManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Functions", "FunctionType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Functions", "FunctionType");
        }
    }
}
