using MiaoBlog.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiaoBlog.Services.Messaging.ArticleCatalogService
{
    public class GetArticlesResponse
    {
        public IEnumerable<ArticleView> Articles { get; set; }
    }
}
