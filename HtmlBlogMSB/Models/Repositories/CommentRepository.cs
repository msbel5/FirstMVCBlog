using HtmlBlogMSB.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HtmlBlogMSB.Models.Repositories
{
    public class CommentRepository
    {
        ProjectContext DBContext = new ProjectContext();

        public bool NewComment(Comment model)
        {
            model.CreatedOn = DateTime.Now;
            DBContext.Comments.Add(model);
            int SuccessedEntries = DBContext.SaveChanges();
            if (SuccessedEntries > 0)
                return true;
            else
                return false;
        }

        public bool RemoveComments(int ID)
        {
            var dataModel = DBContext.Comments.FirstOrDefault(x => x.ID == ID);
            DBContext.Comments.Remove(dataModel);
            int SuccessedEntries = DBContext.SaveChanges();
            if (SuccessedEntries > 0)
                return true;
            else
                return false;
        }

        public bool EditComment(Comment model)
        {
            var dataModel = DBContext.Comments.Find(model.ID);
            dataModel.Context = model.Context;
            int SuccessedEntries = DBContext.SaveChanges();
            if (SuccessedEntries > 0)
                return true;
            else
                return false;
        }     
        
        public ICollection<Comment> SelectCommentsbyCurrentUser()
        {
            int UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
            return DBContext.Comments.Where(x => x.UserID == UserID).ToList();
        }       

        public ICollection<Comment> SelectCommentsbyArticle(Article model)
        {
            int ArticleID = DBContext.Articles.Find(model.ID).ID;
            return DBContext.Comments.Where(a=>a.ArticleID==ArticleID).ToList();
        }

        public Comment SelectCommentbyID(int ID)
        {
            var dataModel = DBContext.Comments.Find(ID);
            return dataModel;
        }

    }
}