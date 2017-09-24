using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace HtmlBlogMSB.Models.Data.Mappings
{
    public class ArticleMapping:EntityTypeConfiguration<Article>
    {
        public ArticleMapping()
        {
            this.HasMany(a => a.Comments).WithRequired().HasForeignKey(b => b.ArticleID).WillCascadeOnDelete(true);
        }
    }
}