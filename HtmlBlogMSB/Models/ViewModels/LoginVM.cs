﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HtmlBlogMSB.Models.ViewModels
{
    public class LoginVM
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}