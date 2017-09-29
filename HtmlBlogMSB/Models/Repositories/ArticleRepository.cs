using HtmlBlogMSB.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HtmlBlogMSB.Models.Repositories
{
    public class ArticleRepository
    {
        ProjectContext DBContext = new ProjectContext();
        public bool NewArticle(Article model, List<CategoryArticle> CAList)
        {
            model.CreatedOn = DateTime.Now;
            int UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
            model.UserID = UserID;
            DBContext.CategoryArticles.AddRange(CAList);
            DBContext.Articles.Add(model);
            int SuccessedEntries = DBContext.SaveChanges();
            if (SuccessedEntries > 0)
                return true;
            else
                return false;
        }

        public bool AddCategory(Category Cmodel, Article model)
        {
            Article AModel = SelectArticlebyID(model.ID);
            DBContext.Categories.Attach(Cmodel);
            int SuccessedEntries = DBContext.SaveChanges();
            if (SuccessedEntries > 0)
                return true;
            else
                return false;
        }

        public bool RemoveArticle(int ID)
        {
            var dataModel = DBContext.Articles.FirstOrDefault(x => x.ID == ID);
            DBContext.Articles.Remove(dataModel);
            int SuccessedEntries = DBContext.SaveChanges();
            if (SuccessedEntries > 0)
                return true;
            else
                return false;
        }

        public bool EditArticle(Article model, List<CategoryArticle> CAList)
        {
            var dataModel = DBContext.Articles.Find(model.ID);            
            dataModel.Context = model.Context;
            dataModel.Summary = model.Summary;
            dataModel.Title = model.Title;
            foreach (var item in CAList)
            {
                var CAModel = DBContext.CategoryArticles.FirstOrDefault(x => x.ArticleId == item.ArticleId);
                DBContext.CategoryArticles.Remove(CAModel);                
            }
            DBContext.CategoryArticles.AddRange(CAList);
            int SuccessedEntries = DBContext.SaveChanges();
            if (SuccessedEntries > 0)
                return true;
            else
                return false;
        }

        public Article SelectArticlebyID(int ID)
        {
            return DBContext.Articles.Find(ID);
        }
        public Article SelectArticlebyTitle(string Title)
        {
            return DBContext.Articles.Find(Title);
        }
        public ICollection<Article> SelectArticlesbyUser(User User)
        {
            int UserID = DBContext.Users.Find(User.ID).ID;
            return DBContext.Articles.Where(a => a.UserID == UserID).ToList();
        }

        public ICollection<Article> SelectAllArticles()
        {
            return DBContext.Articles.ToList();
        }

        public ICollection<Article> SelectArticlesbyCategory(Category model)
        {
            List<Article> alist = DBContext.CategoryArticles.Where(x => x.CategoryId == model.ID).Select(a => a.Article).ToList();
            return alist;
        }
    }
}