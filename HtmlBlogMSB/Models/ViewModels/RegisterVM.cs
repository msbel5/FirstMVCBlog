using HtmlBlogMSB.Models.Data.CustomValidations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HtmlBlogMSB.Models.ViewModels
{
    public class RegisterVM
    {
        [Required, StringLength(12, MinimumLength = 4, ErrorMessage = " En az 4 en fazla 12 karakterden oluşan kullanıcı adı girmek zorundasınız."), Index(IsUnique = true)]
        public string UserName { get; set; }
        [Required, RegularExpression(@"^(?=.*[A-Za-z])(?=.*[0-9])(?=(?:.*?[!@#$%\^&*\(\)\-_+=;:'""\/\[\]{},.<>|`]){2}).{8,15}$", ErrorMessage = "En az bir büyük harf, bir küçük harf, bir rakam ve özel işaret içeren 8 ile  15 karakterden oluşan bi şifre belirlemelisiniz.")]
        public string Password { get; set; }
        [Required, Compare("Password", ErrorMessage = "Şifreleriniz birbiriyle uyuşmalıdır.")]
        public string PasswordVerify { get; set; }
        [Required, DataType(DataType.EmailAddress, ErrorMessage = "Geçerli bir Email adresi giriniz."), Index(IsUnique = true)]
        public string Email { get; set; }
        [Required, Compare("Email", ErrorMessage = "Emailleriniz birbiriyle uyuşmalıdır.")]
        public string EmailVerify { get; set; }
        [Required, AgeValidation(ErrorMessage = "18 yaşından büyük olmalısınız.", LimitAge = 18)]
        public DateTime DoB { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        
    }
}