using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Model
{
    public class Tag
    {
        [Key]
        public int TagId { get; set; }
        public int AttachmentId { get; set; }

        public string TridionURI { get; set; }

        public string tag { get; set; }
        public int ArticleId { get; set; }
        
    }
}
