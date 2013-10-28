using MiaoBlog.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiaoBlog.Controllers.ViewModels.ArticleCatalog
{
    public class ArticleDetailPageView:BaseArticleCatalogPageView
    {
        public ArticleView Article { get; set; }
        public IEnumerable<TagSummaryView> Tags { get; set; }
        public IEnumerable<CommentSummaryView> Comments { get; set; }
    }
}
