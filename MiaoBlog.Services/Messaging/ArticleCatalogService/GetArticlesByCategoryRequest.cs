using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiaoBlog.Services.Messaging.ArticleCatalogService
{
    public class GetArticlesByCategoryRequest
    {
        public int CategoryId { get; set; }
        public int Index { get; set; }
        public int NumberOfResultsPerPage { get; set; }
        public int ExcerptLength { get; set; }
    }
}
