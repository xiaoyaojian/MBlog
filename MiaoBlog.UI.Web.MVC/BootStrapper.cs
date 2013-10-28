using MiaoBlog.Controllers.ActionArguments;
using MiaoBlog.Infrastructure.Authentication;
using MiaoBlog.Infrastructure.Configuration;
using MiaoBlog.Infrastructure.Email;
using MiaoBlog.Infrastructure.Logging;
using MiaoBlog.Infrastructure.UnitOfWork;
using MiaoBlog.Model.Articles;
using MiaoBlog.Model.Categories;
using MiaoBlog.Model.Comments;
using MiaoBlog.Model.Tags;
using MiaoBlog.Model.Users;
using MiaoBlog.Repository.EF;
using MiaoBlog.Repository.EF.Repositories;
using MiaoBlog.Services.Implementations;
using MiaoBlog.Services.Interfaces;
using StructureMap;
using StructureMap.Configuration.DSL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiaoBlog.UI.Web.MVC
{
    public class BootStrapper
    {

        public static void ConfigureDependencies()
        {
            ObjectFactory.Initialize(x =>
                {
                    x.AddRegistry<ControllerRegistry>();
                }
            );
        }


        public class ControllerRegistry : Registry
        {
            public ControllerRegistry()
            {                
                For<ICategoryRepository>().Use<CategoryRepository>();
                For<IArticleRepository>().Use<ArticleRepository>();
                For<ICommentRepository>().Use<CommentRepository>();
                For<ITagRepository>().Use<TagRepository>();

                For<IUnitOfWork>().Use<EFUnitOfWork>();
                For<IArticleCatalogService>().Use<ArticleCatalogService>();
                For<IApplicationSettings>().Use<WebConfigApplicationSettings>();
                For<ILogger>().Use<Log4NetAdapter>();
                For<IEmailService>().Use<SMTPService>();
                For<ILocalAuthenticationService>().Use<AspMembershipAuthentication>();
                For<IFormsAuthentication>().Use<AspFormsAuthentication>();
                For<IUserService>().Use<UserService>();
                For<IActionArguments>().Use<HttpRequestActionArguments>();
                For<IUserRepository>().Use<UserRepository>();
            }
        }
    }
}