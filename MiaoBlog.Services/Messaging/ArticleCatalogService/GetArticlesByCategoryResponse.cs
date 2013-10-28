using MiaoBlog.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiaoBlog.Services.Messaging.ArticleCatalogService
{
    public class GetArticlesByCategoryResponse
    {
        public string SelectedCategoryName { get; set; }
        public int SelectedCategory { get; set; }
        public int NumberOfArticlesFound { get; set; }
        public int TotalNunmberOfPages { get; set; }
        public int CurrentPage { get; set; }
        public IEnumerable<ArticleSummaryView> Articles { get; set; }
    }
}
