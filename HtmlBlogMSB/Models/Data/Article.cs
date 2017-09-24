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
            this.Categories = new HashSet<Category>();
        }
        public int ID { get; set; }
        [Required, StringLength(35,MinimumLength =10,ErrorMessage ="10 ile 35 arasında karakter içeren bi başlık girmelisiniz.")]
        public string Title { get; set; }
        [Required, StringLength(500, MinimumLength =100,ErrorMessage = "100 ile 500 arasında karakter içeren bir özet girmelisiniz.")]
        public string Summary { get; set; }
        [Required, StringLength(1500, MinimumLength = 500, ErrorMessage = "500 ile 1500 arasında karakter içeren bir içerik girmelisiniz.")]
        public string Context { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        public int UserID { get; set; }

        
        public virtual User User { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Category> Categories { get; set; }

    }
}