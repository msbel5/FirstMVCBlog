using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HtmlBlogMSB.Models.Data
{
    public class Category
    {
        public Category()
        {
            this.Articles = new HashSet<Article>();
        }
        public int ID { get; set; }
        [Required, StringLength(20,MinimumLength =4, ErrorMessage ="4 ile 20 arasında karakter içeren bir isim girmelisiniz.")]
        public string Name { get; set; }
        [Required, StringLength(50,MinimumLength =10, ErrorMessage ="10 ile 50 arasında karakter içeren bir açıklama yazmalısınız.")]
        public string Description { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
    }
}