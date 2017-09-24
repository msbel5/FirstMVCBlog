using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HtmlBlogMSB.Models.Data
{
    public class Comment
    {
        public int ID { get; set; }
        [Required(AllowEmptyStrings = false,ErrorMessage ="Boş yorum yapamazsınız.")]
        public string Context { get; set; }
        public DateTime CreatedOn { get; set; }
        public int UserID { get; set; }
        public int ArticleID { get; set; }
        public virtual User User { get; set; }        
        public virtual Article Article { get; set; }
    }
}