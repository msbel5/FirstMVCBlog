using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HtmlBlogMSB.Models.Data
{
    public class CategoryArticle
    {
        [Column(Order =1),Key]
        public int CategoryId { get; set; }

        [Column(Order = 2), Key]
        public int ArticleId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Article Article { get; set; }

    }
}