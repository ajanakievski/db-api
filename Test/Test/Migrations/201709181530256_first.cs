namespace Test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AuthorId = c.Int(nullable: false),
                        Category = c.String(),
                        Content = c.String(),
                        Date = c.DateTime(nullable: false),
                        Guid = c.String(),
                        Local = c.String(),
                        SearchIndex = c.String(),
                        Title = c.String(),
                        Type = c.String(),
                        TridionURI = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        LastUpdated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Attachments",
                c => new
                    {
                        AttachmentId = c.Int(nullable: false, identity: true),
                        ArticleId = c.Int(nullable: false),
                        Guid = c.String(),
                        PostMimeType = c.String(),
                        PostName = c.String(),
                        SiteId = c.String(),
                        Date = c.DateTime(nullable: false),
                        TridionURI = c.String(),
                    })
                .PrimaryKey(t => t.AttachmentId)
                .ForeignKey("dbo.Articles", t => t.ArticleId, cascadeDelete: true)
                .Index(t => t.ArticleId);

            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        TagId = c.Int(nullable: false, identity: true),
                        AttachmentId = c.Int(nullable: false),
                        TridionURI = c.String(),
                        tag = c.String(),
                        ArticleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TagId)
                .ForeignKey("dbo.Attachments", t => t.AttachmentId, cascadeDelete: true)
                .ForeignKey("dbo.Articles", t => t.ArticleId)
                .Index(t => t.AttachmentId);
            
            CreateTable(
                "dbo.EmbededVideos",
                c => new
                    {
                        EmbededVideosId = c.Int(nullable: false, identity: true),
                        embededVideos = c.String(),
                        ArticleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmbededVideosId)
                .ForeignKey("dbo.Articles", t => t.ArticleId)
                .Index(t => t.ArticleId) ;
            
            CreateTable(
                "dbo.FeaturedCategories",
                c => new
                    {
                        FeaturedCategoriesId = c.Int(nullable: false, identity: true),
                        featuredCategories = c.Int(nullable: false),
                        ArticleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FeaturedCategoriesId)
                .ForeignKey("dbo.Articles", t => t.ArticleId)
                .Index(t => t.ArticleId);

            CreateTable(
                "dbo.RelatedPosts",
                c => new
                    {
                        RelatedPostsId = c.Int(nullable: false, identity: true),
                        relatedPosts = c.Int(nullable: false),
                        ArticleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RelatedPostsId)
                .ForeignKey("dbo.Articles", t => t.ArticleId)
                .Index(t => t.ArticleId);

        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tags", "AttachmentId", "dbo.Attachments");
            DropIndex("dbo.Tags", new[] { "AttachmentId" });
            DropTable("dbo.RelatedPosts");
            DropTable("dbo.FeaturedCategories");
            DropTable("dbo.EmbededVideos");
            DropTable("dbo.Tags");
            DropTable("dbo.Attachments");
            DropTable("dbo.Articles");
        }
    }
}
