using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HtmlBlogMSB.Models.Data
{
    public class Article
    {

        public Article()
        {
            this.Comments = new HashSet<Comment>();
            this.CategoryCollection = new HashSet<CategoryArticle>();
        }
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Summary { get; set; }
        [Required]
        public string Context { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        public int UserID { get; set; }

        
        public virtual User User { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<CategoryArticle> CategoryCollection { get; set; }

    }
}