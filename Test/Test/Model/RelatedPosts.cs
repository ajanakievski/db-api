using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Model
{
    public class RelatedPosts
    {
        [Key]
        public int RelatedPostsId { get; set; }

        public int relatedPosts { get; set; }
        
        public int ArticleId { get; set; }

       
    }
}
