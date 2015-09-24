namespace AuthorityManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addModelNameInFunction : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Functions", "FunctionName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Functions", "FunctionName");
        }
    }
}
