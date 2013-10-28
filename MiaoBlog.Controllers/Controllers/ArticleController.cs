using MiaoBlog.Controllers.ViewModels.ArticleCatalog;
using MiaoBlog.Infrastructure.Configuration;
using MiaoBlog.Services.Interfaces;
using MiaoBlog.Services.Messaging.ArticleCatalogService;
using MiaoBlog.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MiaoBlog.Controllers.Controllers
{
    public class ArticleController:ArticleCatalogBaseController
    {
        private readonly IArticleCatalogService articleCatalogService;


        public ArticleController(IArticleCatalogService articleCatalogService)
            : base(articleCatalogService)
        {
            this.articleCatalogService = articleCatalogService;
        }

        public ActionResult List(int categoryId, int index=0)
        {
            GetArticlesByCategoryRequest request = GenerateArticlesByCategoryRequestFrom(categoryId, index);
            GetArticlesByCategoryResponse response = articleCatalogService.GetArticlesByCategory(request);
            ArticleListPageView view = GetArticleListPageViewFrom(response);
            return View(view);
        }

        private ArticleListPageView GetArticleListPageViewFrom(GetArticlesByCategoryResponse response)
        {
            ArticleListPageView view = new ArticleListPageView();
            view.Categories = base.GetCategories();
            view.CurrentPage = response.CurrentPage;
            view.NumberOfArticlesFound = response.NumberOfArticlesFound;
            view.ArticleSummarys = response.Articles;
            view.SelectedCategory = response.SelectedCategory;
            view.SelectedCategoryName = response.SelectedCategoryName;
            view.TotalNumberOfPages = response.TotalNunmberOfPages;
            return view;
        }

        private static GetArticlesByCategoryRequest GenerateArticlesByCategoryRequestFrom(int categoryId, int index)
        {
            GetArticlesByCategoryRequest request = new GetArticlesByCategoryRequest();
            request.NumberOfResultsPerPage = int.Parse(ApplicationSettingsFactory.GetApplicationSettings().NumberOfResultsPerPage);
            request.Index = index;
            request.CategoryId = categoryId;
            request.ExcerptLength = int.Parse(ApplicationSettingsFactory.GetApplicationSettings().ExcerptLength);
            return request;
        }

        public ActionResult Detail(int articleId)
        {
            ArticleDetailPageView detailView = new ArticleDetailPageView();
            GetArticleRequest request = new GetArticleRequest() { ArticleId = articleId };
            GetArticleResponse response = articleCatalogService.GetArticle(request);
            ArticleView articleView = response.Article;
            detailView.Article = articleView;
            detailView.Comments = response.Comments;
            detailView.Tags = response.Tags;
            detailView.Categories = base.GetCategories();
            return View(detailView);
        }
    }
}
