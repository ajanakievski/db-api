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

            //do we need this?
            int attId = 0;
            int tagId = 0;
            int eVideosId = 0;
            int fCategoriesId = 0;
            int rPostId = 0;
            //define error lists
            List<Article> articleError = new List<Article>();
            List<Attachment> attachmentsError = new List<Attachment>();
            List<EmbededVideos> embadedVideosError = new List<EmbededVideos>();
            List<FeaturedCategories> featuredCategoriesError = new List<FeaturedCategories>();
            List<Meta> metaError = new List<Meta>();
            List<RelatedPosts> relatedPostsError = new List<RelatedPosts>();
            List<Tag> tagError = new List<Tag>();

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
                    articleError.Add(tempArticle);


                }
                catch (Exception w)
                {
                    string whatEx = w.ToString();
                    articleError.Add(tempArticle);
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
#pragma warning disable CS0168 // Variable is declared but never used
                    catch (DbEntityValidationException ea)
#pragma warning restore CS0168 // Variable is declared but never used
                    {
                        attachmentsError.Add(tempAttachment);

                    }
#pragma warning disable CS0168 // Variable is declared but never used
                    catch (Exception ex)
#pragma warning restore CS0168 // Variable is declared but never used
                    {
                        attachmentsError.Add(tempAttachment);
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
#pragma warning disable CS0168 // Variable is declared but never used
                        catch (DbEntityValidationException ec)
#pragma warning restore CS0168 // Variable is declared but never used
                        {
                            tagError.Add(tempTag);

                        }
#pragma warning disable CS0168 // Variable is declared but never used
                        catch (Exception ex)
#pragma warning restore CS0168 // Variable is declared but never used
                        {
                            tagError.Add(tempTag);
                        }
                        //do we need this?
                        tagId++;

                        //limit tags somehow
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
#pragma warning disable CS0168 // Variable is declared but never used
                    catch (DbEntityValidationException eb)
#pragma warning restore CS0168 // Variable is declared but never used
                    {
                        embadedVideosError.Add(tempVid);

                    }
#pragma warning disable CS0168 // Variable is declared but never used
                    catch (Exception ex)
#pragma warning restore CS0168 // Variable is declared but never used
                    {
                        embadedVideosError.Add(tempVid);
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
#pragma warning disable CS0168 // Variable is declared but never used
                    catch (DbEntityValidationException ee)
#pragma warning restore CS0168 // Variable is declared but never used
                    {
                        featuredCategoriesError.Add(tempCat);

                    }
#pragma warning disable CS0168 // Variable is declared but never used
                    catch (Exception ex)
#pragma warning restore CS0168 // Variable is declared but never used
                    {
                        featuredCategoriesError.Add(tempCat);
                    }
                    fCategoriesId++;

                }
                foreach (int post in item.Meta.relatedPosts)
                {
                    RelatedPosts tempPosts = new RelatedPosts() { relatedPosts = post, RelatedPostsId = rPostId, ArticleId = tempArticle.Id  };
                    db.RelatedPosts.Add(tempPosts);
                    
                    try
                    {
                        db.SaveChanges();

                    }
#pragma warning disable CS0168 // Variable is declared but never used
                    catch (DbEntityValidationException ed)
#pragma warning restore CS0168 // Variable is declared but never used
                    {
                        relatedPostsError.Add(tempPosts);

                    }
#pragma warning disable CS0168 // Variable is declared but never used
                    catch (Exception ex)
#pragma warning restore CS0168 // Variable is declared but never used
                    {
                        relatedPostsError.Add(tempPosts);
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

            //error handling 
            string result = "";
            if (articleError.Count > 0 || attachmentsError.Count > 0 || embadedVideosError.Count > 0 || featuredCategoriesError.Count > 0 || metaError.Count > 0 || relatedPostsError.Count > 0 || tagError.Count > 0)
            {
                result = "article errors: " + articleError.Count + "\n attachments errors: " + attachmentsError.Count + "\n Videos errors: " + embadedVideosError.Count + "\n categories errors " + featuredCategoriesError.Count + "\n Meta errors" + metaError.Count + "\n Posts errors:" + relatedPostsError.Count + "\n Tags error: " + tagError.Count;
            }
            else
            {
                result = "Congratulations! Database inserts finnished without error";
               
            }
            MessageBox.Show(result);


        }

        
       

        
    }
}
