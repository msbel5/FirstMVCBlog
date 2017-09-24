using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace HtmlBlogMSB.Models.Data.Mappings
{
    public class UserMapping:EntityTypeConfiguration<User>
    {
        public UserMapping()
        {
            this.HasMany(a => a.Articles).WithRequired().HasForeignKey(c=>c.UserID).WillCascadeOnDelete(false);
            this.HasMany(b => b.Comments).WithRequired().HasForeignKey(d => d.UserID).WillCascadeOnDelete(false);
            
        }
    }
}