using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Model
{
    public class ArticleJSON 
    {
        // Class Article is our root class, where all the 
        [Key]
        public int Id { get; set; }    
        public int AuthorId { get; set; }
        public string Category { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public string Guid { get; set; }
        public string Local { get; set; }
        public string SearchIndex { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public Meta Meta { get; set; }
        [ForeignKey("Id")]
        public List<Attachment> Attachments { get; set; }



        public string TridionURI { get; set; }      
        

        [ForeignKey("Id")]
        public List<EmbededVideos> EmbeddedVideos { get; set; }
        [ForeignKey("Id")]
        public List<FeaturedCategories> FeaturedCategories { get; set; }
        [ForeignKey("Id")]
        public List<RelatedPosts> RelatedPosts { get; set; }                    
        
        
    }
    

}

    
