using HtmlBlogMSB.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HtmlBlogMSB.Models.Repositories
{
    public class CategoryRepository
    {
        ProjectContext DBContext = new ProjectContext();

        public bool NewCategory(Category model)
        {
            DBContext.Categories.Add(model);
            int SuccessedEntries = DBContext.SaveChanges();
            if (SuccessedEntries > 0)
                return true;
            else
                return false;
        }

        public bool RemoveCategory(int ID)
        {
            var dataModel = DBContext.Categories.Find(ID);
            bool IsSuccessed = DBContext.Categories.Remove(dataModel) == null ? false : true;
            if (IsSuccessed)
                return true;
            else
                return false;
        }

        public bool EditCategory(Category model)
        {
            var dataModel = DBContext.Categories.Find(model.ID);
            dataModel.Name = model.Name;
            dataModel.Description=model.Description;
            int SuccessedEntries = DBContext.SaveChanges();
            if (SuccessedEntries > 0)
                return true;
            else
                return false;
        }

        public Category SelectCategorybyID(int ID)
        {
            return DBContext.Categories.Find(ID);
        }

        public Category SelectCategorybyName(string Name)
        {
            return DBContext.Categories.Find(Name);
        }

        public ICollection<Category> SelectAllCategory()
        {
            return DBContext.Categories.ToList();
        }

        public ICollection<Category> SelectCategorybyArticle(Article model)
        {
            Article Article = DBContext.Articles.Find(model.ID);
            return Article.Categories.ToList();
        }
    }
}