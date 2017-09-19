using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Model
{
    public class Article : TrackChanges
    {
        // Class Article is our root class, where all the 
        [Key]
        public int Id { get; set; }   
        public int ArticleID { get; set; }
        public int AuthorId { get; set; }
        public string Category { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public string Guid { get; set; }
        public string Local { get; set; }
        public string SearchIndex { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string TridionURI { get; set; }      
        

        public Article( ArticleJSON articleJSON)
        {
            ArticleID = articleJSON.Id;
            AuthorId = articleJSON.AuthorId;
            Category = articleJSON.Category;
            Content = articleJSON.Content;
            Date = articleJSON.Date;
            Guid = articleJSON.Guid;
            Local = articleJSON.Local;
            SearchIndex = articleJSON.SearchIndex;
            Title = articleJSON.Title;
            Type = articleJSON.Type;
            TridionURI = articleJSON.TridionURI;


        }

                    
        
        
    }

    

}

    
