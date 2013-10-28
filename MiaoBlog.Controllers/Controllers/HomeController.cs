using MiaoBlog.Controllers.ViewModels.ArticleCatalog;
using MiaoBlog.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MiaoBlog.Controllers.Controllers
{
    public class HomeController:ArticleCatalogBaseController
    {
        private readonly IArticleCatalogService articleCatalogService;


        public HomeController(IArticleCatalogService articleCatalogService)
            : base(articleCatalogService)
        {
            this.articleCatalogService = articleCatalogService;
        }

        public ActionResult Index()
        {
            return RedirectToAction("List", "Article");
        }
    }
}
