﻿using HtmlBlogMSB.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HtmlBlogMSB.Models.Repositories
{
    public class ArticleRepository
    {
        ProjectContext DBContext = new ProjectContext();
        public bool NewArticle(Article model)
        {
            DBContext.Articles.Add(model);
            int SuccessedEntries = DBContext.SaveChanges();
            if (SuccessedEntries > 0)
                return true;
            else
                return false;
        }

        public bool RemoveArticle(int ID)
        {
            var dataModel = DBContext.Articles.Find(ID);
            bool IsSuccessed = DBContext.Articles.Remove(dataModel) == null ? false : true;
            if (IsSuccessed)
                return true;
            else
                return false;
        }

        public bool EditArticle(Article model)
        {
            var dataModel = DBContext.Articles.Find(model.ID);
            dataModel.Context = model.Context;
            dataModel.Summary = model.Summary;
            dataModel.Title = model.Title;            
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
            return DBContext.Articles.Where(a => a.UserID==UserID).ToList();                
        }

        public ICollection<Article> SelectAllArticles()
        {
            return DBContext.Articles.ToList();
        }

        public ICollection<Article> SelectArticlesbyCategory(Category model)
        {
            Category Category = DBContext.Categories.Find(model.ID);
            return Category.Articles.ToList();
        }
    }
}