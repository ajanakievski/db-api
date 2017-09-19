using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Model
{

    public class Meta
    {
        

        
        public List<string> embeddedVideos { get; set; }
        public List<int> featuredCategories { get; set; }
        public List<int> relatedPosts { get; set; }

        
               

    }


}
