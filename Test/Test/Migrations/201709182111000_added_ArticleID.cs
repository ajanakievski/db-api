namespace Test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_ArticleID : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Articles", "ArticleID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Articles", "ArticleID");
        }
    }
}
