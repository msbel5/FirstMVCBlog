using HtmlBlogMSB.Models.Data.CustomValidations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HtmlBlogMSB.Models.Data
{
    public class User
    {
        public User()
        {
            this.Articles = new HashSet<Article>();
            this.Comments = new HashSet<Comment>();
        }
        public int ID { get; set; }
        [Required, StringLength(12, MinimumLength =4, ErrorMessage = " En az 4 en fazla 12 karakterden oluşan kullanıcı adı girmek zorundasınız."),Index(IsUnique =true)]
        public string UserName { get; set; }
        [Required, RegularExpression(@"^(?=.*[a - z])(?=.*[A - Z])(?=.*\d)(?=.*[^\da - zA - Z]).{8, 15}$",ErrorMessage ="En az bir büyük harf, bir küçük harf, bir rakam ve özel işaret içeren 8 ile  15 karakterden oluşan bi şifre belirlemelisiniz.")]
        public string Password { get; set; }
        [Required, Compare("Password",ErrorMessage ="Şifreleriniz birbiriyle uyuşmalıdır.")]
        public string PasswordVerify { get; set; }
        [Required, DataType(DataType.EmailAddress,ErrorMessage ="Geçerli bir Email adresi giriniz."), Index(IsUnique = true)]
        public string Email { get; set; }
        [Required, Compare("Email",ErrorMessage ="Emailleriniz birbiriyle uyuşmalıdır.")]
        public string EmailVerify { get; set; }
        [Required, AgeValidation(ErrorMessage ="18 yaşından büyük olmalısınız.",LimitAge =18)]
        public DateTime DoB { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        [Required]
        public bool IsAdmin { get; set; }
        [Required]
        public string ActivationCode { get; set; }
        [Required]
        public bool IsActivated { get; set; }       


        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Article> Articles { get; set; }

    }


    
}