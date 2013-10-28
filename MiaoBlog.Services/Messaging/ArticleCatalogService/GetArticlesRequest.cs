using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiaoBlog.Services.Messaging.ArticleCatalogService
{
    public class GetArticlesRequest
    {
        public int NumberOfResult { get; set; }
        public int CategoryId { get; set; }
    }
}
