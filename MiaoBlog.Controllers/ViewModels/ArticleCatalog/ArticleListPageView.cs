using MiaoBlog.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiaoBlog.Controllers.ViewModels.ArticleCatalog
{
    public class ArticleListPageView:BaseArticleCatalogPageView
    {
        public IEnumerable<ArticleSummaryView> ArticleSummarys { get; set; }

        public string SelectedCategoryName { get; set; }
        public int SelectedCategory { get; set; }
        public int NumberOfArticlesFound { get; set; }
        public int TotalNumberOfPages { get; set; }
        public int CurrentPage { get; set; }
    }
}
