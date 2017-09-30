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
            model.CreatedOn = DateTime.Now;
            model.ActivationCode = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 20);
            DBContext.Users.Add(model);
            int SuccessedEntries = DBContext.SaveChanges();
            if (SuccessedEntries > 0)
                return true;
            else
                return false;
        }

        public bool RemoveUser(int ID)
        {
            var dataModel = DBContext.Users.FirstOrDefault(x => x.ID == ID);
            DBContext.Users.Remove(dataModel);
            int SuccessedEntries = DBContext.SaveChanges();
            if (SuccessedEntries > 0)
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
            return DBContext.Users.FirstOrDefault(x => x.ID == ID);
        }
        public User SelectUserbyEmail(string Email)
        {
            return DBContext.Users.FirstOrDefault(x => x.Email == Email);
        }
        public User SelectUserbyUserName(string UserName)
        {
            return DBContext.Users.FirstOrDefault(x => x.UserName == UserName);
        }

        public User GetCurrentUser()
        {
            int UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
            User CurrentUser = SelectUserbyID(UserID);
            return CurrentUser;
        }

        public ICollection<User> SelectAllUser()
        {
            return DBContext.Users.ToList();
        }

    }
}