using HtmlBlogMSB.Models.Data.Mappings;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HtmlBlogMSB.Models.Data
{
    public class ProjectContext : DbContext
    {

        public ProjectContext():base("name=BlogConn")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<ProjectContext>());
        }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserMapping());
            modelBuilder.Configurations.Add(new ArticleMapping());

        }
    }
}