using HtmlBlogMSB.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HtmlBlogMSB.Models.Repositories
{
    public class UserRepository
    {
        ProjectContext DBContext = new ProjectContext();

        public bool NewUser(User model)
        {
            DBContext.Users.Add(model);
            int SuccessedEntries = DBContext.SaveChanges();
            if (SuccessedEntries > 0)
                return true;
            else
                return false;
        }

        public bool RemoveUser(int ID)
        {
           var dataModel= DBContext.Users.Find(ID);
           bool IsSuccessed = DBContext.Users.Remove(dataModel)==null ? false:true;
            if (IsSuccessed)
                return true;
            else
                return false;
        }

        public bool EditUser(User model)
        {
            var dataModel = DBContext.Users.Find(model.ID);
            dataModel.DoB = model.DoB;
            dataModel.Email = model.Email;
            dataModel.EmailVerify = model.EmailVerify;
            dataModel.IsActivated = model.IsActivated;
            dataModel.IsAdmin = model.IsAdmin;
            dataModel.Name = model.Name;
            dataModel.Password = model.Password;
            dataModel.PasswordVerify = model.PasswordVerify;
            dataModel.SurName = model.SurName;
            int SuccessedEntries = DBContext.SaveChanges();
            if (SuccessedEntries > 0)
                return true;
            else
                return false;
        }

        public User SelectUserbyID(int ID)
        {
            return DBContext.Users.Find(ID);
        }
        public User SelectUserbyEmail(string Email)
        {
            return DBContext.Users.Find(Email);
        }
        public User SelectUserbyUserName(string UserName)
        {
            return DBContext.Users.Find(UserName);
        }

        public ICollection<User> SelectAllUser()
        {
            return DBContext.Users.ToList();
        }

    }
}