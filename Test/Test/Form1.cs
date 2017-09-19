using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Test.Model;
using Newtonsoft.Json;
using System.Reflection; 
using Test.DAL;
using System.Data.Entity.Validation;

namespace Test
{
    public partial class Form1 : Form
    {
        public List<ArticleJSON> mArticles = new List<ArticleJSON>();
        private TESTContext db =  new TESTContext();

        public Form1()
        {
            InitializeComponent();
        }

        private void Read_Click(object sender, EventArgs e)
        {
            
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.NullValueHandling = NullValueHandling.Ignore;
            string json = File.ReadAllText("TEST.json");
            mArticles = JsonConvert.DeserializeObject<List<ArticleJSON>>(json, settings);            
        }
        private void Fill_Click(object sender, EventArgs e)
        {
            int attId = 0;
            int tagId = 0;
            int eVideosId = 0;
            int fCategoriesId = 0;
            int rPostId = 0;
            foreach (ArticleJSON item in mArticles)
            {
                Article tempArticle = new Article(item);
               
                tempArticle.IsDeleted = false;
                tempArticle.LastUpdated = DateTime.Now;
                db.Articles.Add(tempArticle);
                try
                {
                    db.SaveChanges();

                }
                catch (DbEntityValidationException ex)
                {
                    string exception = ex.ToString();
                }
                catch (Exception w)
                {
                    string whatEx = w.ToString();
                }


                foreach (Attachment att in item.Attachments)
                {
                    Attachment tempAttachment = new Attachment();
                    tempAttachment = att;
                    //att.AttachmentId = attId;
                    tempAttachment.ArticleId = tempArticle.Id;


                   // att.Id = item.Id;
                    att.SiteId = item.Local;
                    att.Date = item.Date;
                    db.Attachments.Add(tempAttachment);
                    try
                    {
                        db.SaveChanges();

                    }
                    catch (DbEntityValidationException)
                    {

                    }
                    int tagsCounter = 0;
                    int maxTags = 10;
                    foreach (string temp in att.tags)
                    {
                        tagsCounter++;
                        Tag tempTag = new Tag() { AttachmentId = tempAttachment.AttachmentId, tag = temp, ArticleId = tempArticle.Id, TagId = tagId };
                        db.Tags.Add(tempTag);
                        try
                        {
                            db.SaveChanges();

                        }
                        catch (DbEntityValidationException)
                        {

                        }
                        tagId++;
                        if (tagsCounter > maxTags)
                        {

                            int tags_currentcounter = att.tags.Count;
                            break;
                        }
                    }
                    
                   
                    attId++;
                }

                foreach(string vids in item.Meta.embeddedVideos)
                {
                    EmbededVideos tempVid = new EmbededVideos() { embededVideos = vids, EmbededVideosId = eVideosId, ArticleId = tempArticle.Id };
                    db.EmbededVideos.Add(tempVid);
          
                    try
                    {
                        db.SaveChanges();

                    }
                    catch (DbEntityValidationException)
                    {

                    }
                    eVideosId++;

                }
                foreach (int  cat in item.Meta.featuredCategories)
                {
                    FeaturedCategories tempCat = new FeaturedCategories() {  featuredCategories= cat, FeaturedCategoriesId = fCategoriesId, ArticleId = tempArticle.Id };
                    db.FeaturedCategories.Add(tempCat);
                    
                    try
                    {
                        db.SaveChanges();

                    }
                    catch (DbEntityValidationException)
                    {

                    }
                    fCategoriesId++;

                }
                foreach (int post in item.Meta.relatedPosts)
                {
                    RelatedPosts tempVid = new RelatedPosts() { relatedPosts = post, RelatedPostsId = rPostId, ArticleId = tempArticle.Id  };
                    db.RelatedPosts.Add(tempVid);
                    
                    try
                    {
                        db.SaveChanges();

                    }
                    catch (DbEntityValidationException)
                    {

                    }
                    rPostId++;

                }

                //db.Articles.Add(tempArticle);
                //db.SaveChanges();
                //try
                //{
                //    db.SaveChanges();

                //}
                //catch (DBConcurrencyException  DBEX)
                //{
                //    string dbex = DBEX.ToString();
                //}
                //catch (Exception excwption)
                //{
                //    string excet = excwption.ToString();

                //    throw;
                //}
               
                
            }
        }

        
       

        
    }
}
