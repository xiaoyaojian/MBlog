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
    public class ArticleCatalogBaseController:Controller
    {
        private readonly IArticleCatalogService articleCatalogService;


        public ArticleCatalogBaseController(IArticleCatalogService articleCatalogService)
        {
            this.articleCatalogService = articleCatalogService;
        }

        public IEnumerable<CategoryView> GetCategories()
        {
            GetAllCategoriesResponse response = articleCatalogService.GetAllCategories();
            return response.Categories;
        }
    }
}
