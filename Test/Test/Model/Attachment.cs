using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Model
{
    public class Attachment
    {
        [Key]
        public int AttachmentId { get; set; }
               
        public int ArticleId { get; set; }        


        public string Guid { get; set; }
        public string PostMimeType { get; set; }
        public string PostName { get; set; }

        public string SiteId { get; set; }
        public DateTime Date { get; set; }

        public string TridionURI { get; set; }

        [ForeignKey("AttachmentId")]
        public List<Tag> Tags { get; set; }

        private List<string> tempTags;
        public List<string> tags
        {
            get
            {
                tempTags = PostName.Split('_').ToList();
                return tempTags;
            }
            set
            {
                tempTags = value;
            }

        }


    }

}
