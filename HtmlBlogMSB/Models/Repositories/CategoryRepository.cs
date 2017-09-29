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
            var dataModel = DBContext.Categories.FirstOrDefault(x => x.ID == ID);
            DBContext.Categories.Remove(dataModel);
            int SuccessedEntries = DBContext.SaveChanges();
            if (SuccessedEntries > 0)
                return true;
            else
                return false;
        }

        public bool EditCategory(Category model)
        {
            var dataModel = DBContext.Categories.FirstOrDefault(x=>x.ID==model.ID);
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
            return DBContext.Categories.FirstOrDefault(x=>x.Name==Name);
        }

        public ICollection<Category> SelectAllCategory()
        {
            return DBContext.Categories.ToList();
        }

        public ICollection<Category> SelectCategorybyArticle(Article model)
        {
            List<Category> clist = DBContext.CategoryArticles.Where(x => x.ArticleId == model.ID).Select(a => a.Category).ToList();
            return clist;
        }
    }
}