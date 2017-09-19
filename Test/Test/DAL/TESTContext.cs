using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Model;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Test.DAL
{
  public class TESTContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Attachment> Attachments { get; set; }        
        public DbSet<FeaturedCategories> FeaturedCategories { get; set; }
        public DbSet<RelatedPosts> RelatedPosts { get; set; }
        public DbSet<EmbededVideos> EmbededVideos { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}
