using CookComputing.MetaWeblog;
using CookComputing.XmlRpc;
using MiaoBlog.Infrastructure.Authentication;
using MiaoBlog.Services.Interfaces;
using MiaoBlog.Services.Messaging.ArticleCatalogService;
using MiaoBlog.Services.ViewModels;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiaoBlog.UI.Web.MVC.XmlRpc
{
    public class MetaWeblog : XmlRpcService, IMetaWeblog
    {
        private readonly IArticleCatalogService articleCatalogService;
        private readonly ILocalAuthenticationService authenticationService;

        public MetaWeblog()
        {
            this.articleCatalogService = ObjectFactory.GetInstance<IArticleCatalogService>();
            this.authenticationService = ObjectFactory.GetInstance<ILocalAuthenticationService>();
        }


        //public MetaWeblog(IArticleCatalogService articleCatalogService, ILocalAuthenticationService authenticationService)
        //{
        //    this.articleCatalogService = articleCatalogService;
        //    this.authenticationService = authenticationService;
        //}


        public UserBlog[] GetUserBlogs(string appKey, string username, string password)
        {
            Account account = authenticationService.Login(username, password);
            if (account.IsAuthenticated)
            {
                UserBlog blog = new UserBlog();
                blog.BlogId = "";
                blog.BlogName = "MiaoBlog";
                blog.Url = "http://localhost:18646/";
               
                List<UserBlog> blogs = new List<UserBlog>();
                blogs.Add(blog);
                return blogs.ToArray();
            }
            throw new XmlRpcFaultException(0, "User is not valid!");
        }

        public object editPost(string postid, string username, string password, Post post, bool publish)
        {
            throw new NotImplementedException();
        }

        public CategoryInfo[] getCategories(string blogid, string username, string password)
        {
            Account account = authenticationService.Login(username, password);
            if (account.IsAuthenticated)
            {
                GetAllCategoriesResponse response = articleCatalogService.GetAllCategories();
                List<CategoryInfo> categories = new List<CategoryInfo>();
                foreach (CategoryView categoryView in response.Categories)
                {
                    CategoryInfo category = new CategoryInfo();
                    category.categoryid = categoryView.Id.ToString();
                    category.title = categoryView.Name;
                    category.description = categoryView.Name;
                    categories.Add(category);
                }
                return categories.ToArray();
            }
            else
            {
                return null;
            }
        }

        public Post getPost(string postid, string username, string password)
        {
            Account account = authenticationService.Login(username, password);
            if (account.IsAuthenticated)
            {
                GetArticleRequest request = new GetArticleRequest();
                request.ArticleId = int.Parse(postid);
                GetArticleResponse response = articleCatalogService.GetArticle(request);
                ArticleView articleView = response.Article;
                Post post = new Post();
                post.postid = postid;
                post.title = articleView.Title;
                post.userid = "1";
                post.dateCreated = DateTime.Parse(articleView.CreateTime);
                post.description = articleView.Content;
                post.categories = new string[] { articleView.CategoryName };
                return post;
            }
            else
            {
                return default(Post);
            }
        }

        public Post[] getRecentPosts(string blogid, string username, string password, int numberOfPosts)
        {
            Account account = authenticationService.Login(username, password);
            if (account.IsAuthenticated)
            {
                GetArticlesRequest request = new GetArticlesRequest();
                request.CategoryId = 0;
                request.NumberOfResult = numberOfPosts;
                GetArticlesResponse response = articleCatalogService.GetArticles(request);
                List<ArticleView> views = response.Articles.ToList();
                List<Post> posts = new List<Post>();
                foreach (ArticleView view in views)
                {
                    Post post = new Post();
                    post.postid = view.Id;
                    post.title = view.Title;
                    post.userid = "1";
                    post.dateCreated = DateTime.Parse(view.CreateTime);
                    post.description = view.Content;
                    post.categories = new string[] { view.CategoryName };
                    posts.Add(post);
                }
                return posts.ToArray();
            }
            else
            {
                return null;
            }
        }

        public string newPost(string blogid, string username, string password, Post post, bool publish)
        {
            throw new NotImplementedException();
        }

        public UrlData newMediaObject(string blogid, string username, string password, FileData file)
        {
            throw new NotImplementedException();
        }
    }
}