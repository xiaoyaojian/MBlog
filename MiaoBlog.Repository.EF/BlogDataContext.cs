using MiaoBlog.Model.Articles;
using MiaoBlog.Model.Categories;
using MiaoBlog.Model.Comments;
using MiaoBlog.Model.Tags;
using MiaoBlog.Model.Users;
using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiaoBlog.Repository.EF
{
    public class BlogDataContext:ObjectContext
    {
        private ObjectSet<Category> categories;
        private ObjectSet<Article> articles;
        private ObjectSet<Comment> comments;
        private ObjectSet<Tag> tags;
        private ObjectSet<User> users;


        public BlogDataContext()
            : base("name=MiaoBlogEntities", "BlogEntities")
        {
            categories = CreateObjectSet<Category>();
            articles = CreateObjectSet<Article>();
            comments = CreateObjectSet<Comment>();
            tags = CreateObjectSet<Tag>();
            users = CreateObjectSet<User>();
            base.ContextOptions.LazyLoadingEnabled = true;
        }

        public ObjectSet<Category> Categories
        {
            get { return this.categories; }
        }

        public ObjectSet<Article> Articles
        {
            get { return this.articles; }
        }

        public ObjectSet<Comment> Comments
        {
            get { return this.comments; }
        }

        public ObjectSet<Tag> Tags
        {
            get { return this.tags; }
        }

        public ObjectSet<User> Users
        {
            get { return this.users; }
        }
    }
}
